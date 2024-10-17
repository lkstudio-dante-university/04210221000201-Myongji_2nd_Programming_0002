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
	public BaseInputModule UIsBaseInputModule { get; private set; } = null;

	public GameObject UIs { get; private set; } = null;
	public GameObject UIsRoot { get; private set; } = null;
	public GameObject UIsPopup { get; private set; } = null;

	public GameObject Objects { get; private set; } = null;
	public GameObject Objects_Root { get; private set; } = null;
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

		this.SetupScene(true);
	}

	/** 초기화 */
	public override void Start()
	{
		base.Start();
		Time.timeScale = this.IsScene_Active ? 1.0f : Time.timeScale;

		this.SetupScene(false);
	}

	/** 제거되었을 경우 */
	public override void OnDestroy()
	{
		base.OnDestroy();
		CManager_Scene.DictManagers_Scene.ExRemoveVal(this.gameObject.scene.name);
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
		bIsDown_BackKey = bIsDown_BackKey && !CManager_Scene.ActiveScene_Name.Equals(KDefine.G_N_SCENE_E02_EXAMPLE_00);

		// 백 키를 눌렀을 경우
		if(bIsDown_BackKey)
		{
			CLoader_Scene.Inst.LoadScene(KDefine.G_N_SCENE_E02_EXAMPLE_00);
		}
	}

	/** 씬을 설정한다 */
	public virtual void SetupScene(bool a_bIsAwake)
	{
		// Awake 상태 일 경우
		if(a_bIsAwake)
		{
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

				var oGameObj_UIsRoot = oGameObjects_Root[i].name.Equals(KDefine.G_P_GAME_OBJ_UIS_ROOT) ?
					oGameObjects_Root[i] : null;

				var oGameObj_ObjectsRoot = oGameObjects_Root[i].name.Equals(KDefine.G_P_GAME_OBJ_OBJECTS_ROOT) ?
					oGameObjects_Root[i] : null;

				this.Light_Main = this.Light_Main ?? oTrans_MainLight?.GetComponent<Light>();
				this.Camera_Main = this.Camera_Main ?? oTrans_MainCamera?.GetComponent<Camera>();

				this.UIsCanvas = this.UIsCanvas ?? oTrans_UIsCanvas?.GetComponent<Canvas>();
				this.UIsEventSystem = this.UIsEventSystem ?? oTrans_UIsEventSystem?.GetComponent<EventSystem>();
				this.UIsBaseInputModule = this.UIsBaseInputModule ?? oTrans_UIsEventSystem?.GetComponent<BaseInputModule>();

				this.UIs = this.UIs ?? oTrans_UIs?.gameObject;
				this.UIsRoot = this.UIsRoot ?? oGameObj_UIsRoot;
				this.UIsPopup = this.UIsPopup ?? oTrans_UIsPopup?.gameObject;

				this.Objects = this.Objects ?? oTrans_Objects?.gameObject;
				this.Objects_Root = this.Objects_Root ?? oGameObj_ObjectsRoot;
				this.Objects_Static = this.Objects_Static ?? oTrans_StaticObjects?.gameObject;
			}

			this.SetupComponents_Unique();

			// UI 가 존재 할 경우
			if(this.UIs != null)
			{
				(this.UIs.transform as RectTransform).sizeDelta = new Vector3(KDefine.G_SIZE_WIDTH_SCREEN,
					KDefine.G_SIZE_HEIGHT_SCREEN, 0.0f);
			}

			// 최상단 객체가 존재 할 경우
			if(this.Objects_Root != null)
			{
				this.Objects_Root.transform.localScale = new Vector3(Access.Scale_UnitResolution,
					Access.Scale_UnitResolution, Access.Scale_UnitResolution);
			}

			// URP 카메라 데이터가 존재 할 경우
			if(this.Camera_Main != null && this.Camera_Main.TryGetComponent(out UniversalAdditionalCameraData oURP_CameraData))
			{
				oURP_CameraData.renderType = CameraRenderType.Base;
			}

			return;
		}

		// 광원이 존재 할 경우
		if(this.Light_Main != null)
		{
			this.Light_Main.renderMode = LightRenderMode.ForcePixel;
			this.Light_Main.gameObject.SetActive(this.IsScene_Active);
		}

		// 카메라가 존재 할 경우
		if(this.Camera_Main != null)
		{
			this.Camera_Main.gameObject.SetActive(this.IsScene_Active);
		}

		// 이벤트 시스템이 존재 할 경우
		if(this.UIsEventSystem != null)
		{
			this.UIsEventSystem.enabled = this.IsScene_Active;
			this.UIsEventSystem.gameObject.SetActive(this.IsScene_Active);
		}

		// 입력 모듈이 존재 할 경우
		if(this.UIsBaseInputModule != null)
		{
			this.UIsBaseInputModule.enabled = this.IsScene_Active;
		}
	}

	/** 고유 컴포넌트를 설정한다 */
	protected virtual void SetupComponents_Unique()
	{
		var oGameObjects = this.gameObject.scene.GetRootGameObjects();

		for(int i = 0; i < oGameObjects.Length; ++i)
		{
			var oLights = oGameObjects[i].GetComponentsInChildren<Light>(true);
			var oCameras = oGameObjects[i].GetComponentsInChildren<Camera>(true);
			var oEventSystems = oGameObjects[i].GetComponentsInChildren<EventSystem>(true);
			var oAudioListeners = oGameObjects[i].GetComponentsInChildren<AudioListener>(true);
			var oBaseInputModules = oGameObjects[i].GetComponentsInChildren<BaseInputModule>(true);

			for(int j = 0; j < oLights.Length; ++j)
			{
				oLights[j].renderMode = LightRenderMode.Auto;
			}

			for(int j = 0; j < oCameras.Length; ++j)
			{
				// URP 카메라 데이터가 없을 경우
				if(!oCameras[j].TryGetComponent(out UniversalAdditionalCameraData oURP_CameraData))
				{
					continue;
				}

				oURP_CameraData.renderType = CameraRenderType.Overlay;
			}

			for(int j = 0; j < oEventSystems.Length; ++j)
			{
				oEventSystems[j].enabled = this.IsScene_Active;
			}

			for(int j = 0; j < oAudioListeners.Length; ++j)
			{
				oAudioListeners[j].enabled = this.IsScene_Active;
			}

			for(int j = 0; j < oBaseInputModules.Length; ++j)
			{
				oBaseInputModules[j].enabled = this.IsScene_Active;
			}
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
