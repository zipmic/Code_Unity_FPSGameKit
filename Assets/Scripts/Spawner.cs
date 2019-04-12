using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
    public enum Type { Single, Multiple}
    [SerializeField]
    private Type SpawnerType = Type.Single;

    public float StartDelay = 2;
    public float SpawnInterval = 2;
    [Range(1,1000)]
    [Header("Amount to spawn before disabling self")]
    public float AmountToSpawn = 1;

    [Header("What object to spawn?")]
    public GameObject ObjectToSpawn;

    private int _amountSpawned;

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }
    // Use this for initialization
    IEnumerator Spawn () 
    {
        if(ObjectToSpawn == null)
        {
            Debug.LogError("Du har glemt at sætte et spawn object");
        }

        yield return new WaitForSeconds(StartDelay);
        if(gameObject.activeSelf)
        {
            GameObject obj = Instantiate(ObjectToSpawn) as GameObject;
            obj.transform.position = transform.position;
            _amountSpawned++;

            if (_amountSpawned >= AmountToSpawn)
            {
                gameObject.SetActive(false);
            }
            else
            {
                if (SpawnerType == Type.Multiple)
                {
                    yield return new WaitForSeconds(SpawnInterval);
                    StartCoroutine(Spawn());
                }
                else if (SpawnerType == Type.Single)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

}
