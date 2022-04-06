using System.Linq;
using UnityEngine;

public class ScoreIncreaser : MonoBehaviour
{
	[SerializeField] private Score _score;

	private void Update()
	{
		if (FindObjectsOfType<EnemyMover>().Any() == false)
		{
			if (FindObjectsOfType<Powerup>().Any() == false)
			{
				_score.Increase();
			}
		}
	}
}
