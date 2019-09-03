using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnableGameObjectsOnAwake : MonoBehaviour 
{

    public GameObject[] GameObjectsToEnableOnAwake;

	// Use this for initialization
	void Awake () {

        foreach(GameObject g in GameObjectsToEnableOnAwake)
        {
            g.gameObject.SetActive(true);
        }

    }

}
