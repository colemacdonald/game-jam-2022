using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	[SerializeField]
	private Vector3 m_rotationAxis = Vector3.up;

	[SerializeField]
	private float m_rotationSpeed;

	// Update is called once per frame
	void Update()
    {
		transform.Rotate(m_rotationAxis, m_rotationSpeed);
    }
}
