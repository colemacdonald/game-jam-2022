using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreAffector : MonoBehaviour
{
	private ScoreManager m_scoreManager;

	private void Start()
	{
		m_scoreManager = GameObject.Find("Game Manager").GetComponent<ScoreManager>();
	}

	public void AddToScore(int amount)
	{
		m_scoreManager.AddToScore(amount, transform.position);
	}
}
