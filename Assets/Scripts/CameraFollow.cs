using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 1;
    public Transform target;
    private Vector3 delta;
    // Start is called before the first frame update
    void Start()
    {
        delta = transform.position - target.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position + delta, Time.deltaTime * Mathf.Max(followSpeed, Vector3.Distance(transform.position, target.position + delta)));
    }
}
