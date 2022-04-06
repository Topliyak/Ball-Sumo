using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ImpulceReceiver : MonoBehaviour
{
	private Rigidbody _rigidbody;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	public void ApplyImpulce(Vector3 from, float strength)
	{
		Vector3 direction = transform.position - from;
		_rigidbody.AddForce(direction.normalized * strength, ForceMode.Impulse);
	}
}
