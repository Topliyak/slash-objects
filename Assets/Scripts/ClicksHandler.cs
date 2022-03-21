using UnityEngine;
using UnityEngine.Events;

public class ClicksHandler : MonoBehaviour
{
	[SerializeField] private UnityEvent _badIsClickedEvent;
	[SerializeField] private UnityEvent _goodIsClickedEvent;

	public UnityEvent badIsClickedEvent => _badIsClickedEvent;

	public UnityEvent goodIsClickedEvent => _goodIsClickedEvent;

	public void Handle(Target clicked)
	{
		if (clicked.type == TargetType.Bad)
		{
			_badIsClickedEvent.Invoke();
		}
		else
		{
			_goodIsClickedEvent.Invoke();
		}
	}
}
