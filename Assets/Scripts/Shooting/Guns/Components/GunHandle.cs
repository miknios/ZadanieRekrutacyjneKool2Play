using System.Collections.Generic;
using UnityEngine;

public class GunHandle : MonoBehaviour
{
	private int _activeGunIndex;
	private readonly IList<Gun> _attachedGuns = new List<Gun>();

	private Gun ActiveGun => _attachedGuns[_activeGunIndex];
	
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
		gun.SetActive(false);
		_attachedGuns.Add(gun);
	}

	private void ActivateGun(int gunIndex)
	{
		ActiveGun.SetActive(false);
		_activeGunIndex = gunIndex;
		ActiveGun.SetActive(true);
	}

	public void TriggerGun()
	{
		ActiveGun?.Fire();
	}
}