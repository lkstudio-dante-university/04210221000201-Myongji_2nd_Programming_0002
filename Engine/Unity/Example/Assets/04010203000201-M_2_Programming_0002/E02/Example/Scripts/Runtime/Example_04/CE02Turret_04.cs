using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E02Example
{
	/**
	 * 터렛
	 */
	public partial class CE02Turret_04 : CComponent
	{
		#region 변수
		[Header("=====> Turret - Game Objects <=====")]
		[SerializeField] private GameObject m_oPrefab_OriginBullet = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Start()
		{
			base.Start();
			StartCoroutine(this.CoTryShootBullet());
		}
		#endregion // 함수
	}

	/**
	 * 터렛 - 코루틴
	 */
	public partial class CE02Turret_04 : CComponent
	{
		#region 변수
		private WaitForSeconds m_oWait_Seconds = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public IEnumerator CoTryShootBullet()
		{
			float fInterval = Random.Range(1.0f, 3.0f);
			m_oWait_Seconds = new WaitForSeconds(fInterval);

			var oManager_Scene = CManager_Scene.GetManager_Scene<CE02Example_04>(KDefine.G_N_SCENE_E02_EXAMPLE_04);

			do
			{
				yield return m_oWait_Seconds;
			} while(oManager_Scene.State_Cur != CE02Example_04.EState.GAME_OVER);
		}
		#endregion // 함수
	}
}
