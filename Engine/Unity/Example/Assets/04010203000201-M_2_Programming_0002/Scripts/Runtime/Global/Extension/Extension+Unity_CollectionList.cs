using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 확장 클래스 - 리스트
 */
public static partial class Extension
{
	#region 제네릭 클래스 함수
	/** 인덱스 유효 여부를 검사한다 */
	public static bool ExIsValidIdx<T>(this List<T> a_oSender, int a_nIdx)
	{
		return a_nIdx >= 0 && a_nIdx < a_oSender.Count;
	}

	/** 값을 추가한다 */
	public static void ExAddVal<T>(this List<T> a_oSender, T a_tVal)
	{
		// 값 추가가 불가능 할 경우
		if(a_oSender == null || a_oSender.Contains(a_tVal))
		{
			return;
		}

		a_oSender.Add(a_tVal);
	}

	/** 값을 제거한다 */
	public static void ExRemoveVal<T>(this List<T> a_oSender, T a_tVal)
	{
		// 값 제거가 불가능 할 경우
		if(a_oSender == null)
		{
			return;
		}

		int nIdx = a_oSender.IndexOf(a_tVal);
		a_oSender.ExRemoveValAt(nIdx);
	}

	/** 값을 제거한다 */
	public static void ExRemoveValAt<T>(this List<T> a_oSender, int a_nIdx)
	{
		// 값 제거가 불가능 할 경우
		if(a_oSender == null || !a_oSender.ExIsValidIdx(a_nIdx))
		{
			return;
		}

		a_oSender.RemoveAt(a_nIdx);
	}
	#endregion // 제네릭 클래스 함수
}
