using UnityEngine;

public abstract class PowerupBehaviour: ScriptableObject
{
	protected PowerupUser _powerupUser;

	public virtual void Init(PowerupUser user)
	{
		_powerupUser = user;
	}

	public abstract void Apply();

	public abstract PowerupBehaviour GetCopy();
}
