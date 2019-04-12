using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [Header("Det antal liv dette object har")]
    public int HP = 3;

	// Update is called once per frame
	void ChangeHP(int amount)
    {
        HP += amount;


		
	}
}
