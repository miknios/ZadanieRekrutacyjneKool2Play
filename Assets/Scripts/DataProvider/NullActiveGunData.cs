using UniRx;
using UnityEngine;

namespace DataProvider
{
	public class NullActiveGunData : IActiveGunData
	{
		public ReactiveProperty<GunConfig> ActiveGunConfig { get; } =
			new ReactiveProperty<GunConfig>(ScriptableObject.CreateInstance<GunConfig>());
	}
}