using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCleaner : MonoBehaviour
{
    public void Clean()
	{
		foreach (var enemy in FindObjectsOfType<Enemy>())
		{
			enemy.Kill();
		}

		foreach (var powerup in FindObjectsOfType<Powerup>())
		{
			Destroy(powerup.gameObject);
		}
	}
}
