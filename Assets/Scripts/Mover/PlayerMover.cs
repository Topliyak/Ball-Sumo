using UnityEngine;

public class PlayerMover : Mover
{
	private Transform _camera;

	protected override void Start()
	{
		base.Start();
		_camera = Camera.main.transform;
	}

	private void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 direction = _camera.TransformDirection(horizontal, 0, vertical);
		direction -= Vector3.up * direction.y;
		Move(direction);
	}
}
