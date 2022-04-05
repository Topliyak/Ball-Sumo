using System.Linq;
using UnityEngine;

public class EnemyWavesLauncher : MonoBehaviour
{
	[SerializeField] private EnemiesSpawner _enemiesSpawner;
	[SerializeField] private PowerUpSpawner _powerUpSpawner;
	[SerializeField] private Score _score;

	private void OnEnable()
	{
		_score.changedEvent.AddListener(Launch);
	}

	private void OnDisable()
	{
		_score.changedEvent.RemoveListener(Launch);
	}

	private void Launch(int wave)
	{
		_enemiesSpawner.Spawn(wave);
		_powerUpSpawner.Spawn();
	}
}
