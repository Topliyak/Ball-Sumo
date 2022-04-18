using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;
using Random = UnityEngine.Random;

public class EnemyMoverSpawner : Spawner<EnemyMover>
{
	[SerializeField] private Transform _player;
	[SerializeField] private Transform _staticPoint;

	public event UnityAction<EnemyMover> enemySpawnedEvent;

	public override EnemyMover[] Spawn(int count)
	{
		EnemyMover[] spawned = base.Spawn(count);

		foreach (var enemy in spawned) OnEnemySpawned(enemy);

		return spawned;
	}

	private void OnEnemySpawned(EnemyMover enemyMover)
	{
		enemyMover.player = _player;
		enemyMover.enabled = true;

		ConstraintSource constraintSource = new ConstraintSource();
		constraintSource.sourceTransform = _staticPoint;
		constraintSource.weight = 1;
		enemyMover.GetComponentInChildren<RotationConstraint>().SetSource(0, constraintSource);

		enemySpawnedEvent?.Invoke(enemyMover);
	}
}
