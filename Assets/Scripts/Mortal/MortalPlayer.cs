using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MortalPlayer : Mortal
{
	private Vector3 _startPosition;
	private Rigidbody _rigidbody;

	private void Start()
	{
		_startPosition = transform.position;
		_rigidbody = GetComponent<Rigidbody>();
	}

	protected override void Die()
	{
		base.Die();
		_rigidbody.velocity = _rigidbody.angularVelocity = Vector3.zero;
		transform.position = _startPosition;
	}
}
