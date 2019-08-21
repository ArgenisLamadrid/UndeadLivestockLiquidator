using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour {

    Text health;
    public static float playerHealth = 100;

	// Use this for initialization
	void Start () {
        health = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        health.text = "HP: " + playerHealth;
	}
}
