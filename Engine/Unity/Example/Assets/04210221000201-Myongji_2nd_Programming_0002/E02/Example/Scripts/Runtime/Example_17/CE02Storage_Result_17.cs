using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E02Example
{
	/**
	 * 결과 저장소
	 */
	public partial class CE02Storage_Result_17 : CSingleton<CE02Storage_Result_17>
	{
		#region 프로퍼티
		public int Score { get; private set; } = 0;
		#endregion // 프로퍼티

		#region 함수
		/** 상태를 리셋한다 */
		public override void Reset()
		{
			base.Reset();
			this.Score = 0;
		}
		#endregion // 함수

		#region 함수
		/** 점수를 변경한다 */
		public void SetScore(int a_nScore)
		{
			this.Score = a_nScore;
		}
		#endregion // 함수
	}
}
