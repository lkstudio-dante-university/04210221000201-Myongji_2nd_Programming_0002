using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 충돌 전달자
 */
public partial class CDispatcher_Trigger : CComponent
{
	#region 프로퍼티
	public System.Action<CDispatcher_Trigger, Collider> Callback_Begin { get; private set; } = null;
	public System.Action<CDispatcher_Trigger, Collider> Callback_Stay { get; private set; } = null;
	public System.Action<CDispatcher_Trigger, Collider> Callback_End { get; private set; } = null;
	#endregion // 프로퍼티

	#region 함수
	/** 충돌이 시작되었을 경우 */
	public void OnTriggerEnter(Collider a_oCollider)
	{
		this.Callback_Begin?.Invoke(this, a_oCollider);
	}

	/** 충돌이 진행 중 일 경우 */
	public void OnTriggerStay(Collider a_oCollider)
	{
		this.Callback_Stay?.Invoke(this, a_oCollider);
	}

	/** 충돌이 종료되었을 경우 */
	public void OnTriggerExit(Collider a_oCollider)
	{
		this.Callback_End?.Invoke(this, a_oCollider);
	}
	#endregion // 함수

	#region 접근 함수
	/** 시작 콜백을 변경한다 */
	public void SetCallback_Begin(System.Action<CDispatcher_Trigger, Collider> a_oCallback)
	{
		this.Callback_Begin = a_oCallback;
	}

	/** 진행 콜백을 변경한다 */
	public void SetCallback_Stay(System.Action<CDispatcher_Trigger, Collider> a_oCallback)
	{
		this.Callback_Stay = a_oCallback;
	}

	/** 종료 콜백을 변경한다 */
	public void SetCallback_End(System.Action<CDispatcher_Trigger, Collider> a_oCallback)
	{
		this.Callback_End = a_oCallback;
	}
	#endregion // 접근 함수
}

/**
 * 충돌 전달자 - 2 차원
 */
public partial class CDispatcher_Trigger : CComponent
{
	#region 프로퍼티
	public System.Action<CDispatcher_Trigger, Collider2D> Callback2D_Begin { get; private set; } = null;
	public System.Action<CDispatcher_Trigger, Collider2D> Callback2D_Stay { get; private set; } = null;
	public System.Action<CDispatcher_Trigger, Collider2D> Callback2D_End { get; private set; } = null;
	#endregion // 프로퍼티

	#region 함수
	/** 충돌이 시작되었을 경우 */
	public void OnTriggerEnter2D(Collider2D a_oCollider)
	{
		this.Callback2D_Begin?.Invoke(this, a_oCollider);
	}

	/** 충돌이 진행 중 일 경우 */
	public void OnTriggerStay2D(Collider2D a_oCollider)
	{
		this.Callback2D_Stay?.Invoke(this, a_oCollider);
	}

	/** 충돌이 종료되었을 경우 */
	public void OnTriggerExit2D(Collider2D a_oCollider)
	{
		this.Callback2D_End?.Invoke(this, a_oCollider);
	}
	#endregion // 함수

	#region 접근 함수
	/** 시작 콜백을 변경한다 */
	public void SetCallback_Begin(System.Action<CDispatcher_Trigger, Collider2D> a_oCallback)
	{
		this.Callback2D_Begin = a_oCallback;
	}

	/** 진행 콜백을 변경한다 */
	public void SetCallback_Stay(System.Action<CDispatcher_Trigger, Collider2D> a_oCallback)
	{
		this.Callback2D_Stay = a_oCallback;
	}

	/** 종료 콜백을 변경한다 */
	public void SetCallback_End(System.Action<CDispatcher_Trigger, Collider2D> a_oCallback)
	{
		this.Callback2D_End = a_oCallback;
	}
	#endregion // 접근 함수
}
