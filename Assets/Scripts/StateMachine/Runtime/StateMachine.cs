/// <summary>
/// 
/// StateMachine main class.
/// 
/// </summary>

// Used to disable the lack of usage of the exception in a try/catch:
#pragma warning disable 168

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
public class StateMachine : MonoBehaviour
{
    //Public Variables:
    public GameObject defaultState;
    public GameObject currentState;

    private void Start()
    {
        Initialize();
        StartMachine();
    }

    //Public Methods:
    /// <summary>
    /// Change to the next state if possible.
    /// </summary>
    public GameObject Next()
    {
        if (currentState == null) return ChangeState(0);
        int currentIndex = currentState.transform.GetSiblingIndex();
        if (currentIndex == transform.childCount - 1)
        {
            return currentState;
        }
        else
        {
            return ChangeState(++currentIndex);
        }
    }
    /// <summary>
    /// Change to the previous state if possible.
    /// </summary>
    public GameObject Previous()
    {
        if (currentState == null) return ChangeState(0);
        int currentIndex = currentState.transform.GetSiblingIndex();
        if (currentIndex == 0)
        {
            return currentState;
        }
        else
        {
            return ChangeState(--currentIndex);
        }
    }
    /// <summary>
    /// Exit the current state.
    /// </summary>
    public void Exit()
    {
        if (currentState == null) return;
        Log("(-) " + name + " EXITED state: " + currentState.name);
        int currentIndex = currentState.transform.GetSiblingIndex();

        currentState.SetActive(false);
        currentState = null;
    }
    /// <summary>
    /// Changes the state.
    /// </summary>
    public GameObject ChangeState(int childIndex)
    {
        if (childIndex > transform.childCount - 1)
        {
            Log("Index is greater than the amount of states in the StateMachine \"" + gameObject.name + "\" please verify the index you are trying to change to.");
            return null;
        }
        return ChangeState(transform.GetChild(childIndex).gameObject);
    }
    /// <summary>
    /// Changes the state.
    /// </summary>
    public GameObject ChangeState(GameObject state)
    {

        if (state.transform.parent != transform)
        {
            Log("State \"" + state.name + "\" is not a child of \"" + name + "\" StateMachine state change canceled.");
            return null;
        }

        Exit();
        Enter(state);

        return currentState;
    }
    /// <summary>
    /// Changes the state.
    /// </summary>
    public GameObject ChangeState(string state)
    {
        Transform found = transform.Find(state);
        if (!found)
        {
            Log("\"" + name + "\" does not contain a state by the name of \"" + state + "\" please verify the name of the state you are trying to reach.");
            return null;
        }

        return ChangeState(found.gameObject);
    }
    /// <summary>
    /// Internally used within the framework to auto start the state machine.
    /// </summary>
    public void Initialize()
    {
        //turn off all states:
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    /// <summary>
    /// Internally used within the framework to auto start the state machine.
    /// </summary>
    public void StartMachine()
    {
        //start the machine:
        if (Application.isPlaying && defaultState != null) ChangeState(defaultState.name);
    }
    //Private Methods:
    void Enter(GameObject state)
    {
        currentState = state;
        int index = currentState.transform.GetSiblingIndex();

        Log("(+) " + name + " ENTERED state: " + state.name);
        currentState.SetActive(true);
    }
    void Log(string message)
    {
        Debug.Log(message, gameObject);
    }
}