using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using DG.Tweening;

namespace E02Example
{
	/**
	 * Example 19
	 */
	public partial class CE02Example_19 : CManager_Scene
	{
		#region 변수
		[Header("=====> Example 19 - Etc <=====")]
		private Tween m_oAnim_Obstacle = null;

		[Header("=====> Example 19 - Game Objects <=====")]
		[SerializeField] private GameObject m_oGameObj_Target = null;
		[SerializeField] private GameObject m_oGameObj_Obstacle = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
			var stPos_Obstacle = m_oGameObj_Obstacle.transform.localPosition;

			m_oAnim_Obstacle = m_oGameObj_Obstacle.transform.DOLocalMoveX(-stPos_Obstacle.x, 2.5f);
			m_oAnim_Obstacle.SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
		}

		/** 제거되었을 경우 */
		public override void OnDestroy()
		{
			base.OnDestroy();
			m_oAnim_Obstacle?.Kill();
		}

		/** 상태를 갱신한다 */
		public override void Update()
		{
			base.Update();

			// 마우스 버튼을 눌렀을 경우
			if(Input.GetMouseButtonDown((int)EBtn_Mouse.LEFT))
			{
				var stRay = this.Camera_Main.ScreenPointToRay(Input.mousePosition);
				
				bool bIsHit = Physics.Raycast(stRay, 
					out RaycastHit stRaycastHit);

				// 충돌이 발생하지 않았을 경우
				if(!bIsHit)
				{
					return;
				}

				var oAgent_NavMesh = m_oGameObj_Target.GetComponent<NavMeshAgent>();
				oAgent_NavMesh.SetDestination(stRaycastHit.point);
			}
		}
		#endregion // 함수
	}
}
