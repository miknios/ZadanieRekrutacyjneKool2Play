using Cinemachine;
using Installers;
using Shooting.Guns.Components;
using UnityEngine;
using Zenject;

namespace Shooting.Guns.Initialization
{
	[RequireComponent(typeof(WeaponHandle))]
	public class PlayerWeaponInitializer : MonoBehaviour
	{
		[SerializeField] private PlayerInitialWeaponSetup playerInitialWeaponSetup = null;

		private CinemachineDataProvider _cinemachineDataProvider;

		[Inject]
		public void ConstructWithInjection(CinemachineDataProvider cinemachineDataProvider)
		{
			_cinemachineDataProvider = cinemachineDataProvider;
		}
		
		private void Awake()
		{
			WeaponHandle weaponHandle = GetComponent<WeaponHandle>();
			foreach (var weaponConfig in playerInitialWeaponSetup.Weapons)
			{
				Weapon newWeapon = WeaponObjectCreator.Create(weaponConfig);
				AddImpulseSource(newWeapon, weaponConfig);
				weaponHandle.AttachNewWeapon(newWeapon);
			}

			weaponHandle.Initialize();
		}

		private void AddImpulseSource(Weapon weapon, WeaponConfig weaponConfig)
		{
			var impulseDef = new CinemachineImpulseDefinition();
			impulseDef.m_RawSignal = _cinemachineDataProvider.DefaultCinemachineFixedSignal;
			impulseDef.m_AmplitudeGain = weaponConfig.visualImpact;
			impulseDef.m_FrequencyGain = 7;
			
			var impulseSource = weapon.gameObject.AddComponent<CinemachineImpulseSource>();
			impulseSource.m_ImpulseDefinition = impulseDef;
			weapon.AddImpulseSource(impulseSource);
		}
	}
}