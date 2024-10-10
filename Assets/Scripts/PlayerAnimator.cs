using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator PlayerAnim;
    public bool IsHitting;
    public bool IsMoving;


    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }


    // Start is called before the first frame update
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.W)) Input.GetKeyDown(KeyCode.S);
        {
            IsMoving = true;
        }

        if (Input.GetKeyUp(KeyCode.W)) Input.GetKeyUp(KeyCode.S);
        {
            IsMoving = false;
        }



        if (Input.GetMouseButtonDown(1))
        {
            IsHitting = true;

        }

        if (Input.GetMouseButtonUp(1))
        {
            IsHitting = false;
        }

        

            





    }
}

