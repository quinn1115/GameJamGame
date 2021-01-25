using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrikandelSpawner : MonoBehaviour
{
    [SerializeField] GameObject FrikandelPrefab;

    private void Start()
    {
        StartCoroutine(SpawnFrik());
    }

    IEnumerator SpawnFrik()
    {
        yield return new WaitForSeconds(1);
        Vector3 spawnPos = FindObjectOfType<FPSCam>().gameObject.transform.position + new Vector3(0, 5, 0); //offset
        Instantiate(FrikandelPrefab, spawnPos, Quaternion.identity);
        StartCoroutine(SpawnFrik());
    }
}
