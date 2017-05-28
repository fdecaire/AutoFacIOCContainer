using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyClasses;

namespace UnitTests
{
	[TestClass]
	public class MyTests
	{
		[TestMethod]
		public void test_temp_directory_exists()
		{
			var mockFileSystem = new Mock<IFileSystem>();
			mockFileSystem.Setup(x => x.DirectoryExists("c:\\temp")).Returns(true);

			var myObject = new ChildClass(mockFileSystem.Object);
			myObject.IncrementIfTempDirectoryExists();
			Assert.AreEqual(1, myObject.TotalNumbers());
		}

		[TestMethod]
		public void test_temp_directory_missing()
		{
			var mockFileSystem = new Mock<IFileSystem>();
			mockFileSystem.Setup(x => x.DirectoryExists("c:\\temp")).Returns(false);

			var myObject = new ChildClass(mockFileSystem.Object);
			myObject.IncrementIfTempDirectoryExists();
			Assert.AreEqual(0, myObject.TotalNumbers());
		}

		[TestMethod]
		public void test_root_count_exceeded_true()
		{
			var mockChildClass = new Mock<IChildClass>();
			mockChildClass.Setup(x => x.TotalNumbers()).Returns(12);

			var myObject = new MyRootClass(mockChildClass.Object);
			myObject.Increment();
			Assert.AreEqual(true, myObject.CountExceeded());
		}

		[TestMethod]
		public void test_root_count_exceeded_false()
		{
			var mockChildClass = new Mock<IChildClass>();
			mockChildClass.Setup(x => x.TotalNumbers()).Returns(1);

			var myObject = new MyRootClass(mockChildClass.Object);
			myObject.Increment();
			Assert.AreEqual(false, myObject.CountExceeded());
		}
	}
}
