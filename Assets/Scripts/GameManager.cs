using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameObject keyPref;

    public Vector3[] hidingspots = new Vector3[9];
    public GameObject[] preciousObject = new GameObject[5];
    public GameObject[] collectables = new GameObject[2];
    public List<GameObject> collected = new List<GameObject>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void DrawRandom()
    {
        GameObject keyClone = Instantiate(keyPref);
        keyClone.transform.position = hidingspots[Random.Range(0, hidingspots.Length)];

        for(int i = 0; i < collectables.Length; i++)
        {

        }
    }

}
