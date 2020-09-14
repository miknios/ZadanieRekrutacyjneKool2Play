using DataProvider.Player;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ActiveWeaponIndicator : MonoBehaviour
{
	[SerializeField] private Image _image = null;

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
	}
}