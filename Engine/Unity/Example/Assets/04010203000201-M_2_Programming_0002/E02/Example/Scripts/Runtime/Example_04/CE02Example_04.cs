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
		[Header("=====> Example 4 - Game Objects <=====")]
		[SerializeField] private CE02Player_04 m_oPlayer = null;
		#endregion // 변수

		#region 프로퍼티
		public EState State_Cur { get; private set; } = EState.PLAY;
		public List<CE02Bullet_04> ListBullets { get; private set; } = new List<CE02Bullet_04>();
		#endregion // 프로퍼티

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
			m_oPlayer.OnUpdate(Time.deltaTime);

			for(int i = 0; i < this.ListBullets.Count; ++i)
			{
				this.ListBullets[i].OnUpdate(Time.deltaTime);
			}
		}

		/** 상태를 갱신한다 */
		public override void LateUpdate()
		{
			base.LateUpdate();

			for(int i = 0; i < this.ListBullets.Count; ++i)
			{
				// Do Something
			}
		}
		#endregion // 함수
	}
}
