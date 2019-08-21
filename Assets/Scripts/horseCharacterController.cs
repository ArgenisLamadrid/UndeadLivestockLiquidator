using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horseCharacterController : MonoBehaviour {

    float damage = 20f;
    public float maxHealth = 60f;
    public float currentHealth;
    public bool isAlive;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(float amount)
    {
        if(currentHealth > 0)
        {
            //Below the horse will take damage from a weapon script
            currentHealth -= amount;
        }
        else
        {
            isAlive = false;
            ScoreScript.scoreValue += 20;
            Destroy(this.gameObject); //horse is dead
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //If the horse contacts the player, then the player will take damage
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
        }
    }
}
