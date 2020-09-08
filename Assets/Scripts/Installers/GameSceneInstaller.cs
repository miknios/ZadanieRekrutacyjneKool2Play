using Enemy.TargetFollowing;
using Zenject;

namespace Installers
{
	public class GameSceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<IEnemyTargetRegistry>().To<EnemyTargetRegistry>().AsSingle().NonLazy();
		}
	}
}