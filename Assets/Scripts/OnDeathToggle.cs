using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class OnDeathToggle : MonoBehaviour 
{

    [Header("Objekter der skal toggles når man dør")]
    public List<GameObject> ObjectsToToggle = new List<GameObject>();

    private Health _thisObjectsHealth;
    

    private void Awake()
    {
        _thisObjectsHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update ()
    {
		if(_thisObjectsHealth.HP <= 0)
        {
            foreach(GameObject g in ObjectsToToggle)
            {
                if(g != null)
                {
                    g.SetActive(!g.activeSelf);
                }
            }

            enabled = false;
        }
    }
}
