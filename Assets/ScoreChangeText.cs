using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChangeText : MonoBehaviour
{
	[SerializeField]
	private float m_lifetime;

	[SerializeField]
	private AnimationCurve m_movementCurve;

	public int Value { get; set; }

	void Start()
	{

	}
}
