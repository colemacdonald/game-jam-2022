using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPlacer : MonoBehaviour
{
    [SerializeField]
    private GameObject m_itemPrefab;

    [SerializeField]
    private GameObject m_waterPrefab;

    [SerializeField]
    private float m_spawnDistance;

    private CursorController m_cursorController;

	private void Start()
	{
        m_cursorController = GetComponent<CursorController>();
	}

	// Update is called once per frame
	void Update()
    {
        if (Input.GetMouseButtonDown(0))
		{
            PlaceItem();
		}

        if (Input.GetMouseButtonDown(1))
        {
            PlaceWater();
        }
    }

    void PlaceItem()
	{
        m_cursorController.InstantiateAtCursor(m_itemPrefab, true);
	}

    void PlaceWater()
    {
        m_cursorController.InstantiateAtCursor(m_waterPrefab, true);
    }
}
