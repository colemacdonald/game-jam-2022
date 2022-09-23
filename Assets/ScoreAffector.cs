using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreAffector : MonoBehaviour
{
	[SerializeField]
	private GameObject m_scoreChangePrefab;

	private ScoreManager m_scoreManager;

	private void Start()
	{
		m_scoreManager = GameObject.Find("Game Manager").GetComponent<ScoreManager>();
	}

	public void AddToScore(int amount)
	{
		m_scoreManager.AddToScore(amount);
		var scoreText = Instantiate(m_scoreChangePrefab, transform.position, Quaternion.identity).GetComponent<TextMeshPro>();
		scoreText.text = amount.ToString();
		if (amount > 0)
		{
			scoreText.color = Color.green;
		}
		else
		{
			scoreText.color = Color.red;
		}
	}
}
