using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Husk et rigidbody, ellers virker det ikke. 
/// </summary>
public class OnTouch_ChangeHP : MonoBehaviour
{
    public enum Type {Self, Other}
    

    [Header("Hvis det man rører ved har dette tag, så ændrer vi HP")]
    public string Tag;
    [Header("Hvor meget ændring?")]
    public int Change = 1;
    [Header("Ændrer vi Health på os selv eller på det som vi rører ved?")]
    public Type WhatToChangeOn = Type.Self;



    private void OnTriggerEnter(Collider other)
    {
        Touch(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Touch(collision.gameObject);
    }

    void Touch(GameObject TouchedObject)
    {
        if(TouchedObject.tag == Tag)
        {
            if (WhatToChangeOn == Type.Self)
            {
                GetComponent<Health>().ChangeHP(Change);
            }
            else
            {
                TouchedObject.GetComponent<Health>().ChangeHP(Change);
            }
        }
    }
}
