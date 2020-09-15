using DG.Tweening;
using HealthAndDamage;
using UnityEngine;
using UnityEngine.Rendering;

namespace Shooting.Bullets.Components
{
	public class HitscanBullet : BulletBase
	{
		private const int HITS_TAB_LENGTH = 50;
	
		private readonly RaycastHit[] _raycastHits = new RaycastHit[HITS_TAB_LENGTH];
		private readonly Vector3[] _lineVertexPositions = new Vector3[2];
		private LineRenderer _lineRenderer;

		private void Awake()
		{
			_lineRenderer = GetComponent<LineRenderer>();
		}

		public override void Initialize(BulletConfig bulletConfig)
		{
			base.Initialize(bulletConfig);
		
			LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
			lineRenderer.material = bulletConfig.material;
			lineRenderer.widthMultiplier = bulletConfig.scale;
			lineRenderer.shadowCastingMode = ShadowCastingMode.Off;
			lineRenderer.receiveShadows = false;
		}

		protected override void DoFire(Vector3 direction)
		{
			int hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHits, Range);
			Vector3 lineEnd = transform.position + direction * Range;
			for (int i = 0; i < Mathf.Min(hitCount, HITS_TAB_LENGTH); i++)
			{
				RaycastHit hit = _raycastHits[i];
				if(!hit.collider.gameObject.TryGetComponent<IDamageable>(out var damageable))
					return;
			
				
				damageable.DealDamage(Damage);
				if (!Penetrable)
				{
					lineEnd = hit.point;
					break;
				}
			}

			RenderLine(lineEnd);
		}

		private void RenderLine(Vector3 to)
		{
			_lineVertexPositions[0] = transform.position;
			_lineVertexPositions[1] = to;
			_lineRenderer.SetPositions(_lineVertexPositions);
		
			// Line renderer interprets alpha = 0.5 as fully opaque
			_lineRenderer.material.DOFade(0, 0.1f)
				.From(0.5f)
				.OnComplete(Destroy);
		}
	}
}