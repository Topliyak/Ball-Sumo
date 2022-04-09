using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperBehaviour : PowerupBehaviour
{
	private float _timeSinceJumpStarted_sec;
	private float _startPositionY;

	[Header("Jump")]
	[SerializeField] private float _jumpDelay;
	[SerializeField] private float _jumpPeriod;
	[SerializeField] private float _jumpHeight;
	[SerializeField] private AnimationCurve _jumpCurve;

	[Header("Impulce")]
	[SerializeField] private float _impulceRadius;
	[SerializeField] private float _force;

#if UNITY_EDITOR
	public bool displayRadius;
#endif

	private void OnEnable()
	{
		_timeSinceJumpStarted_sec = 0;
		_startPositionY = transform.position.y;
	}

	private void OnDisable() => SetHeight(0);

	private void Update()
	{
		bool wasInJump = _timeSinceJumpStarted_sec < _jumpPeriod;

		_timeSinceJumpStarted_sec += Time.deltaTime;
		_timeSinceJumpStarted_sec %= _jumpPeriod + _jumpDelay;

		bool finishedJump = _timeSinceJumpStarted_sec >= _jumpPeriod;

		if (wasInJump && finishedJump) ApplyImpulce();

		if (_timeSinceJumpStarted_sec > _jumpPeriod)
		{
			SetHeight(0);
		}
		else
		{
			SetHeight(_jumpCurve.Evaluate(_timeSinceJumpStarted_sec / _jumpPeriod) * _jumpHeight);
		}
	}

	private void SetHeight(float height)
	{
		transform.position = transform.position + Vector3.up * (-transform.position.y + _startPositionY + height);
	}

	private void ApplyImpulce()
	{
		var objectsInRadius = Physics.OverlapSphere(transform.position, _impulceRadius);

		foreach (var objectInRadius in objectsInRadius)
		{
			var impulceReceiver = objectInRadius.GetComponent<ImpulceReceiver>();
			impulceReceiver?.ApplyImpulce(transform.position, _force);
		}
	}

	public override void DuplicatePropertiesTo(PowerupBehaviour behaviour)
	{
		JumperBehaviour jumper = behaviour as JumperBehaviour;

		if (jumper == null)
			throw new System.ArgumentException("Argument is not JumperBehaviour instance");

		jumper._jumpDelay = _jumpDelay;
		jumper._jumpPeriod = _jumpPeriod;
		jumper._jumpHeight = _jumpHeight;
		jumper._jumpCurve = _jumpCurve;
		jumper._impulceRadius = _impulceRadius;
		jumper._force = _force;
	}

#if UNITY_EDITOR
	private void OnDrawGizmosSelected()
	{
		if (displayRadius)
			Gizmos.DrawWireSphere(transform.position, _impulceRadius);
	}
#endif
}
