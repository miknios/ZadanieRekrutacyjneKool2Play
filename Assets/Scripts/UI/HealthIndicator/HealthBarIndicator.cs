using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HealthIndicator
{
	public class HealthBarIndicator : HealthIndicatorBase
	{
		[Header("References")] 
		[SerializeField] private Image healthBarImage = null;
	
		[Header("Parameters")] 
		[SerializeField] private float healthBarUpdateDuration = 0.3f;
		[SerializeField] private float flashDuration = 0.1f;

		private Color initialColor;

		private void Awake()
		{
			initialColor = healthBarImage.color;
		}

		protected override void UpdateIndicator(int currentHealth, int maxHealth)
		{
			if(maxHealth == 0)
				return;
		
			float targetValue = (float)currentHealth / maxHealth;
			float current = healthBarImage.fillAmount;

			if (current > targetValue)
				healthBarImage.DOColor(Color.yellow, flashDuration)
					.From(initialColor)
					.SetLoops(2, LoopType.Yoyo);
			healthBarImage.DOFillAmount(targetValue, healthBarUpdateDuration);
		}
	}
}