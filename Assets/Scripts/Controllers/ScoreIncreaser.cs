using System.Collections;
using UnityEngine;

public class ScoreIncreaser : MonoBehaviour
{
	private void Start()
	{
		ScoreManager.Instance.ResetScore();
		StartCoroutine(IncreaseScoreOverTime());
	}

	private IEnumerator IncreaseScoreOverTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f);
			ScoreManager.Instance.AddScore(1);
		}
	}
}