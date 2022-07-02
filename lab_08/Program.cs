using System;
using System.Collections.Generic;
using System.Threading;

namespace lab_08
{
    class Program
    {
        public static bool isPrimeNumber (long number) 
        {
            long limit = (long)Math.Floor(Math.Sqrt(number));
            for (long i = 2; i <= limit; ++i)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {

            HashSet<long> hs = new HashSet<long>();


            Thread thread1 = new Thread(() =>
			{               
                for (int i = 0; i <= 1000; i+=4)
				{
                    if(isPrimeNumber(i))
                    {
                        lock (hs)
                        {

                            hs.Add(i);

                        }
                    }
                }
                    
                    
			});
            Thread thread2 = new Thread(() =>
            {
                for (int i = 1; i <= 1000; i += 4)
                {
                    if (isPrimeNumber(i))
                    {
                        lock (hs)
                        {

                            hs.Add(i);

                        }
                    }
     
                }
            });
            Thread thread3 = new Thread(() =>
            {
                for (int i = 2; i <= 1000; i += 4)
                {
                    if (isPrimeNumber(i))
                    {
                        lock (hs)
                        {

                            hs.Add(i);

                        }
                    }

                }
            });
            Thread thread4 = new Thread(() =>
            {
                for (int i = 3; i <= 1000; i += 4)
                {
                    lock (hs)
                    {

                        hs.Add(i);

                    }
                }
            });
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

                Console.WriteLine(hs.Count);
            
           
        }
    }
}
