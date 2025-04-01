using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 작업 관리자
 */
public partial class CManager_Task : CSingleton<CManager_Task>
{
	// Do Something
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
		var oWait_EndOfFrame = new WaitForEndOfFrame();

		do
		{
			yield return oWait_EndOfFrame;
			a_oCallback?.Invoke(a_oOperation_Async, false);
		} while(!a_oOperation_Async.isDone);

		yield return oWait_EndOfFrame;
		a_oCallback?.Invoke(a_oOperation_Async, true);
	}
	#endregion // 함수
}
