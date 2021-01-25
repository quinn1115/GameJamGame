using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumePoint
{
	private Vector3 m_Position;
	private Transform m_ParentTransform;

	public VolumePoint(Vector3 newPosition, Transform parentTransform)
	{
		m_Position = newPosition;
		m_ParentTransform = parentTransform; 
	}

	public bool IsColliding(float ColRadius)
	{
		var col = Physics.OverlapSphere(m_ParentTransform.position + m_Position, ColRadius);
		bool bIsColliding = false;

		if (col.Length > 0)
		{
			for (int i = 0; i < col.Length; i++)
			{
				if (col[i].gameObject.tag != "Player" && col[i].gameObject.tag != "Interactable")
				{
					bIsColliding = true;
				}
				else
				{
					bIsColliding = false;
				}
			}
		}
		else
		{
			bIsColliding = false;
		}
		return bIsColliding;
	}

	public Vector3 GetWorldLocation()
	{
		return  m_ParentTransform.position + m_Position;
	}

	public Vector3 GetLocalLocation()
	{
		return m_Position;
	}
}
