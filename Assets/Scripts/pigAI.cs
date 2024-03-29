﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigAI : MonoBehaviour {


    private Transform player;
    private bool isGrounded;
    private int JumpChance;
    private Rigidbody pigRigidBody;

    public float rotationSpeed = 6f;
    public float jumpForce = 100f;
    public float speed = 6f;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pigRigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Look at player
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), rotationSpeed * Time.deltaTime);

        // If on the ground, jump at random intervals
        if (isGrounded)
        {

            JumpChance = Random.Range(1, 101);
            if (JumpChance == 5)
            {

                pigRigidBody.AddForce(0, jumpForce, 0);
                isGrounded = false;
            }
        }
        // Move to player
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
