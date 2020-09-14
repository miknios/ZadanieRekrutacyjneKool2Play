using UnityEngine;
using LayerMask = Generic.LayerMask;

namespace Movement
{
	public class LookAtCursor : MonoBehaviour
	{
		[SerializeField] private new Rigidbody rigidbody = null;
	
		private RaycastHit[] raycastHitBuffer = new RaycastHit[1];
		private Camera _mainCamera;

		private void Awake()
		{
			_mainCamera = Camera.main;
		}

		private void FixedUpdate()
		{
			Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
			Physics.RaycastNonAlloc(ray, raycastHitBuffer, float.MaxValue, LayerMask.GROUND);
			Vector3 target = raycastHitBuffer[0].point;
			Vector3 position = transform.position;
			target.y = position.y;
		
			rigidbody.MoveRotation(Quaternion.LookRotation(target - position));
		}
	}
}