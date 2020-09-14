using DataProvider.Player;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ActiveWeaponIndicator : MonoBehaviour
{
	[SerializeField] private Image _image = null;
	[SerializeField] private float changeScale = 1.3f;
	[SerializeField] private float scaleDuration = 0.3f;

	private PlayerDataProvider _playerDataProvider;

	[Inject]
	public void ConstructWithInjection(PlayerDataProvider playerDataProvider)
	{
		_playerDataProvider = playerDataProvider;
	}

	private void Start()
	{
		_playerDataProvider.GunConfigProvider.GetData().ActiveGunConfig
			.Subscribe(UpdateSprite);
	}

	private void UpdateSprite(GunConfig gunConfig)
	{
		_image.sprite = gunConfig.icon;
		_image.transform.DOScale(changeScale, scaleDuration)
			.From(1)
			.SetLoops(2, LoopType.Yoyo);
	}
}