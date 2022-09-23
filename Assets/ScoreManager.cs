using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	[SerializeField]
	private GameObject m_scoreChangePrefab;

	[SerializeField]
	private TextMeshPro m_uiScoreText;

	[SerializeField]
	private float m_scoreUpdateDelay;

	private int m_score = 0;

	public void AddToScore(int amount, Vector3 textSpawnPos)
	{
		StartCoroutine(AddToScoreCoroutine(amount));
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

	private IEnumerator AddToScoreCoroutine(int amount)
	{
		yield return new WaitForSeconds(m_scoreUpdateDelay);
		m_score += amount;
		UpdateScoreText();
	}

	private void Start()
	{
		UpdateScoreText();
	}

	private void UpdateScoreText()
	{
		m_uiScoreText.text = $"Eco: {m_score}";
	}
}
