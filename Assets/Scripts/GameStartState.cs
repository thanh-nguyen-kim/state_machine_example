using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartState : MonoBehaviour
{
    private void OnEnable()
    {
        FindObjectOfType<CubeSpawner>().Reset();
        FindObjectOfType<TapToJump>().Reset();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<State>().Next();
        }
    }
}
