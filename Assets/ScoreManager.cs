using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	[SerializeField]
	private GameObject m_scoreChangePrefab;

	public void AddToScore(int amount, Vector3 textSpawnPos)
	{
		var scoreText = Instantiate(m_scoreChangePrefab, textSpawnPos, Quaternion.identity).GetComponent<TextMeshPro>();
		var scoreTextPrefix = "";
		if (amount > 0)
		{
			scoreTextPrefix = "+";
			scoreText.color = Color.green;
		}
		else
		{
			scoreText.color = Color.red;
		}
		scoreText.text = $"{scoreTextPrefix}{amount}";
	}
}
