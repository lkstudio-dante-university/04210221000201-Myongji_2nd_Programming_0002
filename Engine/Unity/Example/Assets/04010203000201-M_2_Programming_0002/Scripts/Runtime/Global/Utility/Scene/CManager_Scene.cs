using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

/**
 * 씬 관리자
 */
public partial class CManager_Scene : CComponent
{
	#region 프로퍼티
	public Light Light_Main { get; private set; } = null;
	public Camera Camera_Main { get; private set; } = null;

	public Canvas UIsCanvas { get; private set; } = null;
	public EventSystem UIsEventSystem { get; private set; } = null;

	public GameObject UIs { get; private set; } = null;
	public GameObject UIsPopup { get; private set; } = null;

	public GameObject Objects { get; private set; } = null;
	public GameObject Objects_Static { get; private set; } = null;

	public bool IsScene_Active => CManager_Scene.ActiveScene_Name.Equals(this.gameObject.scene.name);
	#endregion // 프로퍼티

	#region 클래스 프로퍼티
	private static Dictionary<string, CManager_Scene> DictManagers_Scene { get; } = new Dictionary<string, CManager_Scene>();
	#endregion // 클래스 프로퍼티

	#region 클래스 함수
	/** 초기화 */
	public override void Awake()
	{
		base.Awake();
		CManager_Scene.DictManagers_Scene.ExAddVal(this.gameObject.scene.name, this);

		Time.fixedDeltaTime = KDefine.G_TIME_FIXED_DELTA;
		Application.targetFrameRate = KDefine.G_RATE_FRAME_DEF_TARGET;
		Physics.gravity = KDefine.G_UNIT_GRAVITY;

		/*
		 * Scene.GetRootGameObjects 메서드는 씬에 존재하는 최상단 게임 객체를 가져오는 역할을
		 * 수행한다. (즉, 해당 메서드를 활용하면 특정 씬에 존재하는 게임 객체에 접근하는 것이
		 * 가능하다.)
		 */
		var oGameObjects_Root = this.gameObject.scene.GetRootGameObjects();

		for(int i = 0; i < oGameObjects_Root.Length; ++i)
		{
			var oTrans_MainLight = oGameObjects_Root[i].transform.Find(KDefine.G_P_GAME_OBJ_LIGHT_MAIN);
			var oTrans_MainCamera = oGameObjects_Root[i].transform.Find(KDefine.G_P_GAME_OBJ_CAMERA_MAIN);

			var oTrans_UIsCanvas = oGameObjects_Root[i].transform.Find(KDefine.G_P_GAME_OBJ_UIS_CANVAS);
			var oTrans_UIsEventSystem = oGameObjects_Root[i].transform.Find(KDefine.G_P_GAME_OBJ_UIS_EVENT_SYSTEM);

			var oTrans_UIs = oGameObjects_Root[i].transform.Find(KDefine.G_P_GAME_OBJ_UIS);
			var oTrans_UIsPopup = oGameObjects_Root[i].transform.Find(KDefine.G_P_GAME_OBJ_UIS_POPUP);

			var oTrans_Objects = oGameObjects_Root[i].transform.Find(KDefine.G_P_GAME_OBJ_OBJECTS);
			var oTrans_StaticObjects = oGameObjects_Root[i].transform.Find(KDefine.G_P_GAME_OBJ_OBJECTS_STATIC);

			this.Light_Main = this.Light_Main ?? oTrans_MainLight?.GetComponent<Light>();
			this.Camera_Main = this.Camera_Main ?? oTrans_MainCamera?.GetComponent<Camera>();

			this.UIsCanvas = this.UIsCanvas ?? oTrans_UIsCanvas?.GetComponent<Canvas>();
			this.UIsEventSystem = this.UIsEventSystem ?? oTrans_UIsEventSystem?.GetComponent<EventSystem>();

			this.UIs = this.UIs ?? oTrans_UIs?.gameObject;
			this.UIsPopup = this.UIsPopup ?? oTrans_UIsPopup?.gameObject;

			this.Objects = this.Objects ?? oTrans_Objects?.gameObject;
			this.Objects_Static = this.Objects_Static ?? oTrans_StaticObjects?.gameObject;
		}

		this.Light_Main?.gameObject.SetActive(this.IsScene_Active);
		this.Camera_Main?.gameObject.SetActive(this.IsScene_Active);
		this.UIsEventSystem?.gameObject.SetActive(this.IsScene_Active);

		var oURP_CameraData_Main = this.Camera_Main?.GetUniversalAdditionalCameraData();

		// URP 카메라 데이터가 존재 할 경우
		if(oURP_CameraData_Main != null)
		{
			oURP_CameraData_Main.renderType = this.IsScene_Active ?
				CameraRenderType.Base : CameraRenderType.Overlay;
		}
	}

	/** 제거되었을 경우 */
	public override void OnDestroy()
	{
		base.OnDestroy();
		CManager_Scene.DictManagers_Scene.ExRemoveVal(this.gameObject.scene.name);
	}

	/** 상태를 갱신한다 */
	public virtual void LateUpdate()
	{
		bool bIsDown_BackKey = Input.GetKeyDown(KeyCode.Escape);
		bIsDown_BackKey = bIsDown_BackKey && !CManager_Scene.ActiveScene_Name.Equals(KDefine.G_N_SCENE_E02_EXAMPLE_00);

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

/**
 * 씬 관리자 - 액티브 씬
 */
public partial class CManager_Scene : CComponent
{
	#region 클래스 프로퍼티
	/*
	 * SceneManager.GetActiveScene 메서드는 현재 로드 된 씬 중에 주요 씬을 가져오는 역할을
	 * 수행한다. (즉, 해당 메서드를 활용하면 주요 씬에 대한 여러 정보를 가져오는 것이 가능하다.)
	 */
	public static string ActiveScene_Name => SceneManager.GetActiveScene().name;
	#endregion // 클래스 프로퍼티

	#region 제네릭 클래스 접근 함수
	/** 액티브 씬 관리자를 반환한다 */
	public static T ActiveScene_GetManager_Scene<T>() where T : CManager_Scene
	{
		return CManager_Scene.GetManager_Scene<T>(CManager_Scene.ActiveScene_Name);
	}
	#endregion // 제네릭 클래스 접근 함수
}
