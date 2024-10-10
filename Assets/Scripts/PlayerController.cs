using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxPower = 10.0f;
    public float powerChargeSpeed = 5.0f;
    public float speed = 3.0f;
    public float accelerationTime = 0.3f;
    public GameObject PuckPrefab;
    public float puckHeight = 0.5f;
    public float puckDistance = 1.5f;
    public float PlayerSpeed = 5.0f;

    private float currentPower = 0f;
    private bool isCharging = false;
    private bool puckShot = false;
    private bool IsHitting = true;
    private bool IsMoving = true;

    public Animator PlayerAnim;
    private Rigidbody myRB;
    private Vector3 moveInput;
    private Vector3 currentVelocity = Vector3.zero;
    private GameObject currentPuck;

    void Start()
    {
        
        PlayerAnim = GetComponent < Animator > ();       
        myRB = GetComponent<Rigidbody>();
        SpawnPuck();
    }

    void Update()
    {
        HandleMovement();
        HandlePuckShooting();
        HandlePuckRespawn();
       
        
       
        



            
        


    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        
        

        Vector3 targetDirection = (transform.right * moveX) + (transform.forward * moveZ);
        targetDirection = targetDirection.normalized * speed;

        if (targetDirection !=Vector3.zero)
        {
            PlayerAnim.SetBool("IsMoving", true);
        }

       else
        {
            PlayerAnim.SetBool("IsMoving", false);
        }
        moveInput = Vector3.SmoothDamp(moveInput, targetDirection, ref currentVelocity, accelerationTime);
        myRB.velocity = new Vector3(moveInput.x, myRB.velocity.y, moveInput.z);

        

        if (currentPuck != null && !puckShot)
        {
            currentPuck.transform.position = transform.position + transform.forward * puckDistance + new Vector3(0, puckHeight, 0);
        }
    }

    private void SpawnPuck()
    {
        if (currentPuck == null)
        {
            currentPuck = Instantiate(PuckPrefab, transform.position + transform.forward * puckDistance + new Vector3(0, puckHeight, 0), Quaternion.identity);
            currentPuck.transform.SetParent(transform);
        }
    }

    private void RespawnPuck()
    {
        if (puckShot)
        {
            Destroy(currentPuck);
            currentPuck = Instantiate(PuckPrefab, transform.position + transform.forward * puckDistance + new Vector3(0, puckHeight, 0), Quaternion.identity);
            currentPuck.transform.SetParent(transform);
            puckShot = false;
        }
    }

    private void HandlePuckShooting()
    {
        if (currentPuck != null && !puckShot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isCharging = true;
                currentPower = 0f;
            }

            if (Input.GetMouseButtonDown(0))
            {
                PlayerAnim.SetBool("IsHitting", true);
            }

            else
            {
                PlayerAnim.SetBool("IsHitting", false);
            }

            if (isCharging && Input.GetMouseButton(0))
            {
                currentPower += powerChargeSpeed * Time.deltaTime;
                currentPower = Mathf.Clamp(currentPower, 0, maxPower);
            }

            if (Input.GetMouseButtonUp(0))
            {
                isCharging = false;
                puckShot = true;
                currentPuck.transform.SetParent(null);
                ShootPuck();
            }
        }
    }

    private void ShootPuck()
    {
        Rigidbody puckRB = currentPuck.GetComponent<Rigidbody>();
        puckRB.isKinematic = false;

        Vector3 shootDirection = transform.forward;
        puckRB.AddForce(shootDirection * currentPower * 5f, ForceMode.Impulse);
        puckRB.AddForce(Vector3.up * 1.5f, ForceMode.Impulse);

        Debug.Log($"Puck shot with power: {currentPower} towards: {shootDirection}");
        currentPower = 0f;
    }

    private void HandlePuckRespawn()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RespawnPuck();
        }
    } 
    

    

    
    
}
    

     
