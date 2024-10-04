using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

namespace E02Example
{
	/**
	 * Example 4
	 */
	public partial class CE02Example_04 : CManager_Scene
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
		[Header("=====> Example 4 - Etc <=====")]
		[SerializeField] private CE02Player_04 m_oPlayer = null;

		private float m_fTime_Play = 0.0f;
		private Collider[] m_oColliders = new Collider[sbyte.MaxValue];

		[Header("=====> Example 4 - UIs <=====")]
		[SerializeField] private TMP_Text m_oTMP_UIText_Time = null;

		[Header("=====> Example 4 - Game Objects <=====")]
		[SerializeField] private GameObject m_oGameObj_UIPopup_GameOver = null;
		[SerializeField] private GameObject m_oGameObj_Bullets = null;
		#endregion // 변수

		#region 프로퍼티
		public EState State_Cur { get; private set; } = EState.PLAY;
		public CE02Player_04 Player => m_oPlayer;

		public GameObject GameObj_Bullets => m_oGameObj_Bullets;
		public List<CE02Bullet_04> ListBullets { get; private set; } = new List<CE02Bullet_04>();
		#endregion // 프로퍼티

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();

			/*
			 * GameObject.SetActive 메서드는 게임 객체를 활성 여부를 변경하는 역할을 수행한다.
			 * (즉, 해당 메서드를 활용하면 특정 순간에 게임 객체를 활성 및 비활성화하는 것이
			 * 가능하다.)
			 */
			m_oGameObj_UIPopup_GameOver.SetActive(false);
		}

		/** 상태를 갱신한다 */
		public override void Update()
		{
			base.Update();

			// 상태 갱신이 불가능 할 경우
			if(this.State_Cur != EState.PLAY)
			{
				return;
			}

			m_fTime_Play += Time.deltaTime;
			m_oTMP_UIText_Time.text = $"{m_fTime_Play:0.00}";

			m_oPlayer.OnUpdate(Time.deltaTime);

			for(int i = 0; i < this.ListBullets.Count; ++i)
			{
				this.ListBullets[i].OnUpdate(Time.deltaTime);
			}
		}

		/** 상태를 갱신한다 */
		public void FixedUpdate()
		{
			var stPosA = m_oPlayer.transform.localPosition + (Vector3.up * 150.0f);
			stPosA = stPosA.ExToWorld(m_oPlayer.transform.parent.gameObject);

			var stPosB = m_oPlayer.transform.localPosition + (Vector3.down * 150.0f);
			stPosB = stPosB.ExToWorld(m_oPlayer.transform.parent.gameObject);

			/*
			 * Physics.Overlap 계열 메서드는 중첩 된 충돌체를 검사하는 역할을 수행한다. (즉,
			 * 해당 메서드를 활용하면 월드 상에 존재하는 게임 객체 중 중첩 된 게임 객체를 판별하는
			 * 것이 가능하다.)
			 * 
			 * 단, Physics.Overlap 계열 메서드의 입력 데이터는 월드 공간을 기준으로 한 위치 및
			 * 크기 등을 명시해야한다. (즉, 로컬 공간 상의 데이터를 명시 할 경우 잘못된 결과가
			 * 만들어진다는 것을 알 수 있다.)
			 */
			int nNumColliders = Physics.OverlapCapsuleNonAlloc(stPosA,
				stPosB, 0.75f, m_oColliders);

			for(int i = 0; i < nNumColliders; ++i)
			{
				// 충돌했을 경우
				if(m_oColliders[i].transform.parent.name.Equals("Bullet"))
				{
					this.State_Cur = EState.GAME_OVER;
					m_oGameObj_UIPopup_GameOver.SetActive(true);

					break;
				}
			}
		}
		#endregion // 함수
	}
}
