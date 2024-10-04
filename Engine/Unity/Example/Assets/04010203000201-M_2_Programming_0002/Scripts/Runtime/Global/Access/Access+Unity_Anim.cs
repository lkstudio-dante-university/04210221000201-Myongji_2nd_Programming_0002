using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

/**
 * 접근자 - 애니메이션
 */
public static partial class Access
{
	#region 클래스 함수
	/** 값을 변경한다 */
	public static void AssignVal(ref Tween a_rLhs, Tween a_oRhs)
	{
		a_rLhs?.Kill();
		a_rLhs = a_oRhs;
	}

	/** 값을 변경한다 */
	public static void AssignVal(ref Sequence a_rLhs, Tween a_oRhs)
	{
		a_rLhs?.Kill();
		a_rLhs = a_oRhs as Sequence;
	}
	#endregion // 클래스 함수
}
