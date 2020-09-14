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

		protected override void UpdateIndicator(int currentHealth, int maxHealth)
		{
			if(maxHealth == 0)
				return;
		
			float fillValue = (float)currentHealth / maxHealth;
			healthBarImage.DOFillAmount(fillValue, healthBarUpdateDuration);
		}
	}
}