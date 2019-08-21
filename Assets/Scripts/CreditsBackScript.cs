using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsBackScript : MonoBehaviour {

    public Button backButton;
    public string Menu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void backedUp()
    {
        SceneManager.LoadScene(Menu);
    }
}
