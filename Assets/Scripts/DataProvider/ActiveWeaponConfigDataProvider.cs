namespace DataProvider
{
	public class ActiveWeaponConfigDataProvider : DataProvider<IActiveWeaponData>
	{
		protected override IActiveWeaponData NullDataProvider { get; } = new NullActiveWeaponData();
	}
}