using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchWall : MonoBehaviour {

	// Use this for initialization
	void Start () {

   

        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.Sleep();
            rb.sleepThreshold = 50f;
           
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
