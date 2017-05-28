namespace MyClasses
{
	public class MyRootClass : IMyRootClass
	{
		private readonly IChildClass _childClass;

		public MyRootClass(IChildClass childClass)
		{
			_childClass = childClass;
		}

		public bool CountExceeded()
		{
			if (_childClass.TotalNumbers() > 5)
			{
				return true;
			}
			return false;
		}

		public void Increment()
		{
			_childClass.IncrementIfTempDirectoryExists();
		}
	}
}
