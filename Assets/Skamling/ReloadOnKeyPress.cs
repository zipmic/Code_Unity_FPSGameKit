using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadOnKeyPress : MonoBehaviour 
{
    public KeyCode ActionKey;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(ActionKey))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
