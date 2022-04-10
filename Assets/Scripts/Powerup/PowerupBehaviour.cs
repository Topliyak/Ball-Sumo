using UnityEngine;

public abstract class PowerupBehaviour: MonoBehaviour
{
	protected virtual void Awake() => enabled = false;

	public void Activate() => enabled = true;

	public abstract void DuplicatePropertiesTo(PowerupBehaviour behaviour);
}
