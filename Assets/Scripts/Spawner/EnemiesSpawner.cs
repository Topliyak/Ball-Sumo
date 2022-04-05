using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawner : Spawner<Enemy>
{
	[SerializeField] private Transform _player;

	private void OnEnable()
	{
		spawnedEvent.AddListener(OnEnemySpawned);
	}

	private void OnDisable()
	{
		spawnedEvent.RemoveListener(OnEnemySpawned);
	}

	private void OnEnemySpawned(Enemy spawned)
	{
		spawned.Player = _player;
		spawned.enabled = true;
	}
}
