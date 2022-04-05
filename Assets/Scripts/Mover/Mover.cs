using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
	private Rigidbody _rigidbody;

	[SerializeField] private float _force;

	protected virtual void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	public void Move(Vector3 direction)
	{
		_rigidbody.AddForce(direction.normalized * _force, ForceMode.Force);
	}

	public void Move(float x, float y, float z) => Move(new Vector3(x, y, z));
}
