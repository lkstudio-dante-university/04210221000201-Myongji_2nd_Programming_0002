using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

namespace E02Example
{
	/**
	 * Example 7
	 */
	public partial class CE02Example_07 : CManager_Scene
	{
		/**
		 * 상태
		 */
		public enum EState
		{
			NONE = -1,
			PLAY,
			GAME_OVER,
			[HideInInspector] MAX_VAL
		}

		#region 변수
		[Header("=====> Example 7 - Etc <=====")]
		private WaitForSeconds m_oWait_Seconds = new WaitForSeconds(2.0f);

		[Header("=====> Example 7 - UIs <=====")]
		[SerializeField] private TMP_Text m_oTMP_UIText_Score = null;

		[Header("=====> Example 7 - Game Objects <=====")]
		[SerializeField] private GameObject m_oGameObj_Player = null;
		[SerializeField] private GameObject m_oGameObj_Obstacles = null;

		[SerializeField] private GameObject m_oPrefab_OriginObstacle = null;
		#endregion // 변수

		#region 프로퍼티
		public EState State_Cur { get; private set; } = EState.PLAY;
		public List<GameObject> ListObstacles { get; private set; } = new List<GameObject>();
		#endregion // 프로퍼티

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
			CE02Storage_Result_07.Inst.Reset();

			var oRigidbody = m_oGameObj_Player.GetComponent<Rigidbody>();
			oRigidbody.useGravity = true;

			/*
			 * Rigidbody.constraints 프로퍼티는 이동 및 회전에 대한 물리 시뮬레이션을 제한하는
			 * 역할을 수행한다. (즉, 해당 프로퍼티를 통해 고정 된 속성은 물리 엔진에 의해서
			 * 시뮬레이션 되지 않는다는 것을 알 수 있다.)
			 */
			oRigidbody.constraints = RigidbodyConstraints.FreezePositionX | 
				RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

			var oDispatcher_Trigger = m_oGameObj_Player.GetComponent<CDispatcher_Trigger>();
			oDispatcher_Trigger.SetCallback_Begin(this.HandleOnTrigger_Begin);
			oDispatcher_Trigger.SetCallback_End(this.HandleOnTrigger_End);
		}

		/** 초기화 */
		public override void Start()
		{
			base.Start();
			StartCoroutine(this.CoTryCreateObstacles());
		}

		/** 상태를 갱신한다 */
		public void Update()
		{
			// 상태 갱신이 불가능 할 경우
			if(this.State_Cur != EState.PLAY)
			{
				return;
			}

			m_oTMP_UIText_Score.text = $"{CE02Storage_Result_07.Inst.Score}";

			// 스페이스 키를 눌렀을 경우
			if(Input.GetKeyDown(KeyCode.Space))
			{
				var oRigidbody = m_oGameObj_Player.GetComponent<Rigidbody>();
				oRigidbody.velocity = Vector3.zero;

				oRigidbody.AddForce(Vector3.up * 10.0f, ForceMode.VelocityChange);
			}

			for(int i = 0; i < this.ListObstacles.Count; ++i)
			{
				var oObstacle = this.ListObstacles[i];
				oObstacle.transform.localPosition += (Vector3.left * 350.0f) * Time.deltaTime;
			}
		}

		/** 충돌 시작을 처리한다 */
		private void HandleOnTrigger_Begin(CDispatcher_Trigger a_oSender, 
			Collider a_oCollider)
		{
			// 장애물이 아닐 경우
			if(this.State_Cur != EState.PLAY || !a_oCollider.CompareTag("E02Tag_Obstacle"))
			{
				return;
			}

			this.State_Cur = EState.GAME_OVER;

			var oRigidbody = m_oGameObj_Player.GetComponent<Rigidbody>();
			oRigidbody.useGravity = false;
			oRigidbody.velocity = Vector3.zero;

			CLoader_Scene.Inst.LoadScene(KDefine.G_N_SCENE_E02_EXAMPLE_08, false);
		}

		/** 충돌 종료를 처리한다 */
		private void HandleOnTrigger_End(CDispatcher_Trigger a_oSender,
			Collider a_oCollider)
		{
			// 안전 영역이 아닐 경우
			if(!a_oCollider.CompareTag("E02Tag_SafeArea"))
			{
				return;
			}

			int nScore = CE02Storage_Result_07.Inst.Score;
			CE02Storage_Result_07.Inst.SetScore(nScore + 1);
		}
		#endregion // 함수
	}

	/**
	 * Example 7 - 코루틴
	 */
	public partial class CE02Example_07 : CManager_Scene
	{
		#region 함수
		/** 장애물을 생성한다 */
		private IEnumerator CoTryCreateObstacles()
		{
			do
			{
				var oObstacle = Factory.CreateGameObj_Clone("Obstacle",
					m_oPrefab_OriginObstacle, m_oGameObj_Obstacles, false);

				oObstacle.transform.localPosition = new Vector3((KDefine.G_SIZE_WIDTH_SCREEN / 2.0f) + 150.0f,
					0.0f, 0.0f);

				this.ListObstacles.ExAddVal(oObstacle);
				yield return m_oWait_Seconds;
			} while(this.State_Cur != EState.GAME_OVER);
		}
		#endregion // 함수
	}
}
