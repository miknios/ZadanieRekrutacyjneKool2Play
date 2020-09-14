using UnityEngine;

namespace DefaultNamespace
{
	public class CameraTargetFollower : MonoBehaviour
	{
		[SerializeField] private Transform targetTransform;
		[SerializeField] private float distance = 10;
		
		private Vector3 _fromTargetTranslation;

		public void SetNewTarget(Transform newTarget)
		{
			targetTransform = newTarget;
			_fromTargetTranslation = -transform.forward * distance;
		}
		
		private void Start()
		{
			SetNewTarget(targetTransform);
		}

		private void FixedUpdate()
		{
			if(targetTransform != null)
				transform.position = targetTransform.position + _fromTargetTranslation;
		}
	}
}