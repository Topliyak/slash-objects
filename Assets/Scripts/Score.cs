using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
	[SerializeField] private UnityEvent<int> _scoreUpdatedEvent;

	public UnityEvent<int> scoreChangedEvent => _scoreUpdatedEvent;

	public int amount { get; protected set; }

	public void Increase()
	{
		amount++;
		_scoreUpdatedEvent.Invoke(amount);
	}

	public void Reset()
	{
		amount = 0;
		_scoreUpdatedEvent.Invoke(amount);
	}
}
