using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Water : MonoBehaviour
{
	[SerializeField]
	private int m_waterLevel = 5;
	private int m_maxWaterLevel;

	[SerializeField]
	private int m_targetLevel;

	[SerializeField]
    private float m_lowerAmount;

    [SerializeField]
    private float m_lowerTime;

	[SerializeField]
	private UnityEvent m_onWaterLowerBegin;

	[SerializeField]
	private UnityEvent m_onWaterLoweredOneLevel;

	[SerializeField]
	private UnityEvent m_onReachedTargetLevel;

	private bool m_moving = false;

	private float m_lastRainCollision = 0.0f;

	// Start is called before the first frame update
    void Start()
    {
        m_maxWaterLevel = m_waterLevel;
    }

	IEnumerator MoveToPosition(Vector3 targetPosition, float duration, bool isTargetLevel)
	{
		m_onWaterLowerBegin?.Invoke();
		var time = 0.0f;
		var startPosition = transform.localPosition;
		while (time < duration)
		{
			transform.localPosition = Vector3.Lerp(startPosition, targetPosition, time / duration);
			time += Time.deltaTime;
			yield return null;
		}
		transform.localPosition = targetPosition;
		m_onWaterLoweredOneLevel?.Invoke();
		if (isTargetLevel)
		{
			m_onReachedTargetLevel?.Invoke();
		}

	}

	private void OnTriggerEnter(Collider other)
    {
		if (!m_moving && other.GetComponent<Plant>() is Plant p) {
			AdjustWaterLevel(p.WaterLevelImpact);
		}
    }

	private void OnParticleCollision(GameObject other) {
		if (!m_moving && other.GetComponent<Rain>() is Rain r) {
			if (Time.time > m_lastRainCollision + r.WaterIncreaseIntervalS) {
				m_lastRainCollision = Time.time;
				AdjustWaterLevel(r.WaterIncreaseAmount);
			}
		}
	}

	void AdjustWaterLevel(int levelChange) {
		int actualWaterLevelChange = System.Math.Max(0, System.Math.Min(m_maxWaterLevel, m_waterLevel + levelChange)) - m_waterLevel;

		Debug.Log("adjusting water level by " + levelChange);

		m_waterLevel += actualWaterLevelChange;

		StartCoroutine(MoveToPosition(transform.localPosition + (transform.up * m_lowerAmount * actualWaterLevelChange), m_lowerTime * System.Math.Abs(actualWaterLevelChange), m_waterLevel == m_targetLevel));
	}
}
