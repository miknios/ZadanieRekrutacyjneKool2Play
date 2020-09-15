using Shooting.Guns.Components;
using UniRx;
using UnityEngine;

namespace Shooting.Guns
{
	public class PlayerWeaponHandleTriggerer : MonoBehaviour
	{
		[SerializeField] private WeaponHandle weaponHandle = null;

		private void Start()
		{
			var inputStream = Observable.EveryUpdate()
				.Where(_ => Input.GetMouseButtonDown(0));

			inputStream.Subscribe(_ => TriggerWeaponHandle());
		}

		private void TriggerWeaponHandle()
		{
			weaponHandle.TriggerWeapon();
		}
	}
}