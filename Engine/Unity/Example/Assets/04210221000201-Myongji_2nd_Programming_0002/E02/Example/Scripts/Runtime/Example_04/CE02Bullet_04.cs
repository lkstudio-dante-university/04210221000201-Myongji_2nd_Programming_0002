using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E02Example
{
	/**
	 * 총알
	 */
	public partial class CE02Bullet_04 : CComponent
	{
		#region 변수
		private Collider m_oCollider = null;
		#endregion // 변수

		#region 프로퍼티
		public Vector3 Velocity { get; private set; } = Vector3.zero;
		public GameObject GameObj_Target { get; private set; } = null;
		#endregion // 프로퍼티

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();

			/*
			 * GetComponentInChildren 메서드는 해당 메서드를 호출한 게임 객체를 포함해서
			 * 자식 게임 객체로부터 컴포넌트를 가져오는 역할을 수행한다. (즉, 메서드를 호출한
			 * 게임 객체에 컴포넌트가 없을 경우 계층 구조를 순차적으로 순회하면서 컴포넌트를
			 * 가져온다는 것을 알 수 있다.)
			 */
			m_oCollider = this.GetComponentInChildren<Collider>();
			m_oCollider.enabled = false;
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);
			this.transform.localPosition += this.Velocity * a_fTime_Delta;

#if P02_PRACTICE_01
			var stDirection = this.GameObj_Target.transform.position - this.transform.position;
			stDirection.y = 0.0f;

			bool bIsEnable_Trace = this.Type == EType.YELLOW;
			bIsEnable_Trace = bIsEnable_Trace && Vector3.Angle(this.Velocity.normalized, stDirection.normalized).ExIsLess(12.5f);

			// 추적이 불가능 할 경우
			if(!bIsEnable_Trace)
			{
				return;
			}

			var stDirection_Next = Vector3.Lerp(this.Velocity.normalized, stDirection.normalized, 0.15f);
			stDirection_Next.y = 0.0f;

			this.Velocity = stDirection_Next.normalized * this.Velocity.magnitude;
#endif // #if P02_PRACTICE_01
		}

		/** 총알을 발사한다 */
		public void Shoot(GameObject a_oGameObj_Target)
		{
			var stDirection = a_oGameObj_Target.transform.position - this.transform.position;
			stDirection.y = 0.0f;

			this.Velocity = stDirection.normalized * Random.Range(450.0f, 750.0f);
			this.GameObj_Target = a_oGameObj_Target;

			m_oCollider.enabled = true;
		}
		#endregion // 함수

#if P02_PRACTICE_01
		/** 타입 */
		public enum EType
		{
			NONE = -1,
			GREEN,
			BLUE,
			YELLOW,
			[HideInInspector] MAX_VAL
		};

		public EType Type { get; private set; } = EType.NONE;

		/** 초기화 */
		public virtual void Init(EType a_eType)
		{
			this.Type = a_eType;
		}
#endif // #if P02_PRACTICE_01
	}
}
