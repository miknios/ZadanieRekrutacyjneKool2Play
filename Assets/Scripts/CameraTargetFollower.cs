using UnityEngine;

namespace DefaultNamespace
{
	public class CameraTargetFollower : MonoBehaviour
	{
		[SerializeField] private Transform targetTransform;
		[SerializeField] private float distance = 10;
		
		private Vector3 _fromTargetTranslation;
		
		private void Start()
		{
			_fromTargetTranslation = -transform.forward * distance;
		}

		private void FixedUpdate()
		{
			transform.position = targetTransform.position + _fromTargetTranslation;
		}
	}
}