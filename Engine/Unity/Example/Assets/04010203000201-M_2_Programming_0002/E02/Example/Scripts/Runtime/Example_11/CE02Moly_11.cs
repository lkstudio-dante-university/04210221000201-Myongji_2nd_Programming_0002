using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E02Example
{
	/**
	 * 두더지
	 */
	public partial class CE02Moly_11 : CComponent
	{
		/**
		 * 타입
		 */
		public enum EType
		{
			NONE = -1,
			A,
			B,
			[HideInInspector] MAX_VAL
		}

		#region 변수
		[Header("=====> Moly - Etc <=====")]
		[SerializeField] private List<RuntimeAnimatorController> m_oListAControllers = new List<RuntimeAnimatorController>();

		private Animator m_oAnimator = null;
		#endregion // 변수

		#region 프로퍼티
		public bool IsOpen { get; private set; } = false;
		public EType Type { get; private set; } = EType.NONE;
		#endregion // 프로퍼티

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();

			m_oAnimator = this.GetComponentInChildren<Animator>();
			m_oAnimator.updateMode = AnimatorUpdateMode.Normal;

			var oDispatcher_Event = this.GetComponentInChildren<CDispatcher_Event>();
			oDispatcher_Event.SetCallback_AnimEvent(this.OnReceiveEvent_CloseAnim);
		}

		/** 초기화 */
		public override void Start()
		{
			base.Start();
			this.OnReceiveEvent_CloseAnim(null, string.Empty);
		}

		/** 두더지를 잡는다 */
		public void Catch()
		{
			this.IsOpen = false;

			m_oAnimator.SetTrigger("Catch");
			m_oAnimator.ResetTrigger("Open");
		}

		/** 닫힘 애니메이션 이벤트를 수신했을 경우 */
		private void OnReceiveEvent_CloseAnim(CDispatcher_Event a_oSender, string a_oParams)
		{
			this.IsOpen = false;
			StartCoroutine(this.CoTryOpen());
		}
		#endregion // 함수
	}

	/**
	 * 두더지 - 코루틴
	 */
	public partial class CE02Moly_11 : CComponent
	{
		#region 함수
		/** 두더지를 등장시킨다 */
		private IEnumerator CoTryOpen()
		{
			float fDelay = Random.Range(1.0f, 6.0f);
			yield return new WaitForSeconds(fDelay);

			this.Type = (EType)Random.Range((int)EType.A, (int)EType.MAX_VAL);
			m_oAnimator.runtimeAnimatorController = m_oListAControllers[(int)this.Type];

			m_oAnimator.SetTrigger("Open");
			m_oAnimator.ResetTrigger("Catch");

			this.IsOpen = true;
		}
		#endregion // 함수
	}
}
