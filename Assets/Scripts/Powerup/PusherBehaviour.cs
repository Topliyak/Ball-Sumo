using UnityEngine;

public class PusherBehaviour : PowerupBehaviour
{
	[SerializeField] private float _pushForce;

	private void OnCollisionEnter(Collision collision)
	{
		if (enabled == false)
			return;

		collision.gameObject.GetComponent<ImpulceReceiver>()?.ApplyImpulce(transform.position, _pushForce);
	}

	public override void DuplicatePropertiesTo(PowerupBehaviour behaviour)
	{
		PusherBehaviour pusherBehaviour = behaviour as PusherBehaviour;

		if (pusherBehaviour == null)
			throw new System.ArgumentException("Argument is not PusherBehaviour instance");

		pusherBehaviour._pushForce = _pushForce;
	}
}
