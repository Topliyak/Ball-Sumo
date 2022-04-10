using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmartMover : EnemyMover
{
	protected override Vector3 GetDirection()
	{
		Vector3 directionToPlayer = player.position - transform.position;
		directionToPlayer.y = 0;
		directionToPlayer.Normalize();

		Vector3 normilizedVelocity = velocity.normalized;
		normilizedVelocity.y = 0;

		Vector3 directionToPlayerAndVelocityDifference = directionToPlayer - normilizedVelocity;

		return directionToPlayer - normilizedVelocity * directionToPlayerAndVelocityDifference.magnitude;
	}
}
