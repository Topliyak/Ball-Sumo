using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public const string PowerUpTag = "PowerUp";

	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private Transform _focalPoint;
	[SerializeField] private GameObject _powerUpIndicator;
	[SerializeField] private float _speed;
	[SerializeField] private float _powerUpDuration;
	[SerializeField] private float _powerUpStrength;

	private bool _hasPowerUp;
	private float _getPowerUpMoment;

	private void Start()
	{
		_hasPowerUp = false;
	}

	private void Update()
	{
		float forwardInput = Input.GetAxis("Vertical");
		_rigidbody.AddForce(_focalPoint.forward * _speed * forwardInput);

		if (Time.realtimeSinceStartup - _getPowerUpMoment > _powerUpDuration)
		{
			_hasPowerUp = false;
			_powerUpIndicator.SetActive(false);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(PowerUpTag))
		{
			ActivatePowerUp1();
			Destroy(other.gameObject);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		var enemy = collision.gameObject.GetComponent<Enemy>();

		if (enemy != null)
		{
			if (_hasPowerUp)
				enemy.ApplyImpulce(transform.position, _powerUpStrength);
		}
	}

	private void ActivatePowerUp1()
	{
		_hasPowerUp = true;
		_powerUpIndicator.SetActive(true);
		_getPowerUpMoment = Time.realtimeSinceStartup;
	}
}
