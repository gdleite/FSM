using System;
using DesignPatterns;

namespace IA_Exercicio_03 { 
    public class Player
    {
        StateMachine<Player> mFSM;
        private int hpMeter = Constants.MAX_HP;
        private int sleepMeter = Constants.MAX_SLEEP;
        private int reliefMeter = Constants.MAX_RELIEF;
        private int hungerMeter = Constants.MAX_HUNGER;  

        public Player()
        {
            mFSM = new StateMachine<Player>(this);
            mFSM.AddState(Constants.STATE_SLEEPING, new StateSleeping(this));
            mFSM.AddState(Constants.STATE_WORKING, new StateWorking(this));
            mFSM.AddState(Constants.STATE_DEAD, new StateDead(this));
            mFSM.AddState(Constants.STATE_EATING, new StateEating(this));
            mFSM.AddState(Constants.STATE_RELIEVING, new StateRelieving(this));
            ChangeState(Constants.STATE_SLEEPING);
        }

        internal bool Rested()
        {
            return sleepMeter == Constants.MAX_SLEEP;
        }

        internal bool Relieved()
        {
            return reliefMeter == Constants.MAX_RELIEF;
        }

        internal bool Satiated()
        {
            return hungerMeter == Constants.MAX_HUNGER;
        }

        internal bool IsDead()
        {
            return hpMeter == 0;
        }
        internal bool NeedRelief()
        {
            return reliefMeter == 0;
        }
        internal void Relief()
        {
            Console.WriteLine("Player is Relieving\n");
            if (reliefMeter < Constants.MAX_RELIEF) reliefMeter++;
            if (hpMeter > 0) hpMeter--;
            if (sleepMeter > 0) sleepMeter--;
        }
        internal void Sleep()
        {
            Console.WriteLine("Player is Sleeping\n");
            if (sleepMeter < Constants.MAX_SLEEP) sleepMeter++;
            if (hpMeter > 0) hpMeter--;
        }
        internal void Eat()
        {
            Console.WriteLine("Player is Eating\n");
            if (hungerMeter < Constants.MAX_HUNGER) hungerMeter++;
            if (reliefMeter > 0) reliefMeter--; 
            if (hpMeter > 0) hpMeter--;
            if (sleepMeter > 0) sleepMeter--;
        }
        internal void Work()
        {
            Console.WriteLine("Player is Working\n");
            if (sleepMeter > 0) sleepMeter--;
            if (hungerMeter > 0) hungerMeter--;
            if (hpMeter > 0) hpMeter--;
        }
        internal bool NeedEating()
        {
            return hungerMeter == 0;
        }
        internal bool NeedSleeping()
        {
            return sleepMeter == 0;
        }

        public void Update()
        {
            printMeters();
            mFSM.Update();
        }
        public void printMeters()
        {
            Console.WriteLine($"Need Eating Meter:\t{hungerMeter}/{Constants.MAX_HUNGER}\n" +
                $"Need Relief Meter:\t{reliefMeter}/{Constants.MAX_RELIEF}\n" +
                $"Need Sleeping Meter:\t{sleepMeter}/{Constants.MAX_SLEEP}\n" +
                $"HP Meter:\t\t{hpMeter}/{Constants.MAX_HP}\n");
        }

        public void ChangeState(string state)
        {
            mFSM.ChangeState(state);
        }

        public bool IsPlayerDead()
        {
           return mFSM.IsInState(Constants.STATE_DEAD);
        }
    }
}
