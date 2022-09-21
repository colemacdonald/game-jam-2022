using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLowerer : MonoBehaviour
{
    [SerializeField]
    private float m_lowerAmount;

    [SerializeField]
    private float m_lowerTime;

    private bool m_active = true;

	private void OnTriggerEnter(Collider other)
    {
        if (m_active)
		{
            var water = other.gameObject.GetComponent<Water>();
            if (water != null)
            {
                water.ChangeLevel(-m_lowerAmount, m_lowerTime);
                m_active = false;
            }
        }
    }
}
