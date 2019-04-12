using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObjectLoop : MonoBehaviour {

    [Header("Hvis denne er sat til, så starter den forfra når den kommer til den sidste")]
    public bool LoopForever;

    [Header("Liste over antal ting at loope igennem")]
    public List<Info> LoopInfo = new List<Info>();



	// Use this for initialization
	IEnumerator Start ()
    {
        while (LoopForever)
        {
            for (int i = 0; i < LoopInfo.Count; i++)
            {
             
                LoopInfo[i].GameObjectToEnable.SetActive(!LoopInfo[i].GameObjectToEnable.activeSelf);
                yield return new WaitForSeconds(LoopInfo[i].TimeUntilDisable);
      
                LoopInfo[i].GameObjectToEnable.SetActive(!LoopInfo[i].GameObjectToEnable.activeSelf);
               
            }
        }

        if(!LoopForever)
        {
            for (int i = 0; i < LoopInfo.Count; i++)
            {
                LoopInfo[i].GameObjectToEnable.SetActive(!LoopInfo[i].GameObjectToEnable.activeSelf);
                yield return new WaitForSeconds(LoopInfo[i].TimeUntilDisable);
                LoopInfo[i].GameObjectToEnable.SetActive(!LoopInfo[i].GameObjectToEnable.activeSelf);
               i++;
            }
        }


    }

}

[System.Serializable]
public class Info
{
    public GameObject GameObjectToEnable;
    [Header("Tiden der går indtil den disabler og går videre til næste på listen")]
    public float TimeUntilDisable;

}
