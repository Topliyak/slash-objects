using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public enum TargetType
{
	Good, Bad, 
}

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
	[SerializeField] private ParticleSystem _explosion;
	[SerializeField] private float _minTossForce;
	[SerializeField] private float _maxTossForce;
	[SerializeField] private float _minTorqueForce;
	[SerializeField] private float _maxTorqueForce;
	[SerializeField] private float _maxOffsetX;
	[SerializeField] private TargetType _type;

	private Rigidbody _rigidbody;

	[SerializeField] private UnityEvent<Target> _targetClickedEvent;

	public UnityEvent<Target> targetClickedEvent => _targetClickedEvent;

	public TargetType type => _type;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_rigidbody.AddForce(GetRandomForce(), ForceMode.Impulse);
		_rigidbody.AddTorque(GetRandomTorque(), ForceMode.Impulse);
		transform.position = GetRandomSpawnPosition();
	}

	private Vector3 GetRandomForce() => Vector3.up * Random.Range(_minTossForce, _maxTossForce);

	private Vector3 GetRandomTorque()
	{
		return new Vector3(Random.Range(_minTorqueForce, _maxTorqueForce),
						   Random.Range(_minTorqueForce, _maxTorqueForce),
						   Random.Range(_minTorqueForce, _maxTorqueForce));
	}

	private Vector3 GetRandomSpawnPosition()
	{
		return transform.position + Vector3.right * Random.Range(-_maxOffsetX, _maxOffsetX);
	}

	private void OnMouseDown()
	{
		_targetClickedEvent.Invoke(this);

		if (_explosion != null)
		{
			_explosion.transform.parent = null;
			_explosion.Play();
		}

		Destroy(gameObject);
	}

	private void OnDestroy()
	{
		_targetClickedEvent.RemoveAllListeners();
	}
}
