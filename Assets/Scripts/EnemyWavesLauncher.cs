using System.Linq;
using UnityEngine;

public class EnemyWavesLauncher : MonoBehaviour
{
	[SerializeField] private EnemiesSpawner _enemiesSpawner;
	[SerializeField] private PowerUpSpawner _powerUpSpawner;

	private int _waveNumber;

	private void Start()
	{
		_waveNumber = 0;
	}

	private void Update()
	{
		if (FindObjectsOfType<Enemy>().Any() == false)
		{
			if (FindObjectsOfType<GameObject>().Any(obj => obj.tag.Contains(PlayerController.PowerUpTag)) == false)
			{
				LaunchNextWave();
			}
		}
	}

	private void LaunchNextWave()
	{
		_waveNumber++;
		_enemiesSpawner.Spawn(_waveNumber);
		_powerUpSpawner.Spawn();
	}
}
