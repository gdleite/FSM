using System;
using System.Threading;

namespace IA_Exercicio_03
{

    // AUTOR: GABRIEL DANTAS LEITE
    // TIA: 31719589
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FSM - Gabriel Leite\nTIA: 31719589\n");
            Player player = new Player();
            while (!player.IsPlayerDead())
            {
                Thread.Sleep(1000);
                player.Update();
            }
        }
    }
}
