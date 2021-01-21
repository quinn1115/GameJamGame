using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameObject keyPref;
    private Vector3[] hidingspots = new Vector3[11];
    [SerializeField]
    private GameObject[] preciousObject = new GameObject[9];
    private List<GameObject> collectables = new List<GameObject>();
    private List<GameObject> collected = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            collectables.Add(null);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DrawRandom();
        }
    }

    void DrawRandom()
    {
        for(int i = 0; i < collectables.Count; i++)
        {
            int rnd = Random.Range(0, preciousObject.Length);
            while (collectables.Contains(preciousObject[rnd]))
            {
                rnd = Random.Range(0, preciousObject.Length);
            }
            collectables.Add(preciousObject[rnd]);
            print(preciousObject[rnd]);
        }


        //GameObject keyClone = Instantiate(keyPref);
        //keyClone.transform.position = hidingspots[Random.Range(0, hidingspots.Length)];

        //for (int i = 0; i < collectables.Length; i++)
        //{
        //    int rnd = Random.Range(0, preciousObject.Length);
        //    //print(rnd);

        //    for(int c = 0; c < collectables.Length; c++)
        //    {
        //        if (preciousObject[rnd] == collectables[c])
        //        {
        //            i--;
        //            print("dubbel");
        //            //print(preciousObject[rnd]);
        //            //print(collectables[c]);
        //        }
        //        else
        //        {
        //            collectables[i] = preciousObject[rnd];
        //        }
        //    }
        //}


        //list = new List<int>(new int[Lenght]);

        //for (int j = 1; j < Lenght; j++)
        //{
        //    Rand = Random.Range(1, 6);

        //    while (list.Contains(Rand))
        //    {
        //        Rand = Random.Range(1, 6);
        //    }

        //    list[j] = Rand;
        //    print(list[j]);
        //}


    }


}
