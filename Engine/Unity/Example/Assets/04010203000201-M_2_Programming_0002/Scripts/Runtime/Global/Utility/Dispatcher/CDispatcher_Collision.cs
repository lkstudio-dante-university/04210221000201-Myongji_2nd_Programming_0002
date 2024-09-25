using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 충돌 전달자
 */
public partial class CDispatcher_Collision : CComponent
{
	#region 프로퍼티
	public System.Action<CDispatcher_Collision, Collision> Callback_Begin { get; private set; } = null;
	public System.Action<CDispatcher_Collision, Collision> Callback_Stay { get; private set; } = null;
	public System.Action<CDispatcher_Collision, Collision> Callback_End { get; private set; } = null;
	#endregion // 프로퍼티

	#region 함수
	/*
	 * OnCollision 계열 메서드란?
	 * - 강체 컴포넌트 (Rigidbody) 와 충돌체 (Collider) 를 지니고 있는 게임 객체가 다른 충돌체와
	 * 충돌했을 경우 호출되는 이벤트 메서드를 의미한다. (즉, 해당 계열 메서드를 활용하면
	 * 게임 객체 간에 충돌 처리를 좀 더 단순화시키는 것이 가능하다.)
	 * 
	 * OnTrigger 계열 메서드란?
	 * - OnCollision 계열 메서드와 같이 게임 객체가 다른 충돌체와 충돌했을 경우 호출되는 이벤트
	 * 메서드를 의미한다.
	 * 
	 * 단, OnCollision 계열 메서드 대신에 OnTrigger 계열 메서드가 호출되기 위해서는 isTrigger
	 * 옵션이 설정 된 충돌체가 존재해야한다. (즉, 충돌한 게임 객체 중 isTrigger 옵션이 설정 된 
	 * 충돌체가 존재 할 경우 OnCollision 계열 메서드 대신에 OnTrigger 계열 메서드가 호출된다는 
	 * 것을 알 수 있다.)
	 * 
	 * OnCollision 계열 메서드 vs OnTrigger 계열 메서드
	 * - OnCollision 계열 메서드는 충돌에 의한 물리 현상이 처리되는 특징이 있다. (즉, 충돌한
	 * 게임 객체들은 물리 엔진에 의해서 위치 및 회전 등에 변화가 발생한다는 것을 알 수 있다.)
	 * 
	 * 반면 OnTrigger 계열 메서드는 단순히 충돌만을 판정하기 때문에 물리 엔진에 의한 시뮬레이션이
	 * 되지 않는 차이점이 존재한다.
	 * 
	 * 따라서 단순히 충돌만을 판정하는 것이 목적이라면 OnTrigger 계열 메서드를 사용하는 것이 좀 더
	 * 성능 향상에 유리하다는 것을 알 수 있다. (즉, OnCollision 계열 메서드는 물리 현상을 
	 * 시뮬레이션하기 때문에 물리 엔진에 의해 성능 저하가 발생 할 수 있다는 것을 알 수 있다.)
	 */
	/** 충돌이 시작되었을 경우 */
	public void OnCollisionEnter(Collision a_oCollision)
	{
		this.Callback_Begin?.Invoke(this, a_oCollision);
	}

	/** 충돌이 진행 중 일 경우 */
	public void OnCollisionStay(Collision a_oCollision)
	{
		this.Callback_Stay?.Invoke(this, a_oCollision);
	}

	/** 충돌이 종료되었을 경우 */
	public void OnCollisionExit(Collision a_oCollision)
	{
		this.Callback_End?.Invoke(this, a_oCollision);
	}
	#endregion // 함수

	#region 접근 함수
	/** 시작 콜백을 변경한다 */
	public void SetCallback_Begin(System.Action<CDispatcher_Collision, Collision> a_oCallback)
	{
		this.Callback_Begin = a_oCallback;
	}

	/** 진행 콜백을 변경한다 */
	public void SetCallback_Stay(System.Action<CDispatcher_Collision, Collision> a_oCallback)
	{
		this.Callback_Stay = a_oCallback;
	}

	/** 종료 콜백을 변경한다 */
	public void SetCallback_End(System.Action<CDispatcher_Collision, Collision> a_oCallback)
	{
		this.Callback_End = a_oCallback;
	}
	#endregion // 접근 함수
}

/**
 * 충돌 전달자 - 2 차원
 */
public partial class CDispatcher_Collision : CComponent
{
	#region 프로퍼티
	public System.Action<CDispatcher_Collision, Collision2D> Callback2D_Begin { get; private set; } = null;
	public System.Action<CDispatcher_Collision, Collision2D> Callback2D_Stay { get; private set; } = null;
	public System.Action<CDispatcher_Collision, Collision2D> Callback2D_End { get; private set; } = null;
	#endregion // 프로퍼티

	#region 함수
	/** 충돌이 시작되었을 경우 */
	public void OnCollisionEnter2D(Collision2D a_oCollision)
	{
		this.Callback2D_Begin?.Invoke(this, a_oCollision);
	}

	/** 충돌이 진행 중 일 경우 */
	public void OnCollisionStay2D(Collision2D a_oCollision)
	{
		this.Callback2D_Stay?.Invoke(this, a_oCollision);
	}

	/** 충돌이 종료되었을 경우 */
	public void OnCollisionExit2D(Collision2D a_oCollision)
	{
		this.Callback2D_End?.Invoke(this, a_oCollision);
	}
	#endregion // 함수

	#region 접근 함수
	/** 시작 콜백을 변경한다 */
	public void SetCallback_Begin(System.Action<CDispatcher_Collision, Collision2D> a_oCallback)
	{
		this.Callback2D_Begin = a_oCallback;
	}

	/** 진행 콜백을 변경한다 */
	public void SetCallback_Stay(System.Action<CDispatcher_Collision, Collision2D> a_oCallback)
	{
		this.Callback2D_Stay = a_oCallback;
	}

	/** 종료 콜백을 변경한다 */
	public void SetCallback_End(System.Action<CDispatcher_Collision, Collision2D> a_oCallback)
	{
		this.Callback2D_End = a_oCallback;
	}
	#endregion // 접근 함수
}
