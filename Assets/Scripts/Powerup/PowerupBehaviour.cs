using UnityEngine;

public abstract class PowerupBehaviour: MonoBehaviour
{
	private void Awake() => enabled = false;

	public void Activate() => enabled = true;

	public abstract void DuplicatePropertiesTo(PowerupBehaviour behaviour);
}
