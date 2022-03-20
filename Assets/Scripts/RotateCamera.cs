using UnityEngine;

public class RotateCamera : MonoBehaviour
{
	[SerializeField] private float _speed;

	private void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		transform.Rotate(Vector3.up, horizontal * _speed * Time.deltaTime);
	}
}
