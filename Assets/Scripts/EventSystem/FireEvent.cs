using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class FireEvent : EventBase
{
	[SerializeField]	private FireSpreadVolume m_Volume;
	[SerializeField]	private GameObject m_FirePrefab;
	[SerializeField]	private int m_MaxFireAmount = 10;
	[SerializeField]	private PostProcessVolume m_FPSPostProcessing;
	private List<GameObject> m_Flames = new List<GameObject>();

	//Post Processing Settings
	ColorGrading		colorGrading;
	ChromaticAberration chromaticAberration;
	Bloom				bloom;
	LensDistortion		lensDistortion;

	public override void EventStart()
	{
		base.EventStart();
		Debug.Log("Fire will start spreading soon!");
		m_Flames.Clear();
		m_FPSPostProcessing.profile.TryGetSettings(out colorGrading);
		m_FPSPostProcessing.profile.TryGetSettings(out chromaticAberration);
		m_FPSPostProcessing.profile.TryGetSettings(out bloom);
		m_FPSPostProcessing.profile.TryGetSettings(out lensDistortion);
	}

	public override void EventStop()
	{
		base.EventStop();
		Debug.Log("Fire has stopped spreading!");
	}

	public override void EventUpdate()
	{
		base.EventUpdate();
		SpawnFire();
	}

	public void SpawnFire()
	{
		if (m_Flames.Count < m_MaxFireAmount)
		{
			print("Fire Has Spawned");
			GameObject curFire = Instantiate(m_FirePrefab, m_Volume.GetRandomPoint().GetWorldLocation(), Quaternion.identity);
			m_Flames.Add(curFire);
		}
		else
		{
			chromaticAberration.intensity.value += 0.25f;
			colorGrading.brightness.value -= 5f;
			colorGrading.brightness.value = Mathf.Clamp(colorGrading.brightness.value, -40, 0);
			bloom.intensity.value += 1f;
			bloom.intensity.value = Mathf.Clamp(bloom.intensity.value, 2, 10);
			lensDistortion.intensity.value += 5;
			lensDistortion.intensity.value = Mathf.Clamp(lensDistortion.intensity.value, 0, 20);
		}
		
	}
}
