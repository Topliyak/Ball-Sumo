using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Rotator : MonoBehaviour
{
	[SerializeField] private bool _paused;
	[SerializeField] private Vector3 _eulerSpeed;

	private void FixedUpdate()
	{
		if (!_paused)
			transform.rotation *= Quaternion.Euler(_eulerSpeed * Time.deltaTime);
	}

	public void Pause() => _paused = true;

	public void Continue() => _paused = false;
}
