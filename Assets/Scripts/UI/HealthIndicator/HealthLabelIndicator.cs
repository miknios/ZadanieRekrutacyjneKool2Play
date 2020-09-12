using TMPro;
using UnityEngine;

namespace UI.HealthIndicator
{
	public class HealthLabelIndicator : HealthIndicatorBase
	{
		[SerializeField] private TMP_Text healthLabel = null;

		protected override void UpdateIndicator(int currentHealth, int maxHealth)
		{
			healthLabel.SetText($"{currentHealth} / {maxHealth}");
		}
	}
}