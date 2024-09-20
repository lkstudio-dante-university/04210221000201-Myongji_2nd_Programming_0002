using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E02Example
{
	/**
	 * 총알
	 */
	public partial class CE02Bullet_04 : CComponent
	{
		#region 프로퍼티
		public Vector3 Velocity { get; private set; } = Vector3.zero;
		#endregion // 프로퍼티

		#region 함수
		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);
			this.transform.localPosition += this.Velocity * a_fTime_Delta;
		}
		#endregion // 함수
	}
}
