using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duckCharacterController : MonoBehaviour
{

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
            ScoreScript.scoreValue += 20;
            SoundManager.Play("DuckDeath");
            Destroy(this.gameObject);
        }

    }

    public void TakeDamage(float amount)
    {
        if (currentHealth > 0)
        {
            //Below the duck will take damage from a weapon script
            currentHealth -= amount;
        }
        else
        {
            isAlive = false;
            ScoreScript.scoreValue += 20;
            Destroy(this.gameObject); //duck is dead
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //If the duck contacts the player, then the player will take damage.
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

