using UnityEngine;

public class TargetsDestroyer : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);
	}
}
