using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 상수
 */
public static partial class KDefine
{
	#region 컴파일 상수
	// 기타 {
	public const int G_RATE_FRAME_DEF_TARGET = 60;
	public const int G_RATE_FRAME_MIN_TARGET = 30;

	public const float G_UNIT_SCALE = 0.01f;
	public const float G_TIME_FIXED_DELTA = 1.0f / 60.0f;
	public const float G_UNIT_PIXELS_PER_UNIT = 1.0f;

	public const float G_SIZE_WIDTH_SCREEN = 1920.0f;
	public const float G_SIZE_HEIGHT_SCREEN = 1080.0f;
	// 기타 }

	// 입력
	public const string G_N_AXIS_VERTICAL = "Vertical";
	public const string G_N_AXIS_HORIZONTAL = "Horizontal";

	// 씬 이름
	public const string G_N_SCENE_E02_EXAMPLE_00 = "E02Example_00 (Menu)";
	public const string G_N_SCENE_E02_EXAMPLE_01 = "E02Example_01 (Basic)";
	public const string G_N_SCENE_E02_EXAMPLE_02 = "E02Example_02 (Light, Camera)";
	public const string G_N_SCENE_E02_EXAMPLE_03 = "E02Example_03 (Prefab, Script - 1)";
	public const string G_N_SCENE_E02_EXAMPLE_04 = "E02Example_04 (Prefab, Script - 2)";
	public const string G_N_SCENE_E02_EXAMPLE_05 = "E02Example_05 (Physics)";
	public const string G_N_SCENE_E02_EXAMPLE_06 = "E02Example_06 (Flappy Bird - Start)";
	public const string G_N_SCENE_E02_EXAMPLE_07 = "E02Example_07 (Flappy Bird - Play)";
	public const string G_N_SCENE_E02_EXAMPLE_08 = "E02Example_08 (Flappy Bird - Result)";

	// 씬 관리자 {
	public const string G_P_GAME_OBJ_LIGHT_MAIN = "Light_Main";
	public const string G_P_GAME_OBJ_CAMERA_MAIN = "Camera_Main";

	public const string G_P_GAME_OBJ_UIS_CANVAS = "Canvas";
	public const string G_P_GAME_OBJ_UIS_EVENT_SYSTEM = "EventSystem";

	public const string G_P_GAME_OBJ_UIS = "Canvas/UIs";
	public const string G_P_GAME_OBJ_UIS_POPUP = "Canvas/UIsPopup";

	public const string G_P_GAME_OBJ_OBJECTS = "Objects";
	public const string G_P_GAME_OBJ_OBJECTS_STATIC = "Objects_Static";
	// 씬 관리자 }
	#endregion // 컴파일 상수

	#region 런타임 상수
	// 기타
	public static readonly Vector3 G_UNIT_GRAVITY = new Vector3(0.0f, -9.81f * 2.0f, 0.0f);
	#endregion // 런타임 상수
}
