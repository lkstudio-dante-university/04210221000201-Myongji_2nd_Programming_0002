using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 작업 관리자
 */
public partial class CManager_Task : CSingleton<CManager_Task>
{
	#region 변수
	private WaitForEndOfFrame m_oWait_EndOfFrame = new WaitForEndOfFrame();
	#endregion // 변수
}

/**
 * 작업 관리자 - 코루틴
 */
public partial class CManager_Task : CSingleton<CManager_Task>
{
	#region 함수
	/** 비동기 작업을 대기한다 */
	public IEnumerator CoWaitOperation_Async(AsyncOperation a_oOperation_Async,
		System.Action<AsyncOperation, bool> a_oCallback)
	{
		do
		{
			yield return m_oWait_EndOfFrame;
			a_oCallback?.Invoke(a_oOperation_Async, false);
		} while(!a_oOperation_Async.isDone);

		yield return m_oWait_EndOfFrame;
		a_oCallback?.Invoke(a_oOperation_Async, true);
	}
	#endregion // 함수
}
