using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameEndState : MonoBehaviour
{
    public GamePlayState gamePlayState;
    public UnityEngine.UI.Text score;
    private void OnEnable()
    {
        FindObjectOfType<CubeSpawner>().StopSpawn();
        score.text = gamePlayState.currentScore.ToString();
    }
    public void OnClickReset()
    {
        GetComponent<State>().ChangeState("GameStartState");
    }
}
