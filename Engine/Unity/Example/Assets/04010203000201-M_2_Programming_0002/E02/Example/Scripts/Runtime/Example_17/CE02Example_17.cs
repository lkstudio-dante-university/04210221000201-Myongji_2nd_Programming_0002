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
		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
			CE02Storage_Result_17.Inst.Reset();
		}
		#endregion // 함수
	}
}
