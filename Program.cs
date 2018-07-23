using System;
using BenchmarkDotNet.Running;

namespace BenchmarkTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to benchmark tests!");

            var mvs = BenchmarkRunner.Run<Md5VsSha256>();
        }
    }
}
