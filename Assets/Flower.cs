using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Flower : MonoBehaviour
{
	[SerializeField]
	private Renderer m_renderer;

	[SerializeField]
	private float m_reviveTime;

	[SerializeField]
	private UnityEvent m_onWatered;

	[SerializeField]
	private UnityEvent m_onRevived;

	private string m_waterTag = "Water";

	private bool m_isWatered;

	private void Start()
	{
		m_renderer.material.SetFloat("_Blend", 1.0f);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(m_waterTag) && !m_isWatered)
		{
			m_isWatered = true;
			m_onWatered?.Invoke();
			StartCoroutine(Revive());
		}
	}

	private IEnumerator Revive()
	{
		var time = 0.0f;
		var startBlend = m_renderer.material.GetFloat("_Blend");
		while (time < m_reviveTime)
		{
			var blend = Mathf.Lerp(startBlend, 0, time / m_reviveTime);
			m_renderer.material.SetFloat("_Blend", blend);
			time += Time.deltaTime;
			yield return null;
		}
		m_renderer.material.SetFloat("_Blend", 0.0f);
		m_onRevived?.Invoke();
	}
}
