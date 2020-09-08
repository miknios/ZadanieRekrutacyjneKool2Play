using System.Collections.Generic;
using UnityEngine;

namespace Health.MonoBehaviour
{
	public class DamageDealer : UnityEngine.MonoBehaviour
	{
		private class DamageableCollidedEntry
		{
			public IDamageable Damageable;
			public float TimeLeft;

			public DamageableCollidedEntry(IDamageable damageable, float time)
			{
				Damageable = damageable;
				TimeLeft = time;
			}
		}

		[SerializeField] private int damageValue = 5;
		[SerializeField] private float damageDealFrequency = 0.5f;

		private IList<DamageableCollidedEntry> damageableCollided = new List<DamageableCollidedEntry>();

		private void Update()
		{
			for (int i = damageableCollided.Count - 1; i >= 0; i--)
			{
				var entry = damageableCollided[i];
				entry.TimeLeft -= Time.deltaTime;
				if (entry.TimeLeft <= 0)
					damageableCollided.RemoveAt(i);
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (!other.TryGetComponent(out IDamageable damageable) || AlreadyCollided(damageable))
				return;

			damageable.DealDamage(damageValue);
			damageableCollided.Add(new DamageableCollidedEntry(damageable, damageDealFrequency));
		}

		private bool AlreadyCollided(IDamageable damageable)
		{
			for (int i = 0; i < damageableCollided.Count; i++)
			{
				if (damageableCollided[i].Damageable == damageable)
					return true;
			}

			return false;
		}
	}
}