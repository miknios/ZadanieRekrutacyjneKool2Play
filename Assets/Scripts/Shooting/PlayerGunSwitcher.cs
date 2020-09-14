using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(GunHandle))]
public class PlayerGunSwitcher : MonoBehaviour
{
	private void Awake()
	{
		GunHandle gunHandle = GetComponent<GunHandle>();
		
		Observable.EveryUpdate()
			.Where(_ => Input.GetKeyDown(KeyCode.Q))
			.Subscribe(_ => gunHandle.ToggleGun());
	}

	private void SwitchGun()
	{
		
	}
}