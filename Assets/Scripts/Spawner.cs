using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner<T>: MonoBehaviour where T: Object
{
	[SerializeField] private T[] _templates;
	[SerializeField] private Transform _spawnPoint;
	[SerializeField] private Transform _spawnedObjectsParent;
	[SerializeField] private Vector3 _maxOffset;

	public T[] templates => _templates;

	public Transform spawnPoint => _spawnPoint;

	public Transform spawnedObjectsParent => _spawnedObjectsParent;

	public Vector3 maxOffset => _maxOffset;

	public virtual void Spawn(int count)
	{
		for (int i = 0; i < count; i++)
		{
			var spawned = Instantiate(GetRandomTemplate(), GetRandomPosition(), 
									  _spawnPoint.rotation, _spawnedObjectsParent);
			HandleSpawnedObject(spawned);
		}
	}

	public virtual void Spawn() => Spawn(1);

	protected T GetRandomTemplate()
	{
		return _templates[Random.Range(0, _templates.Length)];
	}

	protected Vector3 GetRandomPosition()
	{
		float xOffset = Random.Range(-_maxOffset.x, _maxOffset.x);
		float yOffset = Random.Range(-_maxOffset.y, _maxOffset.y);
		float zOffset = Random.Range(-_maxOffset.z, _maxOffset.z);

		return _spawnPoint.TransformDirection(xOffset, yOffset, zOffset);
	}

	protected virtual void HandleSpawnedObject(T spawned)
	{
		//
	}
}
