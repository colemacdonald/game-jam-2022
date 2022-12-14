using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField]
    private Transform m_cursor;

    [SerializeField]
    private float m_cursorDistance;

    [SerializeField]
    private float m_cursorProjectionHeightOffset;

    [SerializeField]
    private LayerMask m_cursorLayerMask;

    [SerializeField]
    private LayerMask m_spawnLayerMask;

    private int m_hitObjectLayer;

    private Vector3 SpawnPos => transform.position + (Vector3.up* m_cursorProjectionHeightOffset) + m_cursorDistance * transform.forward;

    public void SetCursorActive(bool active)
	{
        m_cursor.gameObject.SetActive(active);
	}

    public void InstantiateAtCursor(GameObject prefab, bool randomizeRotation)
    {
        var baseRotation = randomizeRotation ? Quaternion.Euler(0, Random.value * 360.0f, 0) : Quaternion.identity;
        if ((m_hitObjectLayer & m_spawnLayerMask.value) != 0)
        {
            Instantiate(prefab, m_cursor.position, baseRotation * m_cursor.rotation);
        }
        else if (Physics.Raycast(SpawnPos, -Vector3.up, out var hitInfo, Mathf.Infinity, m_spawnLayerMask.value))
        {
            Instantiate(prefab, hitInfo.point, baseRotation * GetForwardRotation(hitInfo.normal));
        }
    }

    private Quaternion GetForwardRotation(Vector3 up)
	{
        var forward = Vector3.Cross(transform.right, up).normalized;
        return Quaternion.LookRotation(forward, up);
	}

    private void Update()
	{
        if (Physics.Raycast(SpawnPos, -Vector3.up, out var hitInfo, Mathf.Infinity, m_cursorLayerMask.value))
        {
            m_hitObjectLayer = hitInfo.transform.gameObject.layer;
            m_cursor.position = hitInfo.point;
            m_cursor.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }
}
