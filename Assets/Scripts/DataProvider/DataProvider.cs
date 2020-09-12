namespace DataProvider
{
	public abstract class DataProvider<T> where T : class
	{
		protected abstract T NullDataProvider { get; }
	
		private T _dataProvider;

		public void Provide(T dataProvider)
		{
			_dataProvider = dataProvider;
		}
	
		public T GetData()
		{
			return _dataProvider ?? NullDataProvider;
		}
	}
}