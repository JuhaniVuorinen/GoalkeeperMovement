using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.0f;
    public float smoothTime = 0.1f;
    public float accelerationTime = 2.0f;

    public Animator animator;
    private Rigidbody myRB;
    private Vector3 currentVelocity = Vector3.zero;
    private Vector3 currentSpeed = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized * speed;

        myRB.AddForce(move, ForceMode.Force);

        move = transform.TransformDirection(move);


        currentSpeed = Vector3.SmoothDamp(currentSpeed, move, ref currentVelocity, accelerationTime);

        myRB.velocity = new Vector3(currentSpeed.x, myRB.velocity.y, currentSpeed.z);

        if(move != Vector3.zero)
        {
            Debug.Log("k" + move); 
                animator.SetBool("IsSkating", true);
        }
        if (move.magnitude < 1)
        {
            animator.SetBool("IsSkating", false);
        }
        Debug.Log("Movement:" + move);

        Debug.Log("currentSpeed:" + currentSpeed);
    }
}
