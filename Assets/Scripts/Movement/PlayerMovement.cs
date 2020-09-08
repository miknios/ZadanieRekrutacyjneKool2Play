using UnityEngine;

namespace Movement
{
	public class PlayerMovement : MonoBehaviour
	{
		private const string HORIZONTAL_AXIS_NAME = "Horizontal";
		private const string VERTICAL_AXIS_NAME = "Vertical";
	
		[SerializeField] private float speed = 10f;
		[SerializeField, Range(0, 1)] private float smoothing = 0.65f;
		[SerializeField] private new Rigidbody rigidbody = null;

		private Vector3 currentMoveVector;
		private Vector3 inputAxisVector;

		// TODO: change to be relative to camera rotation
		private void FixedUpdate()
		{
			inputAxisVector.x = Input.GetAxisRaw(HORIZONTAL_AXIS_NAME);
			inputAxisVector.z = Input.GetAxisRaw(VERTICAL_AXIS_NAME);
		
			UpdateMoveVector();
			UpdatePosition();
		}

		private void UpdateMoveVector()
		{
			Vector3 normalized = inputAxisVector.normalized;
			currentMoveVector = Vector3.Lerp(currentMoveVector, normalized, 1 - smoothing);
		}

		private void UpdatePosition()
		{
			Vector3 targetPos = transform.position + currentMoveVector * (speed * Time.deltaTime);
			rigidbody.MovePosition(targetPos);
		}
	}
}