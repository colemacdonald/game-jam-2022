using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
	private Transform m_camera;

	private void Start()
	{
		m_camera = Camera.main.transform;
	}

	// Update is called once per frame
	void LateUpdate()
    {
		transform.LookAt(transform.position + m_camera.forward); ;
    }
}
