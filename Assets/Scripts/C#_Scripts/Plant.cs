using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    /*
        Plants impact on water level
    */
    [SerializeField]
    private int m_waterLevelImpact = 0;

    public int WaterLevelImpact {
        get => m_waterLevelImpact;
    }

    public bool Active { get; set; } = true;
}
