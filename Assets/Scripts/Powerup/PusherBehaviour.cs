using UnityEngine;

[CreateAssetMenu(menuName = "PowerupBehaviour/Pusher")]
public class PusherBehaviour : PowerupBehaviour
{
	private float _powerupUserRadius;

	[SerializeField] private LayerMask _enemiesLayer;
	[SerializeField] private float _pushForce;

	public override void Init(PowerupUser user)
	{
		base.Init(user);
		_powerupUserRadius = user.GetComponent<SphereCollider>().radius * user.transform.localScale.x;
	}

	public override void Apply()
	{
		var enemies = Physics.OverlapSphere(_powerupUser.transform.position, _powerupUserRadius, _enemiesLayer);

		foreach (var enemy in enemies)
		{
			enemy.GetComponent<ImpulceReceiver>()?.ApplyImpulce(_powerupUser.transform.position, _pushForce);
		}
	}

	public override PowerupBehaviour GetCopy() 
	{
		var pusherCopy = CreateInstance<PusherBehaviour>();
		pusherCopy._enemiesLayer = _enemiesLayer;
		pusherCopy._pushForce = _pushForce;

		return pusherCopy;
	}
}
