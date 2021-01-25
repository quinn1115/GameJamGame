using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameManager gm = GameManager.instance;
        if (other.GetComponent<Interactable>() && other.GetComponent<Interactable>().isPrecious)
        {
            gm.CollectedItem();
            other.gameObject.SetActive(false);
        }
    }
}
