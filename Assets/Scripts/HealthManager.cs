using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public float maxHealth = 100f;
    public float playerHealth;
    public bool isAlive = true;
    public float invincibilityLength = 1f;
    private float invincibilityCounter;
    public Renderer playerRenderer;
    private float flashCounter;
    public float flashLength = 0.1f;

    public GameObject youDiedText, backToMenu;

    // Use this for initialization
    void Start () {

        // Set menu to not show
        youDiedText.SetActive(false);
        backToMenu.SetActive(false);

        playerHealth = maxHealth;
        // Hide cursor on game start
        Cursor.lockState = CursorLockMode.Confined; 
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void TakeDamage(float amount)
    {
        if (playerHealth > 0 && invincibilityCounter <= 0)
        {
            playerHealth -= amount;
            HealthView.playerHealth = playerHealth;

            //After taking some damage, the player will briefly be invincible
            invincibilityCounter = invincibilityLength;

            //Disabling the render to setup for a 'flashing' effect when hit
            playerRenderer.enabled = false;
            flashCounter = flashLength;
        }
        else if(playerHealth <= 0)
        {   
            //Show Menu 
            youDiedText.SetActive(true);
            backToMenu.SetActive(true);
            // Release cursor, kill player
            Cursor.lockState = CursorLockMode.None;
            isAlive = false;
            SoundManager.Play("CharacterDeath");

            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    void FixedUpdate()
    {
        //Invinicibility when hit by an enemy for a brief period
        if (invincibilityCounter > 0)
        {
            //Counting down invincibility time
            invincibilityCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;

            //Below sets up the flashing effect
            if(flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashLength;
            }

            if(invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }
        }
    }

}
