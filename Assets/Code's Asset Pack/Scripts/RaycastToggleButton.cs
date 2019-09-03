using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastToggleButton : MonoBehaviour {

    public KeyCode ButtonForRaycast = KeyCode.E;
    public float RaycastDistance = 6;
    public string Tag = "Button";

    public LayerMask LayerMaskForRaycast;

    private Transform _transformOrigin;

    private void Start()
    {
        _transformOrigin = GetComponentInChildren<Camera>().transform;
    }


    // Update is called once per frame
    void Update ()
    {
        if(Input.GetKeyDown(ButtonForRaycast))
        {
            RaycastHit hit;

            if(Physics.Raycast(_transformOrigin.position, _transformOrigin.forward, out hit, RaycastDistance, LayerMaskForRaycast))
            {
                Debug.DrawRay(_transformOrigin.position, _transformOrigin.forward*RaycastDistance, Color.red,1);            
                if(hit.collider.tag == Tag)
                {
                    hit.collider.gameObject.GetComponent<RaycastButtonToggle>().ToggleObject();
                }
            }

        }

    }
}
