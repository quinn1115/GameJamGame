using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBase : MonoBehaviour
{

	[HideInInspector]
	public float m_UpdateTimerTime;


	public virtual void EventStart()
	{
		StartCoroutine(UpdateTimer());
	}

	public virtual void EventStop()
	{}

	public virtual void EventUpdate()
	{}

	IEnumerator UpdateTimer()
	{
		yield return new WaitForSeconds(m_UpdateTimerTime);
		EventUpdate();
		StartCoroutine(UpdateTimer());
	}
}
