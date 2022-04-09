using UnityEngine;
using UnityEngine.Events;

public class OverPlatformChecker : MonoBehaviour
{
	private SphereCollider _sphereCollider;

	[SerializeField] private float _rayDistance;
	[SerializeField] private LayerMask _layerMask;

	[Space, SerializeField] private UnityEvent<GameObject> _lostPlatformUnderEvent;
	[SerializeField] private UnityEvent<GameObject> _becameOverPlatformEvent;

	public UnityEvent<GameObject> lostPlatformUnderEvent => _lostPlatformUnderEvent;

	public UnityEvent<GameObject> becameOverPlatformEvent => _becameOverPlatformEvent;

	public bool overPlatform { get; private set; }

	private float radius => _sphereCollider.radius * transform.localScale.x;

	private void Start()
	{
		_sphereCollider = GetComponent<SphereCollider>();
	}

	private void Update()
	{
		bool wasOverPlatform = overPlatform;

		Ray ray = new Ray(transform.position, Vector3.down);
		Debug.DrawRay(ray.origin, ray.direction * _rayDistance);
		//overPlatform = Physics.SphereCast(ray, radius * 0.9f, _rayDistance, _layerMask);
		overPlatform = Physics.Raycast(ray, _rayDistance, _layerMask);

		if (wasOverPlatform && !overPlatform)
		{
			lostPlatformUnderEvent.Invoke(gameObject);
		}
		else if (!wasOverPlatform && overPlatform)
		{
			becameOverPlatformEvent.Invoke(gameObject);
		}
	}
}
