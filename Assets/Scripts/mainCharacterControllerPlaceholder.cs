using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacterControllerPlaceholder : MonoBehaviour {

    public float walkSpeed = .1f;
    public float runSpeed = .3f;
    public float crouchSpeed = .05f;
    public float jumpHeight;
    public float speed = .1f;
    public float strafeSpeed = .3f;
    public float jumpForce = 40f;
    public float rotationSpeed = 1.5f;
    public bool isGrounded;
    public bool isCrouching;

    private float mouseInput;
    private HealthManager health;

    private Rigidbody playerRigidBody;
    CapsuleCollider colliderSize; //For now, I am assuming we are using a capsule collider

	// Use this for initialization
	void Start () {
        playerRigidBody = GetComponent<Rigidbody>();
        colliderSize = GetComponent<CapsuleCollider>();
        health = GetComponent<HealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    void FixedUpdate() {

        //Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isCrouching) //If player is already crouching
            {
                isCrouching = false;
                //colliderSize.height = 2; Change height to what the size of the player is
                //colliderSize.center = new Vector3(0, 1, 0) Change center to half player height
            }
            else
            {
                isCrouching = true;
                //colliderSize.height = 1; 
                //colliderSize.center = new Vector3(0, .5, 0);
                speed = crouchSpeed;
            }
        }

        //character movement, if player is dead movement is disabled (for now)
        if (health.isAlive)
        {
            // Rotates according to mouse input
            mouseInput = Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(0, mouseInput * rotationSpeed, 0));

            var z = Input.GetAxis("Vertical") * speed; //WS keys
            var x = Input.GetAxis("Horizontal") * strafeSpeed; //AD keys

            transform.Translate(0, 0, z); //translate forward and back
            transform.Translate(x, 0, 0); //translate left and right
        }

        //jumping with space
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            playerRigidBody.AddForce(0, jumpHeight, 0);
            isCrouching = false;
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
