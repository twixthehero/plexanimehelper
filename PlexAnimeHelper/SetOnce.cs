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

		public override int GetHashCode()
		{
			int hash = 23;

			hash = (hash * 7) + isSet.GetHashCode();
			hash = (hash * 7) + value.GetHashCode();

			return hash;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is SetOnce<T>))
			{
				return false;
			}

			SetOnce<T> other = (SetOnce<T>)obj;

			return isSet == other.isSet && Value.Equals(other.Value);
		}

		public static bool operator ==(SetOnce<T> s1, SetOnce<T> s2)
		{
			return s1.Equals(s2);
		}

		public static bool operator !=(SetOnce<T> s1, SetOnce<T> s2)
		{
			return !s1.Equals(s2);
		}

		public static implicit operator T(SetOnce<T> value) { return value.Value; }
	}
}
