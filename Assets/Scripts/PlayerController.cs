using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.0f;
    public float smoothTime = 0.1f;
    public float accelerationTime = 2.0f;
    public GameObject Puck;
    public float shootForce = 10.0f;

    public Animator animator;
    private Rigidbody myRB;
    private Vector3 currentVelocity = Vector3.zero;
    private Vector3 currentSpeed = Vector3.zero;
    private GameObject currentPuck;
    
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame

    private void Update()
    {
        handleMovement();
        handlePuckShooting();
    }
    private void handleMovement()
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
    private void handlePuckShooting()
    {
        if (currentPuck == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentPuck = Instantiate(Puck, transform.position + new Vector3(1, -1, 0), Quaternion.identity);
                currentPuck.transform.SetParent(transform);
                
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentPuck.transform.SetParent(null);
                Rigidbody puckRB = currentPuck.GetComponent<Rigidbody>();

                puckRB.AddForce(transform.forward * shootForce, ForceMode.Impulse);
                Debug.Log("puckshot" + currentPuck.transform.position + "with force" + transform.forward + shootForce);
                currentPuck = null;
            }
        }
    }
}
