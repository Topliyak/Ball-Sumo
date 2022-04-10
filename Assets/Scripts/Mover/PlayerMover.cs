using UnityEngine;

public class PlayerMover : Mover
{
	private Transform _camera;
	private Vector3 _direction;

	[SerializeField] private Joystick _joystick;

	private void OnEnable() => _joystick.joystickUpdatedEvent += OnInputUpdated;

	private void OnDisable() => _joystick.joystickUpdatedEvent -= OnInputUpdated;

	protected override void Start()
	{
		base.Start();
		_camera = Camera.main.transform;
	}

	private void FixedUpdate()
	{
		Move(_direction);
	}

	private void OnInputUpdated(Vector2 input)
	{
		_direction = _camera.TransformDirection(input.x, 0, input.y);
		_direction -= Vector3.up * _direction.y;
	}
}
