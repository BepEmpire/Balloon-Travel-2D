using System.Collections;
using UnityEngine;

public class ScoreIncreaser : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(IncreaseScoreOverTime());
	}

	private IEnumerator IncreaseScoreOverTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f);
			ScoreController.Instance.AddScore(1);
		}
	}
}