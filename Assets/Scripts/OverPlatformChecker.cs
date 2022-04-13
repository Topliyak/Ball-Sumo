using UnityEngine;
using UnityEngine.Events;

public class OverPlatformChecker : MonoBehaviour
{
	private SphereCollider _sphereCollider;
	private Ray _ray;

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

		_ray = new Ray();
		_ray.direction = Vector3.down;
	}

	private void Update()
	{
		bool wasOverPlatform = overPlatform;

		_ray.origin = transform.position;
		overPlatform = Physics.SphereCast(_ray, radius * 0.95f, _rayDistance, _layerMask);

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
