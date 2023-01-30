// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public class Program
{
    [MemoryDiagnoser]
    public class NXBenchMarks
    {
        string bigOrg = "3.27AC";
        Big bigNum = new Big(3.1234E+105);

        [Benchmark]
        public void ParseTest()
        {
            Big.Parse("3.25AC");

        }

        [Benchmark]
        public void ToStringTest()
        {
            bigNum.ToString();
        }
    }

    static void Main(string[] args)
    {

        var summary = BenchmarkRunner.Run<NXBenchMarks>();
    }
}