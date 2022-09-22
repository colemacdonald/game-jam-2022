using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedFade : MonoBehaviour
{
    [SerializeField]
    private float m_fadeDelay;

	[SerializeField]
	private float m_fadeDuration;

	[SerializeField]
	private bool m_destroyOnFade;

	[SerializeField]
	private Renderer m_renderer;

	private void Start()
	{
		StartCoroutine(Fade());
	}

	IEnumerator Fade()
	{
        yield return new WaitForSeconds(m_fadeDelay);

		var time = 0.0f;
		var startColor = m_renderer.material.color;
		var endColor = startColor;
		endColor.a = 0;
		while (time < m_fadeDuration)
		{
			m_renderer.material.color = Color.Lerp(startColor, endColor, time / m_fadeDuration);
			time += Time.deltaTime;
			yield return null;
		}
		m_renderer.material.color = endColor;

		if (m_destroyOnFade)
		{
			Destroy(gameObject);
		}
	}
}
