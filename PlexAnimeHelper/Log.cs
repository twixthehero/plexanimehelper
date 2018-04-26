using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public class Log
{
	private static Log instance;

	public ELogLevel LogLevel { get; set; }
	public bool Running { get; private set; }

	private Thread thread;
	private Queue<LogMessage> messages = new Queue<LogMessage>();
	private StreamWriter sw;

	public static void Shutdown()
	{
		instance.Stop();
	}

	static Log()
	{
		if (instance != null)
		{
			E("Tried to re-init Log!");
			return;
		}

		instance = new Log();
	}

	private Log()
	{
		LogLevel = ELogLevel.Debug;

		if (!Directory.Exists("logs"))
		{
			Directory.CreateDirectory("logs");
		}

		string file = Path.Combine("logs", $"log-{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss-ffff")}.txt");
		sw = new StreamWriter(File.Open(file, FileMode.Create, FileAccess.Write, FileShare.Read))
		{
			AutoFlush = true
		};

		thread = new Thread(new ThreadStart(Run));
		thread.Start();
	}

	private LogMessage msg;

	private void Run()
	{
		Running = true;

		while (Running)
		{
			LogAll();

			Thread.Sleep(100);
		}

		LogAll();

		sw.Close();
	}

	private void LogAll()
	{
		while (messages.Count > 0)
		{
			msg = messages.Dequeue();

			if (msg.Level >= LogLevel)
			{
				sw.WriteLine(msg.ToString());
			}
		}
	}

	private void Stop()
	{
		Running = false;
		thread.Join();
	}

	public static void SetLogLevel(ELogLevel level)
	{
		instance.LogLevel = level;
	}

	public static void E(object o)
	{
		instance.messages.Enqueue(new LogMessage(ELogLevel.Error, o));
	}

	public static void I(object o)
	{
		instance.messages.Enqueue(new LogMessage(ELogLevel.Info, o));
	}

	public static void W(object o)
	{
		instance.messages.Enqueue(new LogMessage(ELogLevel.Warning, o));
	}

	public static void D(object o)
	{
		instance.messages.Enqueue(new LogMessage(ELogLevel.Debug, o));
	}
	
	private class LogMessage
	{
		public string Time { get; private set; }
		public ELogLevel Level { get; private set; }
		public object Message { get; private set; }

		public LogMessage(ELogLevel level, object msg)
		{
			Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff");
			Level = level;
			Message = msg;

			if (level >= instance.LogLevel)
			{
				Console.WriteLine(this);
			}
		}

		public override string ToString()
		{
			return $"[{Time}][{Level}] {Message}";
		}
	}
}
