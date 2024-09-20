using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E02Example
{
	/**
	 * Example 4
	 */
	public partial class CE02Example_04 : CManager_Scene
	{
		#region 변수
		[Header("=====> Example 4 - Game Objects <=====")]
		[SerializeField] private GameObject m_oGameObj_Player = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
		}

		/** 상태를 갱신한다 */
		public override void Update()
		{
			base.Update();
		}
		#endregion // 함수
	}
}
