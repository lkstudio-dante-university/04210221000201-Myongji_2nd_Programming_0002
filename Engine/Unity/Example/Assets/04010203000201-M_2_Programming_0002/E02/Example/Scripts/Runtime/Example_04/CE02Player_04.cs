using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E02Example
{
	/**
	 * 플레이어
	 */
	public class CE02Player_04 : CComponent
	{
		#region 변수
		[Header("=====> Player - Etc <=====")]
		[SerializeField] private float m_fSpeed = 0.0f;
		#endregion // 변수

		#region 함수
		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);

			float fVertical = Input.GetAxis(KDefine.G_N_AXIS_VERTICAL);
			float fHorizontal = Input.GetAxis(KDefine.G_N_AXIS_HORIZONTAL);

			var stDirection = (Vector3.forward * fVertical) + (Vector3.right * fHorizontal);

			stDirection = stDirection.magnitude.ExIsGreat(1.0f) ?
				stDirection.normalized : stDirection;

			this.transform.localPosition += stDirection * m_fSpeed * a_fTime_Delta;
		}
		#endregion // 함수
	}
}
