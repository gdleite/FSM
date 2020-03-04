using DesignPatterns;
using System;

namespace IA_Exercicio_03
{
    public class StateDead : State<Player> {
        public StateDead(Player parent) : base(parent) { }
        public override void Enter() { }
        public override void Exit() { }
        public override void FixedUpdate() { }
        public override void LateUpdate() { }
        public override void Update()
        {
            Console.WriteLine("[Dead] Player is dead");
        }
    }
}