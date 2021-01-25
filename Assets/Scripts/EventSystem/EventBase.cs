using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBase : MonoBehaviour
{

	private bool m_EventStarted;

	public bool IsStarted() { return m_EventStarted; }

	// Update is called once per frame
	void Update()
	{
		if (m_EventStarted)
		{
			EventUpdate();
		}
	}		
	
	public virtual void EventStart()
	{
		Debug.Log("Event Started");
		m_EventStarted = true;
	}

	public virtual void EventStop()
	{
		Debug.Log("Event Stopped");
		m_EventStarted = false;
	}

	public virtual void EventUpdate()
	{}
}
