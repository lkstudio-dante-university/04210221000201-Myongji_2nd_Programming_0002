using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

/**
 * 씬 로더
 */
public partial class CLoader_Scene : CSingleton<CLoader_Scene>
{
	#region 함수
	/** 씬을 로드한다 */
	public void LoadScene(string a_oName_Scene,
		LoadSceneMode a_eSceneMode_Load = LoadSceneMode.Single)
	{
		SceneManager.LoadScene(a_oName_Scene, a_eSceneMode_Load);
	}

	/** 씬을 로드한다 */
	public void LoadScene_Async(string a_oName_Scene,
		float a_fDelay, System.Action<AsyncOperation, bool> a_oCallback, LoadSceneMode a_eSceneMode_Load = LoadSceneMode.Single)
	{
		StartCoroutine(this.CoLoadScene_Async(a_oName_Scene, 
			a_fDelay, a_oCallback, a_eSceneMode_Load));
	}

	/** 씬을 제거한다 */
	public void UnloadScene_Async(string a_oName_Scene,
		float a_fDelay, System.Action<AsyncOperation, bool> a_oCallback)
	{
		StartCoroutine(this.CoUnloadScene_Async(a_oName_Scene, a_fDelay, a_oCallback));
	}
	#endregion // 함수
}

/**
 * 씬 로더 - 코루틴
 */
public partial class CLoader_Scene : CSingleton<CLoader_Scene>
{
	#region 함수
	/** 씬을 로드한다 */
	public IEnumerator CoLoadScene_Async(string a_oName_Scene,
		float a_fDelay, System.Action<AsyncOperation, bool> a_oCallback, LoadSceneMode a_eSceneMode_Load)
	{
		yield return new WaitForSeconds(a_fDelay);
		var oOperation_Async = SceneManager.LoadSceneAsync(a_oName_Scene, a_eSceneMode_Load);

		yield return CManager_Task.Inst.CoWaitOperation_Async(oOperation_Async, a_oCallback);
	}

	/** 씬을 제거한다 */
	public IEnumerator CoUnloadScene_Async(string a_oName_Scene,
		float a_fDelay, System.Action<AsyncOperation, bool> a_oCallback)
	{
		yield return new WaitForSeconds(a_fDelay);

		var oOperation_Async = SceneManager.UnloadSceneAsync(a_oName_Scene,
			UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);

		yield return CManager_Task.Inst.CoWaitOperation_Async(oOperation_Async, a_oCallback);
	}
	#endregion // 함수
}
