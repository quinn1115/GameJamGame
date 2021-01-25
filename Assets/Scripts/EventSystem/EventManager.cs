using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	[SerializeField]
	private List<EventBase> m_Events = new List<EventBase>();
	[SerializeField]
	private float Event_StartDelay = 2;
	[SerializeField]
	private float Event_UpdateDelay = 5;
	


	private void Awake()
	{
		StartCoroutine(StartTimer());
	}

	private void Update()
	{
		if(GameManager.instance.GetTimeLeft() < 0)
		{
			foreach (var Event in m_Events)
			{
				Event.EventStop();
				StopCoroutine(StartTimer());
			}
		}
	}


	IEnumerator StartTimer()
	{
		yield return new WaitForSeconds(Event_StartDelay);
		foreach (EventBase Event in m_Events)
		{
			Event.m_UpdateTimerTime = Event_UpdateDelay;
			Event.EventStart();
			
		}
	}
}
