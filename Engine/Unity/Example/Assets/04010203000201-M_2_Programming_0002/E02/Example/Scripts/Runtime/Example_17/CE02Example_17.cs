using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E02Example
{
	/**
	 * Example 17
	 */
	public partial class CE02Example_17 : CManager_Scene
	{
		#region 변수
		[Header("=====> Example 17 - Etc <=====")]
		[SerializeField] CE02Player_17 m_oPlayer = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
			CE02Storage_Result_17.Inst.Reset();
		}

		/** 상태를 갱신한다 */
		public override void FixedUpdate()
		{
			base.Update();
			m_oPlayer.OnUpdate(Time.fixedDeltaTime);
		}
		#endregion // 함수
	}
}
