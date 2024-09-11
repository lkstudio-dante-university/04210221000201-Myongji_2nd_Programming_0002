using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 확장 클래스 - 딕셔너리
 */
public static partial class Extension
{
	#region 제네릭 클래스 함수
	/** 값을 추가한다 */
	public static void ExAddVal<K, V>(this Dictionary<K, V> a_oSender, K a_tKey, V a_tVal)
	{
		// 값 추가가 불가능 할 경우
		if(a_oSender == null)
		{
			return;
		}

		a_oSender.TryAdd(a_tKey, a_tVal);
	}

	/** 값을 제거한다 */
	public static void ExRemoveVal<K, V>(this Dictionary<K, V> a_oSender, K a_tKey)
	{
		// 값 제거가 불가능 할 경우
		if(a_oSender == null || !a_oSender.ContainsKey(a_tKey))
		{
			return;
		}

		a_oSender.Remove(a_tKey);
	}
	#endregion // 제네릭 클래스 함수
}
