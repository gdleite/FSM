using DesignPatterns;
using System;

namespace IA_Exercicio_03
{
    public class StateRelieving : State<Player>
    {
        public StateRelieving(Player parent) : base(parent) { }
        public override void Enter() { }
        public override void Exit() { }
        public override void FixedUpdate() { }
        public override void LateUpdate() { }
        public override void Update()
        {
            mParent.Relief();
            if (mParent.IsDead())
            {
                Console.WriteLine("[Relieving] Player died while relieving");
                mParent.ChangeState(Constants.STATE_DEAD);
            }
            else if (mParent.Relieved())
            {
                Console.WriteLine("[Relieving] Player is relieved and will start working");
                mParent.ChangeState(Constants.STATE_WORKING);
            }
        }
    }
}