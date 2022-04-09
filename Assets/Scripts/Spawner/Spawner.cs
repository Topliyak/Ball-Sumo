using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Spawner<T>: MonoBehaviour where T: Object
{
	[SerializeField] private T[] _templates;
	[SerializeField] private Transform _spawnPoint;
	[SerializeField] private Transform _spawnedObjectsParent;
	[SerializeField] private Vector3 _maxOffset;

	public UnityEvent<T> spawnedEvent { get; } = new UnityEvent<T>();

	public T[] templates => _templates;

	public Transform spawnPoint => _spawnPoint;

	public Transform spawnedObjectsParent => _spawnedObjectsParent;

	public Vector3 maxOffset => _maxOffset;

	public virtual void Spawn(int count)
	{
		for (int i = 0; i < count; i++)
		{
			T spawned = Instantiate(GetRandomTemplate(), GetRandomPosition(), _spawnPoint.rotation, _spawnedObjectsParent);
			spawnedEvent.Invoke(spawned);
		}
	}

	public virtual void Spawn() => Spawn(1);

	protected Vector3 GetRandomPosition()
	{
		Vector3 offset = new Vector3(Random.Range(-_maxOffset.x, _maxOffset.x),
									 Random.Range(-_maxOffset.y, _maxOffset.y),
									 Random.Range(-_maxOffset.z, _maxOffset.z));

		return _spawnPoint.TransformDirection(offset);
	}

	protected T GetRandomTemplate() => _templates[Random.Range(0, _templates.Length)];
}
