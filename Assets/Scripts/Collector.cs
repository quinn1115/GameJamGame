using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameManager gm = GameManager.instance;
        for (int i = 0; i < gm.collectables.Count; i++)
        {
            if(gm.collectables[i] == other.gameObject)
            {
                gm.CollectedItem();
                other.gameObject.SetActive(false);
            }
        }
    }
}
