using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horseAI : MonoBehaviour {

    private Transform player;
    public float rotationSpeed = 6f;
    public float speed = 6f;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {

        // Look at player
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), rotationSpeed * Time.deltaTime);

        // Move to player
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
