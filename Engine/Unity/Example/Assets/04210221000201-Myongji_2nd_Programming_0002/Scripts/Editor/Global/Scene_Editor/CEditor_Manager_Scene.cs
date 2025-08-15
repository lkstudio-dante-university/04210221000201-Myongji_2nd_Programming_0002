using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

/**
 * 에디터 씬 관리자
 */
[InitializeOnLoad]
public static partial class CEditor_Manager_Scene
{
	#region 클래스 변수
	private static double m_dblTime_Update = 0.0;
	#endregion // 클래스 변수

	#region 클래스 함수
	/** 생성자 */
	static CEditor_Manager_Scene()
	{
		// 플레이 모드 일 경우
		if(EditorApplication.isPlaying)
		{
			return;
		}

		CEditor_Manager_Scene.m_dblTime_Update = EditorApplication.timeSinceStartup;

		EditorApplication.update -= CEditor_Manager_Scene.Update;
		EditorApplication.update += CEditor_Manager_Scene.Update;
	}

	/** 상태를 갱신한다 */
	private static void Update()
	{
		// 플레이 모드 일 경우
		if(EditorApplication.isPlaying)
		{
			return;
		}

		double dblTime_UpdateDelta = EditorApplication.timeSinceStartup - CEditor_Manager_Scene.m_dblTime_Update;

		// 상태 갱신이 불가능 할 경우
		if(dblTime_UpdateDelta.ExIsLess(1.0))
		{
			return;
		}

		CEditor_Manager_Scene.m_dblTime_Update = EditorApplication.timeSinceStartup;
		
		Func.EnumerateGameObjects_Root((a_oGameObj) =>
		{
			CEditor_Manager_Scene.SetupManager_Scene(a_oGameObj);
		});
	}

	/** 씬 관리자를 설정한다 */
	private static void SetupManager_Scene(GameObject a_oGameObj)
	{
		// 관리자 설정이 불가능 할 경우
		if(!a_oGameObj.TryGetComponent(out CManager_Scene oManager_Scene))
		{
			return;
		}

		oManager_Scene.SetupScene(true);
		oManager_Scene.SetupScene(false);
	}
	#endregion // 클래스 함수
}
#endif // #if UNITY_EDITOR
