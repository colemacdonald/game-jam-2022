using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
	private Vector3 m_targetPosition;

	private void Start()
	{
		m_targetPosition = transform.position;
	}

	IEnumerator MoveToPosition(Vector2 targetPosition, float duration)
	{
		var time = 0.0f;
		var startPosition = transform.position;
		while (time < duration)
		{
			transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
			time += Time.deltaTime;
			yield return null;
		}
		transform.position = targetPosition;
	}

	public void ChangeLevel(float amount, float time)
	{
		m_targetPosition = m_targetPosition + (transform.up * amount);
		var routine = StartCoroutine(MoveToPosition(m_targetPosition, time));
	}
}
