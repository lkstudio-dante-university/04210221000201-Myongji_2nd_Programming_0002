using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 접근자
 */
public static partial class Access
{
	#region 클래스 프로퍼티
	public static Rect SafeArea
	{
		get
		{
#if UNITY_EDITOR
			return new Rect(0.0f, 0.0f, Camera.main.pixelWidth, Camera.main.pixelHeight);
#else
			return Screen.safeArea;
#endif // #if UNITY_EDITOR
		}
	}
	#endregion // 클래스 프로퍼티
}
