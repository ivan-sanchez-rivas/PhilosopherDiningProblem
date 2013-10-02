using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PhilosopherDiningProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Filosofos filosofo = new Filosofos();
                var p1 = new Thread(() =>
                {
                    while (true)
                    {
                        filosofo.RecogerDejar(0);
                    }
                });
                var p2 = new Thread(() =>
                {
                    while (true)
                    {
                        filosofo.RecogerDejar(1);
                    }
                });
                var p3 = new Thread(() =>
                {
                    while (true)
                    {
                        filosofo.RecogerDejar(2);
                    }
                });
                var p4 = new Thread(() =>
                {
                    while (true)
                    {
                        filosofo.RecogerDejar(3);
                    }
                });
                var p5 = new Thread(() =>
                {
                    while (true)
                    {
                        filosofo.RecogerDejar(4);
                    }
                });

                p1.Start();
                p2.Start();
                p3.Start();
                p4.Start();
                p5.Start();
        }
    }
}
