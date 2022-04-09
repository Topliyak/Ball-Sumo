using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreTextChanger : MonoBehaviour
{
	private TextMeshProUGUI _scoreText;

	[SerializeField] private Score _score;

	private void Start() => _scoreText = GetComponent<TextMeshProUGUI>();

	private void OnEnable() => _score.changedEvent.AddListener(OnScoreChanged);

	private void OnDisable() => _score.changedEvent.RemoveListener(OnScoreChanged);

	private void OnScoreChanged(int amount) => _scoreText.text = amount.ToString();
}
