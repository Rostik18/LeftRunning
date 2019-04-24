using System;

namespace LeftRunning
{
    class Program
    {
        class Method
        {
            public int n;
            public double[] a;
            public double[] b;
            public double[] c;
            public double[] f;
            public double[] y;
            public double x1;
            public double x2;
            public double[] alfa;
            public double[] beta;
            double h;

            public Method()
            {
            }

            public void InitData()
            {
                n = 100;

                a = new double[n + 1];
                b = new double[n + 1];
                c = new double[n + 1];
                f = new double[n + 1];
                y = new double[n + 1];
                alfa = new double[n + 1];
                beta = new double[n + 1];

                h = 1.0 / n;

                x1 = 1 * h;
                x2 = 2 * h;

                f[0] = 2;
                f[n] = 2 / Math.Pow(1 + n * h, 3);

                y[0] = 1;
                y[n] = 0.5;

                for (int i = 1; i <= n - 1; i++)
                {
                    a[i] = 1 / (h * h) + (1 + i * h) / 2 * h;
                    b[i] = 1 / (h * h) - (1 + i * h) / 2 * h;
                    c[i] = 1 + 2 / (h * h);
                    f[i] = 2 / Math.Pow(1 + i * h, 3);
                }
                alfa[n] = x2;
                beta[n] = f[n];
            }
            public void Tridiagonal()
            {
                for (int i = n - 1; i >= 1; i--)
                {
                    alfa[i] = a[i] / (c[i] - alfa[i + 1] * b[i]);
                    beta[i] = (b[i] * beta[i + 1] + f[i]) / (c[i] - alfa[i + 1] * b[i]);
                }
                y[0] = (f[0] + x1 * beta[1]) / (1 - alfa[1] * x1);

                for (int i = 0; i <= n - 1; i++)
                {
                    y[i + 1] = alfa[i + 1] * y[i] + beta[i + 1];
                }
            }

            public void PrintRezult()
            {
                Console.WriteLine("Вектор а:");
                for (int i = 1; i < n; i++)
                {
                    Console.Write("{0:f3}  ", a[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Вектор b:");
                for (int i = 1; i < n; i++)
                {
                    Console.Write("{0:f3}  ", b[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Вектор c:");
                for (int i = 1; i < n; i++)
                {
                    Console.Write("{0:f3}  ", c[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Вектор f:");
                for (int i = 0; i < n + 1; i++)
                {
                    Console.Write("{0:f3}  ", f[i]);
                }
                Console.WriteLine();
                for (int i = 0; i < y.Length; i++)
                {
                    Console.WriteLine($"y[{i}] = {y[i]}");
                }

                Console.WriteLine("Точний розв'язок:");
                for (int i = 0; i < n + 1; i++)
                {
                    Console.WriteLine($"y[{i}] = {y[i]:f5}");
                }
            }

            public void Run()
            {
                InitData();
                Tridiagonal();
                PrintRezult();
            }
        }

        static void Main(string[] args)
        {
            Method method = new Method();
            method.Run();

            Console.ReadKey();
        }
    }
}
