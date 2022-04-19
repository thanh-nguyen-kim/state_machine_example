/// <summary>
/// 
/// Base class for States to be used as children of StateMachines.
/// 
/// </summary>

using UnityEngine;
using System.Collections;
    public class State : MonoBehaviour 
    {
        //Public Properties:

        /// <summary>
        /// Gets or sets the state machine.
        /// </summary>
        public StateMachine StateMachine
        {
            get
            {
                if (_stateMachine == null)
                {
                    _stateMachine = transform.parent.GetComponent<StateMachine>();
                    if (_stateMachine == null)
                    {
                        Debug.LogError("States must be the child of a StateMachine to operate.");
                        return null;
                    }
                }

                return _stateMachine;
            }
        }

        //Private Variables:
        StateMachine _stateMachine;

        //Public Methods
        /// <summary>
        /// Changes the state.
        /// </summary>
        public void ChangeState(int childIndex)
        {
            StateMachine.ChangeState(childIndex);
        }

        /// <summary>
        /// Changes the state.
        /// </summary>
        public void ChangeState (GameObject state)
        {
            StateMachine.ChangeState (state.name);
        }

        /// <summary>
        /// Changes the state.
        /// </summary>
        public void ChangeState (string state)
        {
            if (StateMachine == null) return;
            StateMachine.ChangeState (state);
        }

        /// <summary>
        /// Change to the next state if possible.
        /// </summary>
        public GameObject Next ()
        {
            return StateMachine.Next ();
        }

        /// <summary>
        /// Change to the previous state if possible.
        /// </summary>
        public GameObject Previous ()
        {
            return StateMachine.Previous ();
        }

        /// <summary>
        /// Exit the current state.
        /// </summary>
        public void Exit ()
        {
            StateMachine.Exit ();
        }
}