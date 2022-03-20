using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawner : Spawner<Enemy>
{
	[SerializeField] private Transform _player;

	protected override void HandleSpawnedObject(Enemy spawned)
	{
		spawned.Player = _player;
		spawned.enabled = true;
	}
}
