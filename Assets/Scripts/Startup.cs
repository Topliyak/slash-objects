using UnityEngine;
using UnityEngine.Events;

public class Startup : MonoBehaviour
{
	[SerializeField] private UnityEvent _startEvent;

	public UnityEvent startEvent => _startEvent;

	public void Start()
	{
		_startEvent.Invoke();
	}
}
