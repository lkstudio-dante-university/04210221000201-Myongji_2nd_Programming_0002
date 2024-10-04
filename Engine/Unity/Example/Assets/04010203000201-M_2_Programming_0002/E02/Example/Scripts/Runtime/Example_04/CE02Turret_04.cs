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

#if P02_PRACTICE_01
		[SerializeField] private List<GameObject> m_oListPrefabs_OriginBullet = new List<GameObject>();
#endif // #if P02_PRACTICE_01
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Start()
		{
			base.Start();

			/*
			 * StartCoroutine 메서드는 코루틴을 시작하는 역할을 수행한다. (즉, 해당 메서드를
			 * 활용하면 비동기적인 연산을 좀 더 수월하게 처리하는 것이 가능하다.)
			 * 
			 * 코루틴이란?
			 * - 프로그램의 흐름이 반환되었던 지점부터 다시 이어서 실행 할 수 있는 메서드를
			 * 의미한다. (즉, 일반적인 메서드는 프로그램의 흐름이 반환되고 나면 다시 메서드의 
			 * 처음부터 실행 되지만 코루틴은 반환되었던 위치부터 다시 이어서 실행이 가능하다는 
			 * 차이점이 존재한다.)
			 * 
			 * 따라서 코루틴을 활용하면 여러 작업을 병렬적으로 처리하는 결과를 만들어내는 것이
			 * 가능하다. (즉, 일정 간격으로 프로그램의 흐름을 넘겨줌으로서 병렬 처리를 수행 할 수
			 * 있다.)
			 */
			StartCoroutine(this.CoTryShootBullet());
		}
		#endregion // 함수
	}

	/**
	 * 터렛 - 코루틴
	 */
	public partial class CE02Turret_04 : CComponent
	{
		#region 함수
		/** 초기화 */
		public IEnumerator CoTryShootBullet()
		{
			float fInterval = Random.Range(1.0f, 3.0f);
			var oWait_Seconds = new WaitForSeconds(fInterval);

			var oManager_Scene = CManager_Scene.GetManager_Scene<CE02Example_04>(KDefine.G_N_SCENE_E02_EXAMPLE_04);

			do
			{
#if P02_PRACTICE_01
				int nType_Min = (int)CE02Bullet_04.EType.GREEN;
				int nType_Max = (int)CE02Bullet_04.EType.MAX_VAL;

				var eType_Bullet = (CE02Bullet_04.EType)Random.Range(nType_Min, nType_Max);
				var oPrefab_OriginBullet = m_oListPrefabs_OriginBullet[(int)eType_Bullet];

				var oBullet = Factory.CreateGameObj_Clone<CE02Bullet_04>("Bullet",
					oPrefab_OriginBullet, oManager_Scene.GameObj_Bullets, false);

				oBullet.Init(eType_Bullet);
#else
				var oBullet = Factory.CreateGameObj_Clone<CE02Bullet_04>("Bullet",
					m_oPrefab_OriginBullet, oManager_Scene.GameObj_Bullets, false);
#endif // #if P02_PRACTICE_01

				oBullet.transform.position = this.transform.position;
				oBullet.Shoot(oManager_Scene.Player.gameObject);

				oManager_Scene.ListBullets.ExAddVal(oBullet);
				yield return oWait_Seconds;
			} while(oManager_Scene.State_Cur != CE02Example_04.EState.GAME_OVER);
		}
		#endregion // 함수
	}
}
