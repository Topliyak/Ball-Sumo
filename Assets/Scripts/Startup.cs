using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Startup : MonoBehaviour
{
	[SerializeField] private UnityEvent _started;

	public UnityEvent started => _started;

	public void Start()
	{
		_started.Invoke();
	}
}
