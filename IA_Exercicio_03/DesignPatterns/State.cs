namespace DesignPatterns
{
    public abstract class State<T>
    {
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
        public abstract void FixedUpdate();
        public abstract void LateUpdate();

        protected T mParent;

        public State(T parent)
        {
            mParent = parent;
        }
    }
}