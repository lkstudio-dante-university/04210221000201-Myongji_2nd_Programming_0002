using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 접근자
 */
public static partial class Access
{
	#region 클래스 프로퍼티
	public static Vector3 Size_DeviceScreen
	{
		get
		{
#if UNITY_EDITOR
			return new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f);
#else
			return new Vector3(Screen.width, Screen.height, 0.0f);
#endif // #if UNITY_EDITOR
		}
	}

	public static Rect SafeArea
	{
		get
		{
#if UNITY_EDITOR
			var stSafeArea = new Rect(0.0f,
				0.0f, Camera.main.pixelWidth, Camera.main.pixelHeight);

			return UnityEngine.Device.Application.isEditor ? stSafeArea : Screen.safeArea;
#else
			return Screen.safeArea;
#endif // #if UNITY_EDITOR
		}
	}

	public static float Scale_Resolution =>
		Access.Size_DeviceScreen.x.ExIsLess(Access.Size_ScreenResolution.x) ? Access.Size_DeviceScreen.x / Access.Size_ScreenResolution.x : 1.0f;

	public static float Scale_UnitResolution => KDefine.G_UNIT_SCALE * Access.Scale_Resolution;
	#endregion // 클래스 프로퍼티
}

/**
 * 접근자 - Private
 */
public static partial class Access
{
	#region 클래스 프로퍼티
	private static Vector3 Size_ScreenResolution =>
		new Vector3(Access.Size_DeviceScreen.y * (KDefine.G_SIZE_WIDTH_SCREEN / KDefine.G_SIZE_HEIGHT_SCREEN), Access.Size_DeviceScreen.y, Access.Size_DeviceScreen.z);
	#endregion // 클래스 프로퍼티
}
