using Shooting.Guns;
using UniRx;
using UnityEngine;

namespace DataProvider
{
	public class NullActiveWeaponData : IActiveWeaponData
	{
		public ReactiveProperty<WeaponConfig> ActiveWeaponConfig { get; } =
			new ReactiveProperty<WeaponConfig>(ScriptableObject.CreateInstance<WeaponConfig>());
	}
}