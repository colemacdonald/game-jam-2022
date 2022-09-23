using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreeReplacer : MonoBehaviour
{
    [SerializeField]
    public GameObject[] m_prefabs;

    private TerrainData m_terrainData;
    private TreeInstance[] m_originalInstances;

    // Use this for initialization
    void Start()
    {
        var prefabDictionary = m_prefabs.ToDictionary(prefab => prefab.name, prefab => prefab);
        m_terrainData = GetComponent<Terrain>().terrainData;
        m_originalInstances = m_terrainData.treeInstances;
        var treeInstanceList = m_terrainData.treeInstances.ToList();
        foreach (TreeInstance tree in m_originalInstances)
        {
            var treePrefab = m_terrainData.treePrototypes[tree.prototypeIndex].prefab;
            if (prefabDictionary.ContainsKey(treePrefab.name))
			{
                var treePos = Vector3.Scale(tree.position, m_terrainData.size) + Terrain.activeTerrain.transform.position;
                var treeRotation = Quaternion.Euler(0, Mathf.Rad2Deg * tree.rotation, 0);
                Instantiate(treePrefab, treePos, treeRotation);
                treeInstanceList.Remove(tree);
            }
        }

        m_terrainData.treeInstances = treeInstanceList.ToArray();
    }

	private void OnDestroy()
	{
        m_terrainData.treeInstances = m_originalInstances;
	}
}
