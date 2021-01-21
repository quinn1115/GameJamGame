using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEvent : EventBase
{
	public override void EventStart()
	{
		Debug.Log("Fire will start spreading soon!");
	}

	public override void EventStop()
	{
		Debug.Log("Fire has stopped spreading!");
	}

	public override void EventUpdate()
	{
		base.EventUpdate();
	}
}
