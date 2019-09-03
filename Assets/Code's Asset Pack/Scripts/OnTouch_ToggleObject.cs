using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouch_ToggleObject : MonoBehaviour
{

    public enum Type { Self, Other }
    public enum State { Toggle, Enable, Disable }

    [Header("Hvis jeg rører ved dette tag, så skifter vi dens state")]
    public string Tag;

    [Header("Hvad skal den ændres til?")]
    public State ChangeToState = State.Enable;

    [Header("På os selv eller på den som rører os?")]
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
        if (TouchedObject.tag == Tag)
        {
            if (WhatToChangeOn == Type.Self)
            {
                if(ChangeToState == State.Enable)
                {
                    gameObject.SetActive(true);
                }
                else if(ChangeToState == State.Disable)
                {
                    gameObject.SetActive(false);
                }
                else if(ChangeToState == State.Toggle)
                {
                    gameObject.SetActive(!gameObject.activeSelf);
                }
            }
            else
            {
                if (ChangeToState == State.Enable)
                {
                    TouchedObject.gameObject.SetActive(true);
                }
                else if (ChangeToState == State.Disable)
                {
                    TouchedObject.gameObject.SetActive(false);
                }
                else if (ChangeToState == State.Toggle)
                {
                    TouchedObject.gameObject.SetActive(!TouchedObject.gameObject.activeSelf);
                }

            }
        }
    }


}
