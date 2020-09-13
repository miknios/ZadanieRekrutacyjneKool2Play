using UnityEngine;

[RequireComponent(typeof(GunHandle))]
public class PlayerGunInitializer : MonoBehaviour
{
	[SerializeField] private PlayerInitialGunSetup playerInitialGunSetup = null;
	
	private void Awake()
	{
		GunHandle gunHandle = GetComponent<GunHandle>();
		
		foreach (var gunConfig in playerInitialGunSetup.Guns)
		{
			Gun newGun = GunObjectCreator.Create(gunConfig);
			gunHandle.AttachNewGun(newGun);
		}

		gunHandle.Initialize();
	}
}