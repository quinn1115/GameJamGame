using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Key(Clone)")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
            other.gameObject.SetActive(false);
        }
    }
}
