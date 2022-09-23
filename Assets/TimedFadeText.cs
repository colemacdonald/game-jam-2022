using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimedFadeText : MonoBehaviour
{
    [SerializeField]
    private float m_fadeDelay;

	[SerializeField]
	private float m_fadeDuration;

	[SerializeField]
	private bool m_destroyOnFade;

	[SerializeField]
	private TextMeshPro m_text;

	private void Start()
	{
		StartCoroutine(Fade());
	}

	IEnumerator Fade()
	{
        yield return new WaitForSeconds(m_fadeDelay);

		var time = 0.0f;
		var startColor = m_text.color;
		var endColor = startColor;
		endColor.a = 0;
		while (time < m_fadeDuration)
		{
			m_text.color = Color.Lerp(startColor, endColor, time / m_fadeDuration);
			time += Time.deltaTime;
			yield return null;
		}
		m_text.color = endColor;

		if (m_destroyOnFade)
		{
			Destroy(gameObject);
		}
	}
}
