using Shooting.Guns;
using UniRx;

namespace DataProvider
{
	public interface IActiveWeaponData
	{
		ReactiveProperty<WeaponConfig> ActiveWeaponConfig { get; }
	}
}