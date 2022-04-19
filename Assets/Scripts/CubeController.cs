using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public ParticleSystem.MinMaxCurve moveTimeRange = new ParticleSystem.MinMaxCurve(1f, 3f);
    private float timeStamp;
    private float moveTime;
    private Vector3 originLocalPos;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        timeStamp = Time.time;
        originLocalPos = transform.localPosition;
        moveTime = moveTimeRange.Evaluate(Random.Range(0, 1f));
        yield return new WaitForSeconds(moveTime);
        if (FindObjectOfType<GamePlayState>()) FindObjectOfType<GamePlayState>().currentScore++;
    }
    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Slerp(originLocalPos, Vector3.zero, (Time.time - timeStamp) / moveTime);
    }
    public void Dispose()
    {
        Destroy(gameObject);
    }
}
