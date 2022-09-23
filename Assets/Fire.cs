using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fire : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem m_particleSystem;

	[SerializeField]
	private Light m_light;

	[SerializeField]
	private float m_extinguishDelay;

	[SerializeField]
	private float m_lightFadeTime;

	[SerializeField]
	private float m_destroyDelay;

	[SerializeField]
	private UnityEvent m_onBeginExtinguish;

	[SerializeField]
	private UnityEvent m_onExtinguished;

	private bool m_active = true;

	private string m_waterTag = "Water";

	public void Extinguish()
	{
		StartCoroutine(ExtinguishSelf());
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(m_waterTag) && m_active)
		{
			StartCoroutine(ExtinguishSelf());
		}
	}

	private IEnumerator FadeLight()
	{
		var time = 0.0f;
		var startIntensity = m_light.intensity;
		while (time < m_lightFadeTime)
		{
			m_light.intensity = Mathf.Lerp(startIntensity, 0, time / m_lightFadeTime);
			time += Time.deltaTime;
			yield return null;
		}
		m_light.intensity = 0;
	}

	private IEnumerator ExtinguishSelf()
	{
		m_active = false;
		yield return new WaitForSeconds(m_extinguishDelay);
		m_onBeginExtinguish?.Invoke();
		m_particleSystem.Stop();
		yield return StartCoroutine(FadeLight());
		m_onExtinguished?.Invoke();
		yield return new WaitForSeconds(m_destroyDelay);
		Destroy(gameObject);
	}
}
