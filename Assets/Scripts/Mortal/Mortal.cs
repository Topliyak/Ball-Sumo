using UnityEngine;
using UnityEngine.Events;

public class Mortal : MonoBehaviour
{
	[SerializeField] private float _minY;

	[SerializeField] private UnityEvent<GameObject> _deadEvent;

	public UnityEvent<GameObject> deadEvent => _deadEvent;

	protected virtual void Update()
	{
		if (transform.position.y < _minY)
		{
			Die();
		}
	}

	protected virtual void Die()
	{
		deadEvent.Invoke(gameObject);
	}
}
