using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    [SerializeField]
    private int m_waterIncreaseIntervalS;
    public int WaterIncreaseIntervalS {
        get => m_waterIncreaseIntervalS;
    }

    [SerializeField]
    private int m_waterIncreaseAmount;
    public int WaterIncreaseAmount {
        get => m_waterIncreaseAmount;
    }
}
