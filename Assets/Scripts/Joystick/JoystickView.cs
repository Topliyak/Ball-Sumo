using UnityEngine;

public class JoystickView : MonoBehaviour
{
	[SerializeField] private Joystick _joystick;
	[SerializeField] private RectTransform _joystickImageTransform;
	[SerializeField] private GameObject _background;

	private void OnEnable() => _joystick.joystickUpdatedEvent += OnJoystickUpdated;

	private void OnDisable() => _joystick.joystickUpdatedEvent -= OnJoystickUpdated;

	private void OnJoystickUpdated(Vector2 input)
	{
		_joystickImageTransform.localPosition = input * _joystick.radius;

		_joystickImageTransform.gameObject.SetActive(_joystick.active);
		_background.SetActive(_joystick.active);
	}
}
