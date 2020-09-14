using System.Collections.Generic;
using DataProvider;
using UniRx;
using UnityEngine;

public class GunHandle : MonoBehaviour, IActiveGunData
{
	private int _activeGunIndex;
	private readonly IList<Gun> _attachedGuns = new List<Gun>();

	private Gun ActiveGun => _attachedGuns[_activeGunIndex];
	
	public ReactiveProperty<GunConfig> ActiveGunConfig { get; } = new ReactiveProperty<GunConfig>();

	public void Initialize()
	{
		if(_attachedGuns.Count > 0)
			ActivateGun(0);
	}
	
	public void AttachNewGun(Gun gun)
	{
		Transform gunTransform = gun.transform;
		gunTransform.SetParent(transform);
		gunTransform.localPosition = Vector3.zero;
		gunTransform.localRotation = Quaternion.identity;
		gun.SetActive(false);
		_attachedGuns.Add(gun);
	}

	private void ActivateGun(int gunIndex)
	{
		ActiveGun.SetActive(false);
		_activeGunIndex = gunIndex;
		ActiveGun.SetActive(true);
		ActiveGunConfig.Value = ActiveGun.Config;
	}

	public void TriggerGun()
	{
		ActiveGun?.Fire();
	}

	public void ToggleGun()
	{
		int gunIndex = _activeGunIndex + 1;
		if (gunIndex == _attachedGuns.Count)
			gunIndex = 0;
		
		ActivateGun(gunIndex);
	}

}