using UniRx;
using UnityEngine;

public class PlayerGunHandleTriggerer : MonoBehaviour
{
	[SerializeField] private GunHandle gunHandle = null;
	
	private void Start()
	{
		// TODO: extract input for config
		var inputStream = Observable.EveryUpdate()
			.Where(_ => Input.GetMouseButtonDown(0));

		inputStream.Subscribe(_ => TriggerGunHandle());
	}

	private void TriggerGunHandle()
	{
		gunHandle.TriggerGun();
	}
}