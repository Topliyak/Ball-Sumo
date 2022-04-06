using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortalEnemy : Mortal
{
	public void Kill() => Die();

	protected override void Die()
	{
		base.Die();
		Destroy(gameObject);
	}
}
