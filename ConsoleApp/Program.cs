using System;
using Autofac;
using MyClasses;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			IOCContainer.Setup();

			using (var myLifetime = IOCContainer.Container.BeginLifetimeScope())
			{
				var myRootClass = myLifetime.Resolve<IMyRootClass>();

				myRootClass.Increment();

				Console.WriteLine(myRootClass.CountExceeded());
				Console.ReadKey();
			}
		}

		public static class IOCContainer
		{
			public static IContainer Container { get; set; }

			public static void Setup()
			{
				var builder = new ContainerBuilder();

				builder.Register(x => new FileSystem())
					.As<IFileSystem>()
					.PropertiesAutowired()
					.SingleInstance();

				builder.Register(x => new ChildClass(x.Resolve<IFileSystem>()))
					.As<IChildClass>()
					.PropertiesAutowired()
					.SingleInstance();

				builder.Register(x => new MyRootClass(x.Resolve<IChildClass>()))
					.As<IMyRootClass>()
					.PropertiesAutowired()
					.SingleInstance();

				Container = builder.Build();
			}
		}
	}
}
