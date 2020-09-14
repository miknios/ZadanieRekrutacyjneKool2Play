using DataProvider.Player;
using DG.Tweening;
using Shooting.Guns;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
	public class ActiveWeaponIndicator : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] private Image _image = null;
	
		[Header("Parameters")]
		[SerializeField] private float changeScale = 1.3f;
		[SerializeField] private float scaleDuration = 0.3f;

		private PlayerDataProvider _playerDataProvider;
		private bool _firstUpdate = true;

		[Inject]
		public void ConstructWithInjection(PlayerDataProvider playerDataProvider)
		{
			_playerDataProvider = playerDataProvider;
		}

		private void Start()
		{
			_playerDataProvider.WeaponConfigProvider.GetData().ActiveWeaponConfig
				.Subscribe(UpdateSprite);
		}

		private void UpdateSprite(WeaponConfig weaponConfig)
		{
			_image.sprite = weaponConfig.icon;
			if (_firstUpdate)
			{
				_firstUpdate = false;
				return;
			}
		
			_image.transform.DOScale(changeScale, scaleDuration)
				.From(1)
				.SetLoops(2, LoopType.Yoyo);
		}
	}
}