using UnityEngine;

public class PlayerMover : Mover
{
	private Transform _camera;

	[SerializeField] private Joystick _joystick;

	private void OnEnable() => _joystick.joystickUpdatedEvent += OnInputUpdated;

	private void OnDisable() => _joystick.joystickUpdatedEvent -= OnInputUpdated;

	protected override void Start()
	{
		base.Start();
		_camera = Camera.main.transform;
	}

	private void OnInputUpdated(Vector2 input)
	{
		Vector3 direction = _camera.TransformDirection(input.x, 0, input.y);
		direction -= Vector3.up * direction.y;
		Move(direction);
	}
}
