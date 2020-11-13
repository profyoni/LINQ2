using System;
using System.Collections.Generic;

// implement IEnumerable Primes() that returns all primes (until long overflow)
// implement IEnumerable Fibonacci sequence iterating with a specified seed.
// Fibonacci(0,1) will return the Fib sequence 0,1,1,2,3,5,8
// Fibonacci(1,3) will return the Fib sequence 1,3,4,7,11,18,29,
// Fibonacci(100) will return the 100th Fibonacci number using the standard sequence 0,1,1,2,3,5

namespace LINQ2
{
    public class Class1
    {
        public static int Plus(int a, int b)
        {
            return a + b;
        }
        public static int Minus(int a, int b)
        {
            return a - b;
        }
        public static int Times(int a, int b)
        {
            return a * b;
        }
        public static int DivideBy(int a, int b)
        {
            return a / b;
        }

        // delegate type
        public delegate int IntMethodThatTakesTwoIntArgs(int a, int b);// data type that is used to store methods

        // delegate variable
        private IntMethodThatTakesTwoIntArgs method;

        // method(), the parentheses are often referred to as the function invocation operator
        
        public static IEnumerable<int> Process(
            IEnumerable<(int, int)> list,
            IntMethodThatTakesTwoIntArgs twoArgMethod = null)
        {
            if (twoArgMethod == null)
                twoArgMethod = Plus;
            List<int> ret = new List<int>();
            foreach (var pair in list)
            {
                var val = twoArgMethod(pair.Item1, pair.Item2);
                ret.Add(val );
            }
            return ret;
        }
    }
}
