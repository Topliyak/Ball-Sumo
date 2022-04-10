using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : Mover
{
	public Transform player { get; set; }

	private void FixedUpdate() => Move(GetDirection());

	protected virtual Vector3 GetDirection()
	{
		Vector3 direction = player.position - transform.position;
		direction.y = 0;

		return direction;
	}
}
