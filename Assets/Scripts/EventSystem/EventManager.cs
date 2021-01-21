using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	[SerializeField]
	protected List<EventBase> Events = new List<EventBase>();
	[SerializeField]
	protected float Event_StartDelay = 2;


	private void Awake()
	{
		StartCoroutine(StartTimer());
	}

	IEnumerator StartTimer()
	{
		yield return new WaitForSeconds(Event_StartDelay);
		foreach (EventBase Event in Events)
		{
			Event.EventStart();
		}
	}
}
