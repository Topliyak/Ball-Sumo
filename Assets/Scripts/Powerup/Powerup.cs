using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
	[SerializeField] private PowerupBehaviour _behaviour;
	[SerializeField] private float _duration_sec;

	public PowerupBehaviour behaviour => _behaviour.GetCopy();

	public float duration_sec => _duration_sec;

	public void Destroy() => Destroy(gameObject);
}
