using DefaultNamespace;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreLabel : MonoBehaviour
{
	[Inject]
	public void Initialize(ScoreCounter scoreCounter)
	{
		var text = GetComponent<TextMeshProUGUI>();
		scoreCounter.CurrentScore
			.Subscribe(score => text.SetText(score.ToString()));
	}
}