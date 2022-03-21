using UnityEngine;

public class TargetsSpawner : Spawner<Target>
{
	[SerializeField] private ClicksHandler _clicksHandler;

	protected override void HandleSpawnedObject(Target spawned)
	{
		spawned.targetClickedEvent.AddListener(_clicksHandler.Handle);
	}
}
