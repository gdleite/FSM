using DesignPatterns;
using System;

namespace IA_Exercicio_03
{
    public class StateSleeping : State<Player>
    {
        public StateSleeping(Player parent) : base(parent) { }
        public override void Enter() { }
        public override void Exit() { }
        public override void FixedUpdate() { }
        public override void LateUpdate() { }
        public override void Update()
        {
            mParent.Sleep();
            if (mParent.IsDead())
            {
                Console.WriteLine("[Sleeping] Player died while sleeping");
                mParent.ChangeState(Constants.STATE_DEAD);
            }
            else if (mParent.Rested()){
                Console.WriteLine("[Sleeping] Player will start working");
                mParent.ChangeState(Constants.STATE_WORKING);
            }
        }
    }
}