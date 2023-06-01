using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    
    public Joystick joystick;

    public Animator animator;


    public float runSpeed = 40f;

    float horizontalMove = 0.0f;

    bool jump = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //horizontalMove = joystick.Horizontal * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        /*if (joystick.Vertical > 0.5f)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }*/
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        // Move our character

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>(), true);
            gameObject.layer = LayerMask.NameToLayer("IgnorePlayer");
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>(), false);
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

}
