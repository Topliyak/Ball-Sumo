using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
	public UnityEvent<int> changedEvent { get; } = new UnityEvent<int>();

	public int amount { get; private set; }

	public void Increase()
	{
		amount++;
		changedEvent.Invoke(amount);
	}

	public void Reset()
	{
		amount = 1;
		changedEvent.Invoke(amount);
	}
}
