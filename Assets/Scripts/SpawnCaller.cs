using UnityEngine;

public class SpawnCaller : MonoBehaviour
{
	[SerializeField] private TargetsSpawner _targetsSpawner;
	[SerializeField] private float _startSpawnDelay;

	private float _lastSpawnMoment;
	private bool _paused;

	private void Start()
	{
		_lastSpawnMoment = 0;
		_paused = false;
	}

	private void Update()
	{
		if (_paused)
			return;

		if (Time.realtimeSinceStartup - _lastSpawnMoment > _startSpawnDelay)
		{
			_targetsSpawner.Spawn();
			_lastSpawnMoment = Time.realtimeSinceStartup;
		}
	}

	public void Pause() => _paused = true;

	public void Continue() => _paused = false;
}
