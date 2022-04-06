using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawner : Spawner<EnemyMover>
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

	private void OnEnemySpawned(EnemyMover spawned)
	{
		spawned.player = _player;
		spawned.enabled = true;
	}
}
