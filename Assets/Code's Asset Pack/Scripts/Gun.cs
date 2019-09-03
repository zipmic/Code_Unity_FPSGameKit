using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject Bullet;
    public GameObject SpawnPoint;
    public float IntervalPerBullet = 0.5f;

    public enum ShootButton { Mouse, Keyboard};
    public ShootButton ShootButtonType;

    [Header("Hvis du har valgt Keyboard, så vælg knap")]
    public KeyCode ActionButton = KeyCode.E;

    private float intervalCounter = 0;

    // Use this for initialization
    void Start ()
    {
        intervalCounter = IntervalPerBullet;
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(ShootButtonType == ShootButton.Mouse)
        {
            if(Input.GetMouseButton(0))
            {
                SpawnBullet();
            }
        }
        else
        {
            if(Input.GetKey(ActionButton))
            {
                SpawnBullet();
            }
        }

        intervalCounter++;

    }

    void SpawnBullet()
    {
        if(intervalCounter > IntervalPerBullet)
        {
            GameObject spawn = Instantiate(Bullet) as GameObject;
            spawn.transform.position = SpawnPoint.transform.position;
            spawn.transform.forward = SpawnPoint.transform.forward;
            intervalCounter = 0;
        }
    }
}
