using Shooting.Guns.Components;
using UniRx;
using UnityEngine;

namespace Shooting
{
	[RequireComponent(typeof(WeaponHandle))]
	public class PlayerGunSwitcher : MonoBehaviour
	{
		private void Awake()
		{
			WeaponHandle weaponHandle = GetComponent<WeaponHandle>();
		
			Observable.EveryUpdate()
				.Where(_ => Input.GetKeyDown(KeyCode.Q))
				.Subscribe(_ => weaponHandle.ToggleWeapon());
		}
	}
}