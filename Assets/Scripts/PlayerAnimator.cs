using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;

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
        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("W"))
        {
            animator.SetBool("IsSkating", true);

            {
                if (!Input.GetKeyDown("W"))
                    animator.SetBool("IsMoving", false);
            }


            if (Input.GetKeyDown(KeyCode.Mouse0));

            animator.SetBool("IsMoving", true);

            if (!Input.GetKeyDown(KeyCode.Mouse0));

            animator.SetBool("IsShooting", false);


        }}
}
