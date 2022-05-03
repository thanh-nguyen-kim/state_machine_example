using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : MonoBehaviour
{
    public UnityEngine.UI.Text score;
    public Transform player;
    public int currentScore = 0;
    private void OnEnable()
    {
        currentScore = 0;
        FindObjectOfType<CubeSpawner>().SpawnCube();
        FindObjectOfType<TapToJump>().canJump = true;
    }
    private void OnDisable()
    {
        FindObjectOfType<TapToJump>().canJump = false;
    }
    // Update is called once per frame
    void Update()
    {
        score.text = currentScore.ToString();
        if (player.position.y < currentScore - 1)
            GetComponent<State>().Next();
    }
}
