using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToJump : MonoBehaviour
{
    public bool canJump;
    [SerializeField] private float jumpForce;
    private Animator anim;
    private Rigidbody rig;
    private Vector3 originPos;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        originPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            rig.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            anim.Play("Jump");
        }
    }
    public void Reset()
    {
        transform.position = originPos;
    }
}
