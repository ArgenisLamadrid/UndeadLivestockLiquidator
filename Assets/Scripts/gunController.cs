using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour {


    public GameObject bulletSpawn;
    public GameObject bullet;
    public float bulletSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("mouse 0"))
        {
            // Spawn Bullet
            GameObject spawnedBullet;
            spawnedBullet = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;
            SoundManager.Play("ShootSound");


            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = spawnedBullet.GetComponent<Rigidbody>();

            Temporary_RigidBody.AddForce(transform.forward * bulletSpeed);
            Destroy(spawnedBullet, 1.8f);
        }
    }
}
