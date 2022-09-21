using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
	[SerializeField]
	private int m_waterLevel = 5;
	private int m_maxWaterLevel;

    [SerializeField]
    private float m_lowerAmount;

    [SerializeField]
    private float m_lowerTime;

	private bool m_moving = false;

	// Start is called before the first frame update
    void Start()
    {
        m_maxWaterLevel = m_waterLevel;
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

	private void OnTriggerEnter(Collider other)
    {
		if (!m_moving && other.GetComponent<Plant>() is Plant p) {
			AdjustWaterLevel(p.WaterLevelImpact);
		}
    }

	void AdjustWaterLevel(int levelChange) {
		int actualWaterLevelChange = System.Math.Max(0, System.Math.Min(m_maxWaterLevel, m_waterLevel + levelChange)) - m_waterLevel;

		m_waterLevel += actualWaterLevelChange;

		StartCoroutine(MoveToPosition(transform.position + (transform.up * m_lowerAmount * actualWaterLevelChange), m_lowerTime * System.Math.Abs(actualWaterLevelChange)));
	}
}
