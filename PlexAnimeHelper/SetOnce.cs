namespace PlexAnimeHelper
{
	public class SetOnce<T>
	{
		private bool isSet = false;
		private T value;

		public T Value
		{
			get
			{
				if (!isSet)
				{
					throw new System.Exception("Value is not set!");
				}

				return value;
			}
			set
			{
				if (isSet)
				{
					throw new System.Exception("Value can only be set once!");
				}
				
				this.value = value;
				isSet = true;

				Set?.Invoke();
			}
		}

		public delegate void OnSet();
		public event OnSet Set;

		public SetOnce()
		{

		}

		public SetOnce(T initialValue)
		{
			Value = initialValue;
		}

		public static implicit operator T(SetOnce<T> value) { return value.Value; }
	}
}
