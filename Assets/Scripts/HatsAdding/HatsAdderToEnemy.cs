using UnityEngine;

public class HatsAdderToEnemy : HatsAdder
{
	const string nonRotatableCenterName = "NonRotatableCenter";

	[SerializeField] private EnemyMoverSpawner _enemiesSpawner;

	private void OnEnable() => _enemiesSpawner.enemySpawnedEvent += OnEnemySpawned;

	private void OnDisable() => _enemiesSpawner.enemySpawnedEvent -= OnEnemySpawned;

	private void OnEnemySpawned(EnemyMover enemy)
	{
		Transform nonRotatableCenter = enemy.transform.Find(nonRotatableCenterName);

		if (nonRotatableCenter == null)
			throw new System.NullReferenceException($"Enemy hasn't child with name \"{nonRotatableCenterName}\"");

		AddHatTo(nonRotatableCenter);
	}

#if UNITY_EDITOR

	[Header("Debug")]
	public EnemyMover enemyExample;

	[ContextMenu("DebugHatAdding")]
	private void DebugHatAdding() => OnEnemySpawned(enemyExample);

#endif
}
