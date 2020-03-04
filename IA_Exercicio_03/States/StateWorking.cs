using DesignPatterns;
using System;

namespace IA_Exercicio_03
{
    public class StateWorking : State<Player>
    {
        public StateWorking(Player parent) : base(parent) { }
        public override void Enter() { }
        public override void Exit() { }
        public override void FixedUpdate() { }
        public override void LateUpdate() { }
        public override void Update()
        {
            mParent.Work();
            if (mParent.IsDead())
            {
                Console.WriteLine("[Working] Player died from working");
                mParent.ChangeState(Constants.STATE_DEAD);
            }
            else if (mParent.NeedEating())
            {
                Console.WriteLine("[Working] Player will start eating");
                mParent.ChangeState(Constants.STATE_EATING);
            }
            else if (mParent.NeedSleeping())
            {
                Console.WriteLine("[Working] Player will start Sleeping");
                mParent.ChangeState(Constants.STATE_SLEEPING);
            }
        }
    }
}