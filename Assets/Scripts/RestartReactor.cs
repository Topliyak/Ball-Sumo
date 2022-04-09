using UnityEngine;

public class RestartReactor : MonoBehaviour
{
	private Rigidbody _rigidbody;
	private Vector3 _startPosition;
	private PowerupUser _powerupUser;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_powerupUser = GetComponent<PowerupUser>();
		_startPosition = transform.position;
	}

	public void OnRestart()
	{
		_rigidbody.velocity = _rigidbody.angularVelocity = Vector3.zero;
		transform.position = _startPosition;
		_powerupUser.ResetPowerup();
	}
}
