namespace DataProvider
{
	public class ActiveGunConfigDataProvider : DataProvider<IActiveGunData>
	{
		protected override IActiveGunData NullDataProvider { get; } = new NullActiveGunData();
	}
}