using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToOffset : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_positionOffset;

	[SerializeField]
	private float m_moveDelay;

	[SerializeField]
	private float m_moveDuration;

	[SerializeField]
	private AnimationCurve m_movementCurve;

	[SerializeField]
	private bool m_moveOnStart;

	// Start is called before the first frame update
	void Start()
    {
        if (m_moveOnStart)
		{
			Move();
		}
    }

	public void Move()
	{
		StartCoroutine(MoveCoroutine());
	}

    private IEnumerator MoveCoroutine()
	{
		yield return new WaitForSeconds(m_moveDelay);

		var time = 0.0f;
		var startPosition = transform.position;
		var targetPosition = startPosition + m_positionOffset;
		while (time < m_moveDuration)
		{
			transform.localPosition = Vector3.Lerp(startPosition, targetPosition, m_movementCurve.Evaluate(time / m_moveDuration));
			time += Time.deltaTime;
			yield return null;
		}
		transform.localPosition = targetPosition;
	}
}
