using System.Collections.Generic;
using DataProvider;
using UniRx;
using UnityEngine;

namespace Shooting.Guns.Components
{
	public class WeaponHandle : MonoBehaviour, IActiveWeaponData
	{
		private int _activeWeaponIndex;
		private readonly IList<Weapon> _attachedWeapons = new List<Weapon>();

		private Weapon ActiveWeapon => _attachedWeapons[_activeWeaponIndex];
	
		public ReactiveProperty<WeaponConfig> ActiveWeaponConfig { get; } = new ReactiveProperty<WeaponConfig>();

		public void Initialize()
		{
			if(_attachedWeapons.Count > 0)
				ActivateWeapon(0);
		}
	
		public void AttachNewWeapon(Weapon weapon)
		{
			Transform weaponTransform = weapon.transform;
			weaponTransform.SetParent(transform);
			weaponTransform.localPosition = Vector3.zero;
			weaponTransform.localRotation = Quaternion.identity;
			
			weapon.SetActive(false);
			_attachedWeapons.Add(weapon);
		}

		private void ActivateWeapon(int weaponIndex)
		{
			ActiveWeapon.SetActive(false);
			_activeWeaponIndex = weaponIndex;
			ActiveWeapon.SetActive(true);
			ActiveWeaponConfig.Value = ActiveWeapon.Config;
		}

		public void TriggerWeapon()
		{
			ActiveWeapon?.Fire();
		}

		public void ToggleWeapon()
		{
			int weaponIndex = _activeWeaponIndex + 1;
			if (weaponIndex == _attachedWeapons.Count)
				weaponIndex = 0;
		
			ActivateWeapon(weaponIndex);
		}

	}
}