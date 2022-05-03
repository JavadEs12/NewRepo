using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    public interface ISum
    {
        public double Sum(double left, double right);
    }

    internal class Sum : ISum
    {
        double ISum.Sum(double left, double right)
        {
            return left + right;
        }
    }

    internal class AnotherSum : ISum
    {
        public double Sum(double left, double right)
        {
            return left + right;
        }
    }

    public class SumClient
    {
        public ISum Adder { get; set; }

        public void DoWork()
        {
            var value = Adder.Sum(1, 1);
        }
    }

    public static class SumClientBuilder
    {
        public static SumClient Build(int option)
        {
            if (option == 0)
            {
                return new SumClient { Adder = new Sum() };
            }
            else
            {
                return new SumClient { Adder = new AnotherSum() };
            }
        }
    }
}
