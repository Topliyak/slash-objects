using UnityEngine;
using UnityEngine.Events;

public class GameOverChecker : MonoBehaviour
{
	[SerializeField] private UnityEvent _gameOverEvent;

	public UnityEvent gameOverEvent => _gameOverEvent;

	public void GameOver()
	{
		gameOverEvent.Invoke();
	}
}
