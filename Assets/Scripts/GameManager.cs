using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameObject keyPref;
    public Transform[] hidingspots = new Transform[3];
    [SerializeField]
    private GameObject[] preciousObject = new GameObject[9];
    public List<GameObject> collectables = new List<GameObject>();
    public List<GameObject> collected = new List<GameObject>();
	private float timeLeft;


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
		timeLeft = 60;
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
            timeLeft = Time.time + 60f;
        }
        if (GetTimeLeft() <= 0f)
        {
            Debug.Log("GameOver, You went up in to flames");
			//SceneManager.LoadScene("MainMenu");
        }
    }
    void DrawRandom()
    {
        for (int i = 0; i < collectables.Count; i++)
        {
            int rnd = Random.Range(0, preciousObject.Length);
            while (collectables.Contains(preciousObject[rnd]))
            {
                rnd = Random.Range(0, preciousObject.Length);
            }
            collectables[i] = preciousObject[rnd];
            print(preciousObject[rnd]);
        }

        GameObject keyClone = Instantiate(keyPref);
        keyClone.transform.position = hidingspots[Random.Range(0, hidingspots.Length)].position;
    }

    private void OnTriggerEnter(Collider other)
    {
        int collectedItems = 0;
        for(int C = 0; C < collected.Count; C++)
        {
            for (int L = 0; L < collectables.Count; L++)
            {
                if (collected[C] == collectables[L])
                {
                    collectedItems++;   
                }
            }
        }
        if(collectedItems == collectables.Count)
        {
            print("You won/nxt lvl");
        }
        else
        {
            print("Zoek verder");
        }
    }

    public float GetTimeLeft()
    {
        return timeLeft - Time.time;
    }
}
