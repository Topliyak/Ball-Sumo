using UnityEngine;

public class PowerupUser : MonoBehaviour
{
	private PowerupBehaviour _powerupBehaviour;
	private float _timeUntilPowerupOver;

	private void Update()
	{
		_timeUntilPowerupOver -= Time.deltaTime;

		if (_timeUntilPowerupOver <= 0)
		{
			_powerupBehaviour = null;
		}

		_powerupBehaviour?.Apply();
	}

	private void OnTriggerEnter(Collider other)
	{
		Powerup powerup = other.GetComponent<Powerup>();

		if (powerup != null)
		{
			_powerupBehaviour = powerup.behaviour;
			_timeUntilPowerupOver = powerup.duration_sec;
			_powerupBehaviour.Init(this);
			powerup.Destroy();
		}
	}
}
