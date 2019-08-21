using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigCharacterController : MonoBehaviour {

    float damage = 10f;
    public float damageTaken = 26f;
    public float maxHealth = 100f;
    public float currentHealth;
    public bool isAlive;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentHealth <= 0)
        {
            isAlive = false;
            ScoreScript.scoreValue += 15;
            SoundManager.Play("PigDeath");
            Destroy(this.gameObject);
        }

    }

    public void TakeDamage(float amount)
    {
        if (currentHealth > 0)
        {
            //Below the pig will take damage from a weapon script
            currentHealth -= amount;
        }
        else
        {
            isAlive = false;
            ScoreScript.scoreValue += 15;
            Destroy(this.gameObject); //pig is dead
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //If the pig contacts the player, then the player will take damage.
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            currentHealth -= damageTaken;
            SoundManager.Play("DamageSound");
        }
    }
}
