using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(RectTransform))]
public class Joystick : MonoBehaviour
{
	private RectTransform _rectTransform;

	[SerializeField] private JoystickArea _joystickArea;

	public event UnityAction<Vector2> joystickUpdatedEvent;

	public Vector2 input { get; private set; }

	public bool active { get; private set; }

	public float radius => _rectTransform.rect.width / 2;

	private Vector3 mousePosition => transform.parent.InverseTransformPoint(Input.mousePosition);

	private void OnEnable() => _joystickArea.joystickAreaDownEvent.AddListener(Activate);

	private void OnDisable() => _joystickArea.joystickAreaDownEvent.RemoveListener(Activate);

	private void Start() => _rectTransform = GetComponent<RectTransform>();

	private void Update()
	{
		if (Input.GetKey(KeyCode.Mouse0) == false)
			Deactivate();

		if (active == false)
			return;

		Vector3 mouseOffset = mousePosition - _rectTransform.localPosition;

		input = mouseOffset.magnitude > radius ? mouseOffset.normalized : mouseOffset / radius;
		joystickUpdatedEvent?.Invoke(input);
	}

	private void Activate(Vector2 position)
	{
		if (active)
			return;

		active = true;
		_rectTransform.position = position;
	}

	private void Deactivate()
	{
		active = false;

		input = Vector2.zero;
		joystickUpdatedEvent?.Invoke(input);
	}
}
