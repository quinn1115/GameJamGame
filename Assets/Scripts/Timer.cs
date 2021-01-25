using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text text;

    private EventBase events;

    private void Start()
    {
        events = FindObjectOfType<EventBase>();
    }

    private void Update()
    {
        if(GameManager.instance != null)
        {
            if(events.IsStarted())
                text.text = GameManager.instance.GetTimeLeft().ToString("0.00");
        }
    }
}
