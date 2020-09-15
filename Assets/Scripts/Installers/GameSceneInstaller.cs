using Cinemachine;
using DataProvider.Player;
using Enemy;
using Score;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class GameSceneInstaller : MonoInstaller
	{
		[SerializeField] private CinemachineFixedSignal defaultFixedSignal = null;
		
		public override void InstallBindings()
		{
			Container.Bind<IEnemyTargetRegistry>().To<EnemyTargetRegistry>().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<ScoreCounter>().AsSingle().NonLazy();
			Container.Bind<PlayerDataProvider>().AsSingle().NonLazy();
			Container.BindInstance(new CinemachineDataProvider(defaultFixedSignal));
		}
	}
}	