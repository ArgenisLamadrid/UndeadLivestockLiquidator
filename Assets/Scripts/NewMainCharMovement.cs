using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMainCharMovement : MonoBehaviour
{
    static Animator anim;           //HERE

    public float walkSpeed = .1f;
    public float runSpeed = .3f;
    public float crouchSpeed = .05f;
    public float jumpHeight;
    public float speed = .1f;
    public float strafeSpeed = .3f;
    public float jumpForce = 40f;
    public float rotationSpeed = 1.5f;
    public bool isGrounded;
    public bool isCrouching1;

    private float mouseInput1;
    private HealthManager health1;

    private Rigidbody playerRigidBody1;
    //CapsuleCollider colliderSize1; //For now, I am assuming we are using a capsule collider

    // Use this for initialization
    void Start()
    {
        anim = GetComponent < Animator>();    //HERE
        playerRigidBody1 = GetComponent<Rigidbody>();
        //colliderSize1 = GetComponent<CapsuleCollider>();
        health1 = GetComponent<HealthManager>();
        anim.SetBool("isRunning", false);
        anim.SetBool("isStrafingLeft", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {   
        isGrounded = true;
    }

    void FixedUpdate()
    {

        //Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isCrouching1) //If player is already crouching
            {
                isCrouching1 = false;
                //colliderSize.height = 2; Change height to what the size of the player is
                //colliderSize.center = new Vector3(0, 1, 0) Change center to half player height
            }
            else
            {
                isCrouching1 = true;
                //colliderSize.height = 1; 
                //colliderSize.center = new Vector3(0, .5, 0);
                speed = crouchSpeed;
            }
        }

        //character movement, if player is dead movement is disabled (for now)
        if (health1.isAlive)
        {
            // Rotates according to mouse input
            mouseInput1 = Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(0, mouseInput1 * rotationSpeed, 0));

            float z = Input.GetAxis("Vertical") * speed; //WS keys
            float x = Input.GetAxis("Horizontal") * strafeSpeed; //AD keys

            transform.Translate(0, 0, z); //translate forward and back
            transform.Translate(x, 0, 0); //translate left and right

            if (z != 0)
            {
                anim.SetBool("isRunning", true);
                anim.SetBool("isIdle", false);
                anim.SetBool("isStrafingLeft", false);
            }
            else if (x != 0)
            {
                anim.SetBool("isStrafingLeft", true);
                anim.SetBool("isIdle", false);
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isStrafingLeft", false);
                anim.SetBool("isIdle", true);
            }
        }

        //jumping with space
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            anim.SetTrigger("isJumping");   //HERE
            playerRigidBody1.AddForce(0, jumpForce, 0);
            isCrouching1 = false;
            isGrounded = false;
        }

        //running, cannot run in the air
        else if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded == true)
        {
            speed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkSpeed;
        }
    }
}
