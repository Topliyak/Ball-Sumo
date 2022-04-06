using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : Mover
{
	public Transform player { get; set; }

	private void Update()
	{
		Move(player.position - transform.position);
	}
}
