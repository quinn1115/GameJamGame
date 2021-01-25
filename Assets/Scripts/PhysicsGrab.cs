﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PhysicsGrab : MonoBehaviour
{
	//Public
	public float m_InteractionDistance = 200;
	public float m_Speed = 10;
	public float m_ThrowStrength = 10;

	//Private
	[SerializeField] private Transform m_Camera;
	[SerializeField] private GameObject m_GrabPos;
	private GameObject CurrentInteractable;
	private Rigidbody CurRigidbody;

	// Start is called before the first frame update
	void Start()
    {
		CurrentInteractable = null;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.E))
		{
			Interact();
		}
		if (Input.GetMouseButtonDown(0))
		{
			if (CurrentInteractable)
			{
				CurrentInteractable.GetComponent<Rigidbody>().AddForce(m_Camera.forward * m_ThrowStrength, ForceMode.Impulse);
				CurRigidbody.angularDrag = 0.05f;
				CurRigidbody = null;
				CurrentInteractable = null;
			}
		}
    }

	void Interact()
	{
		if (!CurrentInteractable)
		{
			Ray InteractionRay = new Ray(m_Camera.position, m_Camera.forward);
			RaycastHit hitInfo;
			Debug.DrawLine(m_Camera.position, m_Camera.forward * m_InteractionDistance);
			if (Physics.Raycast(InteractionRay,out hitInfo, m_InteractionDistance))
			{
				if (hitInfo.collider.gameObject.tag == "Interactable")
				{
					CurrentInteractable = hitInfo.collider.gameObject;
					CurRigidbody = CurrentInteractable.GetComponent<Rigidbody>();					
					CurRigidbody.rotation = Quaternion.Euler(Vector3.zero);
					CurRigidbody.angularDrag = 2;
					Debug.Log("Grab hit Gameobject: " + hitInfo.collider.gameObject.name);

					if(hitInfo.collider.gameObject.GetComponent<LockedDoor>() == null)
						CurRigidbody.constraints = RigidbodyConstraints.None;
				}
			}
		}
	}

	private void FixedUpdate()
	{
		if (CurrentInteractable && CurrentInteractable.GetComponent<Rigidbody>() != null)
		{
			CurrentInteractable.GetComponent<Rigidbody>().velocity = (m_GrabPos.transform.position - CurrentInteractable.transform.position) * m_Speed;
		}
	}
}
