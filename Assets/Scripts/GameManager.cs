using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameObject keyPref;
    public Transform[] hidingspots = new Transform[3];
	[SerializeField] private GameObject[] preciousObject = new GameObject[9]; // objects to spawn
    public List<GameObject> collectables = new List<GameObject>(); // object that has spawned
    public List<GameObject> collected = new List<GameObject>(); // objects in player inventory?
	private float timeLeft;

    [SerializeField] int collectedItems = 0;

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
		timeLeft = Time.time + 60f;
		//for (int i = 0; i < preciousObject.Length; i++)
  //      {
  //          collectables.Add(null);
  //      }

        DrawRandom();
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
			TransitionManager.instance.LoadScene("LoseScreen");
        }
    }
    void DrawRandom()
    {
        for (int i = 0; i < 4; i++)
        {
            int rnd = Random.Range(0, preciousObject.Length);
            while (collectables.Contains(preciousObject[rnd]))
            {
                rnd = Random.Range(0, preciousObject.Length);
            }
            collectables.Add(preciousObject[rnd]);
			print(preciousObject[rnd]);
        }

        for (int i = 0; i < collectables.Count; i++)
        {
            collectables[i].layer = 10;
        }

		if (hidingspots.Length >= collectables.Count)
		{
			for (int i = 0; i < collectables.Count; i++)
			{
				Instantiate(collectables[i], hidingspots[i].transform.position, Quaternion.identity, this.transform);
			}
		}
		else
		{
			Debug.LogError("WARNING: There are less hiding spots than collectable items");
		}

        GameObject keyClone = Instantiate(keyPref);
        keyPref.name = "Key";
        keyClone.transform.position = hidingspots[Random.Range(0, hidingspots.Length)].position;
    }

    public void CollectedItem()
    {
        collectedItems++;
        timeLeft += 10;

        if (collectedItems >= collectables.Count)
            TransitionManager.instance.LoadScene("WinScreen");
    }

    private void OnTriggerEnter(Collider other)
    {
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
