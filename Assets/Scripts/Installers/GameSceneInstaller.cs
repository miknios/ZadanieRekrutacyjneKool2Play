using DataProvider.Player;
using Enemy;
using Score;
using Zenject;

namespace Installers
{
	public class GameSceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<IEnemyTargetRegistry>().To<EnemyTargetRegistry>().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<ScoreCounter>().AsSingle().NonLazy();
			Container.Bind<PlayerDataProvider>().AsSingle().NonLazy();
		}
	}
}	