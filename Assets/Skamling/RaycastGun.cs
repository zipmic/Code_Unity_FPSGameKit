using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaycastGun : MonoBehaviour {

    public GameObject PurpleCube;
    public float RayCastDistance = 20;
    public LayerMask LayerMaskForRaycast;
    public UnityEngine.UI.Text AmountOfBoxes;

    public Color[] ColorsYaaay;

    private float _counter;
    private int _boxcount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetMouseButton(0) && _counter > 0.25f)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, RayCastDistance, LayerMaskForRaycast))
            {
              //  Debug.DrawRay(_transformOrigin.position, _transformOrigin.forward * RaycastDistance, Color.red, 1);
                if(hit.collider != null)
                {
                    GameObject tmp = Instantiate(PurpleCube) as GameObject;
                    tmp.transform.position = hit.point;
                    tmp.GetComponent<MeshRenderer>().material.color = ColorsYaaay[Random.Range(0, ColorsYaaay.Length)];
                    tmp.transform.localScale *= Random.Range(0.3f, 2f);
                    _boxcount++;
                    AmountOfBoxes.text = "Amount of boxes: " + _boxcount;
                    tmp.transform.forward = hit.normal;
                }
            }

        }

        _counter += Time.deltaTime;
    }
}
