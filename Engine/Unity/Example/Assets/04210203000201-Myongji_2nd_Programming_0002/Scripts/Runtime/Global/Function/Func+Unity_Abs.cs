using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Diagnostics;
using UnityEngine.SceneManagement;

/**
 * 함수
 */
public static partial class Func
{
	#region 클래스 함수
	/**
	 * Conditional 속성은 조건부로 메서드를 활성화하는 역할을 수행한다. (즉, 해당 속성을 활용하면
	 * 특정 환경에서만 동작하는 메서드를 제작하는 것이 가능하다.)
	 * 
	 * Debug.Log 메서드는 콘솔 창에 로그를 출력 할 수 있기 때문에 개발 중에는 유용하게 사용하는
	 * 것이 가능하지만 해당 메서드를 빈번하게 사용 할 경우 성능 저하가 발생하기 때문에 릴리즈
	 * 단계에서는 반드시 해당 메서드를 제거 할 필요가 있다.
	 * 
	 * 이때 Conditional 속성을 활용하면 손쉽게 메서드를 제거하는 것이 가능하다. (즉, 디버그
	 * 환경에서만 동작하도록 조건을 설정함으로서 릴리즈 단계에서는 별도의 수정 없이 간단하게
	 * 메서드를 제거하는 것이 가능하다.)
	 */
	/** 로그를 출력한다 */
	[Conditional("DEBUG"), Conditional("DEVELOPMENT_BUILD")]
	public static void ShowLog(string a_oFmt, params object[] a_oParams)
	{
		/*
		 * Debug 클래스란?
		 * - 디버깅을 하기 위한 여러 기능을 제공하는 클래스를 의미한다. (즉, 해당 클래스를
		 * 활용하면 프로그램을 제작하면서 발생하는 여러 문제를 해결하기 위한 힌트 등을 얻는
		 * 것이 가능하다.)
		 */
		UnityEngine.Debug.LogFormat(a_oFmt, a_oParams);
	}

	/** 씬을 순회한다 */
	public static void EnumerateScenes(System.Action<Scene> a_oCallback)
	{
		for(int i = 0; i < SceneManager.sceneCount; ++i)
		{
			a_oCallback?.Invoke(SceneManager.GetSceneAt(i));
		}
	}

	/** 최상단 게임 객체를 순회한다 */
	public static void EnumerateGameObjects_Root(System.Action<GameObject> a_oCallback)
	{
		Func.EnumerateScenes((a_stScene) =>
		{
			var oGameObjects_Root = a_stScene.GetRootGameObjects();

			for(int i = 0; i < oGameObjects_Root.Length; ++i)
			{
				a_oCallback?.Invoke(oGameObjects_Root[i]);
			}
		});
	}
	#endregion // 클래스 함수
}
