using UniRx;

namespace Score
{
	public class ScoreCounter
	{
		private readonly ReactiveProperty<int> _currentScore;
		public readonly ReadOnlyReactiveProperty<int> CurrentScore;

		public ScoreCounter()
		{
			_currentScore = new ReactiveProperty<int>(0);
			CurrentScore = _currentScore.ToReadOnlyReactiveProperty();
		}

		public void Increment(int amount = 1)
		{
			_currentScore.Value += amount;
		}
	}
}