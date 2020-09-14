using UniRx;

namespace DataProvider
{
	public interface IActiveGunData
	{
		ReactiveProperty<GunConfig> ActiveGunConfig { get; }
	}
}