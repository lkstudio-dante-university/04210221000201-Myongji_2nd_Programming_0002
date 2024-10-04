using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 이벤트 전달자
 */
public partial class CDispatcher_Event : CComponent
{
	#region 프로퍼티
	public System.Action<CDispatcher_Event, string> Callback_AnimEvent { get; private set; } = null;
	#endregion // 프로퍼티

	#region 함수
	/** 애니메이션 이벤트를 수신했을 경우 */
	public void OnReceiveEvent_Anim(string a_oParams)
	{
		this.Callback_AnimEvent?.Invoke(this, a_oParams);
	}
	#endregion // 함수

	#region 접근 함수
	/** 애니메이션 이벤트 콜백을 변경한다 */
	public void SetCallback_AnimEvent(System.Action<CDispatcher_Event, string> a_oCallback)
	{
		this.Callback_AnimEvent = a_oCallback;
	}
	#endregion // 접근 함수
}
