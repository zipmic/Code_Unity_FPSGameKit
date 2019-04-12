using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [Header("Det antal liv dette object har")]
    public int HP = 3;

    [Header("Max antal liv man kan få?")]
    public int MaxHP = 150;

    [Header("Hvor lang tid skal der gør før at man kan tage skade igen?")]
    public float InvincibleTime = 0.1f;

    private bool _invincible = false;
    private float _invincibleCounter;

	// Update is called once per frame
	public void ChangeHP(int amount)
    {
        if (!_invincible)
        {
            HP += amount;
            _invincible = true;
        }

        if(HP < 0)
        {
            HP = 0;
        }

        if(HP > MaxHP)
        {
            HP = MaxHP;
        }

    }

    private void Update()
    {
        if(_invincible)
        {
            _invincibleCounter += Time.deltaTime;

            if(_invincibleCounter >= InvincibleTime)
            {
                _invincibleCounter = 0;
                _invincible = false;
            }
        }
    }
}
