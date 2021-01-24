using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text text;

    private void Update()
    {
        if(GameManager.instance != null)
        {
            text.text = GameManager.instance.GetTimeLeft().ToString("0.00");
        }
    }
}
