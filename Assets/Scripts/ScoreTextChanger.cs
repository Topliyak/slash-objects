using UnityEngine;
using UnityEngine.UI;

public class ScoreTextChanger : MonoBehaviour
{
	[SerializeField] private Text _text;

	public void OnScoreChanged(int score)
	{
		_text.text = "Score: " + System.Convert.ToString(score);
	}
}
