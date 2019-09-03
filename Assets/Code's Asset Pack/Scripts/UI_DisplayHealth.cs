using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DisplayHealth : MonoBehaviour {

    public Health HealthToDisplay;
    private Text _thisText;

	// Use this for initialization
	void Start () {

        _thisText = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        _thisText.text = "Health: " + HealthToDisplay.HP;
		
	}
}
