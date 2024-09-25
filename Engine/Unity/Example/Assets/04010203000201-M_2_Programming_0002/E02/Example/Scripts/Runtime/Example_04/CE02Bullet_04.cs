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
		#endregion // 프로퍼티

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();

			/*
			 * GetComponentInChildren 메서는 해당 메서드를 호출한 게임 객체를 포함해서
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
		}

		/** 총알을 발사한다 */
		public void Shoot(GameObject a_oGameObj_Target)
		{
			var stDirection = a_oGameObj_Target.transform.position - this.transform.position;
			stDirection.y = 0.0f;

			this.Velocity = stDirection.normalized * Random.Range(450.0f, 750.0f);
			m_oCollider.enabled = true;
		}
		#endregion // 함수
	}
}
