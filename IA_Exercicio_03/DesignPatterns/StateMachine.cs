using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class StateMachine<T>
    {
        protected T mParent;
        private Dictionary<string, State<T>> mStateDictionary;
        protected State<T> mCurrentState;
        public State<T> currentState
        {
            get { return mCurrentState; }
        }
        protected State<T> mGlobalState;
        public State<T> GlobalState
        {
            get { return mGlobalState; }
        }

        public StateMachine(T parent)
        {
            mParent = parent;
            mStateDictionary = new Dictionary<string, State<T>>();
            mCurrentState = null;
            mGlobalState = null;
        }
        public void Update()
        {
            mGlobalState?.Update();
            mCurrentState?.Update();
        }
        public void FixedUpdate()
        {
            mGlobalState?.FixedUpdate();
            mCurrentState?.FixedUpdate();
        }
        public void LateUpdate()
        {
            mGlobalState?.LateUpdate();
            mCurrentState?.LateUpdate();
        }
        public bool IsInState(string stateName)
        {
            if (!mStateDictionary.ContainsKey(stateName))
            {
                Console.WriteLine($"IsInState({stateName}): state not found.");
                return false;
            }
            return mCurrentState == mStateDictionary[stateName];
        }
        public bool IsInGlobal(string stateName)
        {
            if (!mStateDictionary.ContainsKey(stateName))
            {
                Console.WriteLine($"IsInGlobalState({stateName}): state not found.");
                return false;
            }
            return mCurrentState == mStateDictionary[stateName];
        }
        public void ChangeState(string stateName)
        {
            if (!mStateDictionary.ContainsKey(stateName))
            {
                Console.WriteLine($"ChangeState({stateName}): state not found.");
                return;
            }
            if (mStateDictionary[stateName] == mCurrentState)
            {
                Console.WriteLine($"ChangeState({stateName}): new state is already the current state.");
                return;
            }
            mCurrentState?.Exit();

            mCurrentState = mStateDictionary[stateName];
            mCurrentState.Enter();
        }
        public void ChangeGlobalState(string stateName)
        {
            if (!mStateDictionary.ContainsKey(stateName)){
                Console.WriteLine($"ChangeGlobalState({stateName}): state not found.");
                return;
            }
            if (mStateDictionary[stateName] == mCurrentState)
            {
                Console.WriteLine($"ChangeState({stateName}): new state is already the global state.");
                return;
            }
            mGlobalState?.Exit();

            mGlobalState = mStateDictionary[stateName];
            mGlobalState.Enter();
        }
        public void ClearCurrentState()
        {
            mCurrentState?.Exit();
            mCurrentState = null;
        }
        public void ClearGlobalState()
        {
            mGlobalState?.Exit();
            mGlobalState = null;
        }
        public bool AddState(string stateName, State<T> state, bool overwriteIfExists = true)
        {
            if (state == null)
            {
                Console.WriteLine($"AddState({stateName}, {state}, {overwriteIfExists}): state is null.");
            }

            if (overwriteIfExists)
            {
                mStateDictionary[stateName] = state;
            }
            else
            {
                try
                {
                    mStateDictionary.Add(stateName, state);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"AddState({stateName}, {state}, {overwriteIfExists}): error trying to add new state.");
                    return false;
                }
            }
            return true;
        }
        public bool RemoveState(string stateName, bool forceIfInUse = false)
        {
            if (mStateDictionary.ContainsKey(stateName))
            {
                if (mCurrentState == mStateDictionary[stateName])
                {
                    if (forceIfInUse)
                    {
                        Console.WriteLine($"RemoveState({stateName}): removing current state.");

                        ClearCurrentState();
                        return mStateDictionary.Remove(stateName);
                    }
                    else
                    {
                        Console.WriteLine($"RemoveState({stateName}): trying to remove current state.");
                        return false;
                    }
                }
                if (mGlobalState == mStateDictionary[stateName])
                {
                    if (forceIfInUse) { }
                    else { }
                }
                return mStateDictionary.Remove(stateName);
            }
            Console.WriteLine($"RemoveState({stateName}): state not found.");
            return false;
        }

    }
}