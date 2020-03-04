using DesignPatterns;
using System;

namespace IA_Exercicio_03
{
    public class StateEating : State<Player>
    {
        public StateEating(Player parent) : base(parent) { }
        public override void Enter() { }
        public override void Exit() { }
        public override void FixedUpdate() { }
        public override void LateUpdate() { }
        public override void Update()
        {
            mParent.Eat();
            if (mParent.IsDead())
            {
                Console.WriteLine("[Eating] Player died while eating");
                mParent.ChangeState(Constants.STATE_DEAD);
            }
            else if (mParent.NeedRelief())
            {
                Console.WriteLine("[Eating] Player will start relieving");
                mParent.ChangeState(Constants.STATE_RELIEVING);
            }
            else if (mParent.Satiated())
            {
                Console.WriteLine("[Eating] Player is satiated and will go back to work");
                mParent.ChangeState(Constants.STATE_WORKING);

            }
        }
    }
}