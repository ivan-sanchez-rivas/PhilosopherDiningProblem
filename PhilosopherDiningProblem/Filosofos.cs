using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PhilosopherDiningProblem
{
    public class Filosofos
    {

        Semaphore semcomer;
        int NumFilosofos = 5;
        int pensar = 1, hambre = 2, comer = 3;
        int[] estado;
        string[] nombre;
        
        public Filosofos()
        {
            estado = new int[NumFilosofos];
            semcomer = new Semaphore(1, NumFilosofos);
            nombre = new string[] { "Filosofo 1", "Filosofo 2", "Filosofo 3", "Filosofo 4", "Filosofo 5"};
            for (int i = 0; i < NumFilosofos; i++)
            {
                estado[i] = pensar;
                Console.WriteLine(nombre[i] + " Esta pensando \n");
            }
        }
        private void Dejar(int filosofo)
        {
                semcomer.WaitOne();
                estado[filosofo] = pensar;
                Console.WriteLine(nombre[filosofo] + " Esta pensando \n");
                Comer((filosofo + 4) % NumFilosofos);
                Comer((filosofo + 1) % NumFilosofos);
                Console.WriteLine(nombre[filosofo] + " Dejo los tenedores \n");
                semcomer.Release();
        }
        private void Recoger(int filosofo)
        {
                semcomer.WaitOne();
                estado[filosofo] = hambre;
                Console.WriteLine(nombre[filosofo] + " Tiene hambre \n");
                Comer(filosofo);
                Thread.Sleep(1000);
                semcomer.Release();
        }

        private void Comer(int filosofo)
        {
            if ((estado[(filosofo + 4) % NumFilosofos] != comer) && (estado[filosofo] == hambre && (estado[(filosofo + 1) % NumFilosofos] !=comer)))
            {
                estado[filosofo] = comer;
                Console.WriteLine(nombre[filosofo] + " Recogio tenedor izquierdo \n");
                Thread.Sleep(1000);
                Console.WriteLine(nombre[filosofo] + " Recogio tenedor derecho \n");
                Thread.Sleep(1000);
                Console.WriteLine(nombre[filosofo] + " Esta comiendo \n");               
            }
        }
        public void RecogerDejar(int filosofo)
        {
            while (true)
            {
                Thread.Sleep(1000);
                Recoger(filosofo);
                Thread.Sleep(1000);
                Dejar(filosofo);
            }
        }
    }
}
