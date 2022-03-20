using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private Transform _player;
	[SerializeField] private float _speed;

	public Transform Player 
	{ 
		get => _player;
		set => _player = value;
	}

	private void Update()
	{
		Vector3 direction = _player.position - transform.position;
		direction.Normalize();
		_rigidbody.AddForce(direction * _speed);

		if (transform.position.y < -10)
		{
			Kill();
		}
	}

	public void ApplyImpulce(Vector3 playerPosition, float strength)
	{
		Vector3 direction = transform.position - playerPosition;
		direction.Normalize();
		_rigidbody.AddForce(direction * strength, ForceMode.Impulse);
	}

	public void Kill()
	{
		Destroy(gameObject);
	}
}
