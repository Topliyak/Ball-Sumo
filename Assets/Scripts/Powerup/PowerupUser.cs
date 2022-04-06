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
		{
			_powerupBehaviour = null;
			powerupOverEvent.Invoke();
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

			gotPowerupEvent.Invoke();
		}
	}
}
