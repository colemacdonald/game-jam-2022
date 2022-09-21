using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField]
    private float m_lowerAmount;

    [SerializeField]
    private float m_lowerTime;

	private bool m_moving = false;

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

	private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lowerwater") && !m_moving)
		{
			LowerLevel();
		}
    }

    void LowerLevel()
	{
		StartCoroutine(MoveToPosition(transform.position - (transform.up * m_lowerAmount), m_lowerTime));
	}
}
