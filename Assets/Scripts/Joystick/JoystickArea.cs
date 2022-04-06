using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class JoystickArea : MonoBehaviour, IPointerDownHandler
{
	public UnityEvent<Vector2> joystickAreaDownEvent { get; } = new UnityEvent<Vector2>();

	public void OnPointerDown(PointerEventData eventData)
	{
		joystickAreaDownEvent.Invoke(eventData.position);
	}
}
