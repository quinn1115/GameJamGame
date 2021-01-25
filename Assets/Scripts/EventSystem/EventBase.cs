using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBase : MonoBehaviour
{

	[HideInInspector]
	public float m_UpdateTimerTime;
	bool m_EventStarted;

	public bool IsStarted() { return m_EventStarted; }

    private void Start()
    {
		m_EventStarted = true;
    }

    // Update is called once per frame
    void Update()
	{
	}		
	
	public virtual void EventStart()
	{
		StartCoroutine(UpdateTimer());
	}

	public virtual void EventStop()
	{
		m_EventStarted = false;
	}

	public virtual void EventUpdate()
	{}

	IEnumerator UpdateTimer()
	{
		yield return new WaitForSeconds(m_UpdateTimerTime);
		EventUpdate();
		StartCoroutine(UpdateTimer());
	}
}
