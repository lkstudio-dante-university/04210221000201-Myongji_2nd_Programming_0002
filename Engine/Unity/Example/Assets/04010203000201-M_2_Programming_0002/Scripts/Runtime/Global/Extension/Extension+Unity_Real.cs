using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 확장 클래스 - 실수
 */
public static partial class Extension
{
	#region 클래스 함수
	/** 같음 여부를 검사한다 */
	public static bool ExIsEquals(this float a_fSender, float a_fRhs)
	{
		/*
		 * float 자료형과 double 자료형은 부동 소수점 방식이기 때문에 값을 비교하기 위해서는
		 * 부동 소수점 오차를 감안 할 필요가 있다.
		 * 
		 * 따라서 Unity 는 오차를 감안해서 동등 여부를 검사 할 수 있는 Mathf.Approximately
		 * 메서드를 제공하며 해당 메서드를 활용하면 간단하게 float 데이터의 동등 여부를 검사하는
		 * 것이 가능하다.
		 */
		return Mathf.Approximately(a_fSender, a_fRhs);
	}

	/** 작음 여부를 검사한다 */
	public static bool ExIsLess(this float a_fSender, float a_fRhs)
	{
		/*
		 * float.Epsilon 은 부동 소수점 방식으로 인한 오차를 감안 할 수 있는 작은 값을 의미한다.
		 * (즉, float 자료형 데이터는 float.Epsilon 을 활용함으로서 부동 소수점 오차를 감안한
		 * 데이터 비교를 수행하는 것이 가능하다.)
		 */
		return a_fSender < a_fRhs - float.Epsilon;
	}

	/** 작거나 같음 여부를 검사한다 */
	public static bool ExIsLessEquals(this float a_fSender, float a_fRhs)
	{
		return a_fSender.ExIsLess(a_fRhs) || a_fSender.ExIsEquals(a_fRhs);
	}

	/** 큰 여부를 검사한다 */
	public static bool ExIsGreat(this float a_fSender, float a_fRhs)
	{
		return a_fSender > a_fRhs - float.Epsilon;
	}

	/** 크거나 같음 여부를 검사한다 */
	public static bool ExIsGreatEquals(this float a_fSender, float a_fRhs)
	{
		return a_fSender.ExIsGreat(a_fRhs) || a_fSender.ExIsEquals(a_fRhs);
	}
	#endregion // 클래스 함수
}
