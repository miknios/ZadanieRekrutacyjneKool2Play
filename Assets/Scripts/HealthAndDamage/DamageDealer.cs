using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HealthAndDamage
{
	public class DamageDealer : MonoBehaviour
	{
		private class DamageableEntry
		{
			public IDamageable Damageable;
			public float TimeLeft;

			public DamageableEntry(IDamageable damageable)
			{
				Damageable = damageable;
			}
		}

		[SerializeField] private int damageValue = 5;
		[SerializeField] private float damageDealFrequency = 0.5f;

		private HashSet<DamageableEntry> _damageableEntries = new HashSet<DamageableEntry>();

		public void Initialize(int damageValue, float damageDealFrequency)
		{
			this.damageValue = damageValue;
			this.damageDealFrequency = damageDealFrequency;
		}

		private void Update()
		{
			foreach (var damageableEntry in _damageableEntries)
			{
				damageableEntry.TimeLeft -= Time.deltaTime;
				if (damageableEntry.TimeLeft > 0) continue;

				damageableEntry.Damageable.DealDamage(damageValue);
				damageableEntry.TimeLeft = damageDealFrequency;
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!other.TryGetComponent(out IDamageable damageable) || AlreadyInEntryCollection(damageable))
				return;

			_damageableEntries.Add(new DamageableEntry(damageable));
		}

		private bool AlreadyInEntryCollection(IDamageable damageable)
		{
			return _damageableEntries.Any(entry => entry.Damageable == damageable);
		}

		private void OnTriggerExit(Collider other)
		{
			if (!other.TryGetComponent(out IDamageable damageable))
				return;

			_damageableEntries.RemoveWhere(entry => entry.Damageable == damageable);
		}
	}
}