using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

/**
 * 씬 관리자
 */
public partial class CManager_Scene : CComponent
{
	#region 클래스 프로퍼티
	/*
	 * SceneManager.GetActiveScene 메서드는 현재 로드 된 씬 중에 주요 씬을 가져오는 역할을
	 * 수행한다. (즉, 해당 메서드를 활용하면 주요 씬에 대한 여러 정보를 가져오는 것이 가능하다.)
	 */
	public static string Name_ActiveScene => SceneManager.GetActiveScene().name;
	private static Dictionary<string, CManager_Scene> DictManagers_Scene { get; } = new Dictionary<string, CManager_Scene>();
	#endregion // 클래스 프로퍼티

	#region 클래스 함수
	/** 초기화 */
	public override void Awake()
	{
		base.Awake();
		string oKey = this.GetType().ToString();

		CManager_Scene.DictManagers_Scene.ExAddVal(oKey, this);
	}

	/** 제거되었을 경우 */
	public override void OnDestroy()
	{
		base.OnDestroy();
		string oKey = this.GetType().ToString();

		CManager_Scene.DictManagers_Scene.ExRemoveVal(oKey);
	}

	/** 상태를 갱신한다 */
	public virtual void Update()
	{
		// Do Something
	}

	/** 상태를 갱신한다 */
	public virtual void LateUpdate()
	{
		bool bIsDown_BackKey = Input.GetKeyDown(KeyCode.Escape);
		bIsDown_BackKey = bIsDown_BackKey && !CManager_Scene.Name_ActiveScene.Equals(KDefine.G_N_SCENE_E02_EXAMPLE_00);

		// 백 키를 눌렀을 경우
		if(bIsDown_BackKey)
		{
			CLoader_Scene.Inst.LoadScene(KDefine.G_N_SCENE_E02_EXAMPLE_00);
		}
	}
	#endregion // 클래스 함수

	#region 제네릭 클래스 접근 함수
	/** 씬 관리자를 반환한다 */
	public static T GetManager_Scene<T>(string a_oName_Scene) where T : CManager_Scene
	{
		return CManager_Scene.DictManagers_Scene.ExGetVal(a_oName_Scene) as T;
	}
	#endregion // 제네릭 클래스 접근 함수
}
