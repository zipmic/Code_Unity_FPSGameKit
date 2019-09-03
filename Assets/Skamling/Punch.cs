using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {

    public float Distance = 3;
    public LayerMask Mask;
    public string tag = "punchable";

    public float Force = 100;

// Use this for initialization
    void Start () 
    {
		
	}

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            float smallModifier = 0.02f;

            PunchIt(Vector3.zero);
            PunchIt(Vector3.right* smallModifier);
            PunchIt(Vector3.left * smallModifier);
            PunchIt(Vector3.up * smallModifier);
            PunchIt(Vector3.down * smallModifier);

            PunchIt(Vector3.right * smallModifier*2);
            PunchIt(Vector3.left * smallModifier*2);
            PunchIt(Vector3.up * smallModifier*2);
            PunchIt(Vector3.down * smallModifier*2);
        }
    }

    void PunchIt(Vector3 variation)
    {
        RaycastHit hit;

      
            if (Physics.Raycast(transform.position, transform.forward+variation, out hit, Distance, Mask))
            {

                if (hit.collider.tag == tag)
                {

                    hit.collider.GetComponent<Rigidbody>().AddForce(Force * transform.forward, ForceMode.Impulse);
                }
            }
        

    }
}
