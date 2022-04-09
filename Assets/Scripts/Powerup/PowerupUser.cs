using UnityEngine;
using UnityEngine.Events;

public class PowerupUser : MonoBehaviour
{
	private PowerupBehaviour _powerupBehaviour;
	private float _timeUntilPowerupOver;
	
	[Space, SerializeField] private UnityEvent _gotPowerupEvent;
	[SerializeField] private UnityEvent _powerupOverEvent;

	public UnityEvent gotPowerupEvent => _gotPowerupEvent;

	public UnityEvent powerupOverEvent => _powerupOverEvent;

	private void Update()
	{
		_timeUntilPowerupOver -= Time.deltaTime;

		if (_timeUntilPowerupOver <= 0)
			ResetPowerup();
	}

	private void OnTriggerEnter(Collider other)
	{
		Powerup powerup = other.GetComponent<Powerup>();

		if (powerup != null)
		{
			ChangeBehaviour(powerup.behaviour);
			_timeUntilPowerupOver = powerup.duration_sec;

			powerup.Destroy();
			
			gotPowerupEvent.Invoke();
		}
	}

	private void ChangeBehaviour(PowerupBehaviour behaviour)
	{
		Destroy(_powerupBehaviour);
		_powerupBehaviour = gameObject.AddComponent(behaviour.GetType()) as PowerupBehaviour;
		behaviour.DuplicatePropertiesTo(_powerupBehaviour);
		_powerupBehaviour.Activate();
	}

	public void ResetPowerup()
	{
		Destroy(_powerupBehaviour);
		_powerupBehaviour = null;
		powerupOverEvent.Invoke();
	}
}
