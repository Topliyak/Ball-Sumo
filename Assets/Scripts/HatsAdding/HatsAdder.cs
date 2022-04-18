using UnityEngine;

public class HatsAdder : MonoBehaviour
{
	[SerializeField] private GameObjectsSpawner _hatsSpawner;
	[SerializeField] private Vector3 _hatLocalPosition;
	[SerializeField] private Vector3 _hatLocalRotation;
	[SerializeField] private Vector3 _hatLocalScale;

	public void AddHatTo(Transform hatHolder)
	{
		Transform hat = _hatsSpawner.Spawn().transform;

		hat.parent = hatHolder;
		hat.localPosition = _hatLocalPosition;
		hat.localRotation = Quaternion.Euler(_hatLocalRotation);
		hat.localScale = _hatLocalScale;
	}
}
