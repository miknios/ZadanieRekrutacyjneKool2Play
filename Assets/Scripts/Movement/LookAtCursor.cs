using UnityEngine;
using LayerMask = Generic.LayerMask;

namespace Movement
{
	public class LookAtCursor : MonoBehaviour
	{
		[SerializeField] private new Rigidbody rigidbody = null;
	
		private RaycastHit[] raycastHitBuffer = new RaycastHit[1];
	
		private void FixedUpdate()
		{
			// TODO: change Camera.main to something else
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.RaycastNonAlloc(ray, raycastHitBuffer, float.MaxValue, LayerMask.GROUND);
			Vector3 target = raycastHitBuffer[0].point;
			Vector3 position = transform.position;
			target.y = position.y;
		
			rigidbody.MoveRotation(Quaternion.LookRotation(target - position));
		}
	}
}