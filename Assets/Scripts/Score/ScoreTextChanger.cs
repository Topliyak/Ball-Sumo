using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextChanger : MonoBehaviour
{
	[SerializeField] private Text _scoreText;
	[SerializeField] private Score _score;

	private void OnEnable()
	{
		_score.changedEvent.AddListener(OnScoreChanged);
	}

	private void OnDisable()
	{
		_score.changedEvent.RemoveListener(OnScoreChanged);
	}

	private void OnScoreChanged(int amount)
	{
		_scoreText.text = amount.ToString();
	}
}
