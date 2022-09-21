using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    [SerializeField]
    private GameObject m_itemPrefab;

    [SerializeField]
    private float m_spawnDistance;

    public float SampleField;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
		{
            PlaceItem();
		}
    }

    void PlaceItem()
	{
        // Bit shift the index of the layer (8) to get a bit mask
        var layerMask = ~(1 << 4);

        var spawnPos = transform.position + m_spawnDistance * transform.forward;
        if (Physics.Raycast(spawnPos, -transform.up, out var hitInfo, Mathf.Infinity, layerMask))
        {
            var spawnRotation = Quaternion.Euler(0, Random.value * 360.0f, 0);
            Instantiate(m_itemPrefab, hitInfo.point, spawnRotation);
        }
	}
}
