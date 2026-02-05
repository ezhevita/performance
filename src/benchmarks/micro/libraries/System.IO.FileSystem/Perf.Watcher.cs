using BenchmarkDotNet.Attributes;
using MicroBenchmarks;

namespace System.IO.Tests
{
	[BenchmarkCategory(Categories.Libraries)]
	public class Perf_Watcher
	{
		private readonly string _path = FileUtils.GetTestFilePath();

		[GlobalSetup]
		public void Setup()
		{
			Directory.CreateDirectory(_path);
		}

		[GlobalCleanup]
		public void Cleanup()
		{
			Directory.Delete(_path, true);
		}

		[Benchmark]
		public void Start()
		{
			using var fsw = new FileSystemWatcher(Path.GetDirectoryName(_path));
			fsw.EnableRaisingEvents = true;
		}
	}
}
