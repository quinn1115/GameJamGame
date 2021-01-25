using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpreadVolume : MonoBehaviour
{
	public int m_Length = 1;
	public int m_Width = 1;
	public int m_Height = 1;
	public bool m_DrawNonColliding = true;

	public float m_GridDensity = 1;

	private List<VolumePoint> Points = new List<VolumePoint>();
	private List<VolumePoint> CollidingPoints = new List<VolumePoint>();

	private void Awake()
	{
		GenerateVolume();	
	}

	public void GenerateVolume()
	{
		Points.Clear();
		for (int x = 0; x < m_Length; x++)
		{
			for (int y = 0; y < m_Width; y++)
			{
				for (int z = 0; z < m_Height; z++)
				{
					Points.Add(new VolumePoint(new Vector3((x / m_GridDensity), z , (y / m_GridDensity)), transform));
				}
			}
		}
		CollidingPoints.Clear();
		foreach (var Point in Points)
		{
			if (Point.IsColliding(0.25f))
			{
				CollidingPoints.Add(Point);
			}
		}
	}

	public VolumePoint GetRandomPoint()
	{
		return CollidingPoints[Random.Range(0, CollidingPoints.Count)];
	}

	private void OnDrawGizmos()
	{
		GenerateVolume();
		foreach (VolumePoint Point in Points)
		{
			if (Point.IsColliding(0.25f))
			{
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(Point.GetWorldLocation(), 0.25f);
			}
			else
			{
				if (m_DrawNonColliding)
				{
					Gizmos.color = Color.blue;
					Gizmos.DrawWireSphere(Point.GetWorldLocation(), 0.25f);
				}
			}
		}
	}
}
