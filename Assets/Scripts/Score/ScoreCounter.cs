using UniRx;

namespace Score
{
	public class ScoreCounter
	{
		private IReactiveProperty<int> _currentScore;
		public IReadOnlyReactiveProperty<int> CurrentScore => _currentScore;

		public ScoreCounter()
		{
			_currentScore = new ReactiveProperty<int>(0);
		}

		public void Increment(int amount = 1)
		{
			_currentScore.Value += amount;
		}
	}
}