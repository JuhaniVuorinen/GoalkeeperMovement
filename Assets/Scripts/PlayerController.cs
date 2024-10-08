using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private CharacterController characterController;
    public Animator animator;
    private Rigidbody myRB;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        myRB = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * speed * Time.deltaTime);

        if(move != Vector3.zero)
        {
            Debug.Log("k" + move); 
                animator.SetBool("IsSkating", true);
        }
        if (move.magnitude < 1)
        {
            animator.SetBool("IsSkating", false);
        }
    }
}
