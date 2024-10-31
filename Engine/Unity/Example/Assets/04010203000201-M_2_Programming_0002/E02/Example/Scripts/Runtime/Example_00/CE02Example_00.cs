using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace E02Example
{
	/**
	 * 메뉴
	 */
	public partial class CE02Example_00 : CManager_Scene
	{
		#region 변수
		[Header("=====> Menu - Game Objects <=====")]
		[SerializeField] private GameObject m_oTMP_Prefab_UIText = null;
		[SerializeField] private GameObject m_oGameObj_UIContents_ScrollView = null;
		#endregion // 변수

		#region 프로퍼티
		public override bool IsEnable_BackBtn => false;
		#endregion // 프로퍼티

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();

			/*
			 * SceneManager 클래스란?
			 * - Unity 씬과 관련 된 여러 편리 기능을 제공하는 클래스를 의미한다. (즉, 해당 
			 * 클래스를 활용하면 씬을 전환하거나 로드 된 씬을 제거하는 등의 기능을 사용하는 것이
			 * 가능하다.)
			 */
			for(int i = 1; i < SceneManager.sceneCountInBuildSettings; ++i)
			{
				string oPath_Scene = SceneUtility.GetScenePathByBuildIndex(i);
				string oName_Scene = Path.GetFileNameWithoutExtension(oPath_Scene);

				var oText = Factory.CreateGameObj_Clone<TMP_Text>(string.Format("Text_{0:00}", i),
					m_oTMP_Prefab_UIText, m_oGameObj_UIContents_ScrollView);

				oText.text = oName_Scene;

				int nIdx = i;
				var oBtn = oText.GetComponentInChildren<Button>();

				/*
				 * 반복문 내부에서 람다와 같은 무명 메서드를 사용 할 경우 외부 변수 캡처를
				 * 조심해야 될 필요가 있다. (즉, 반복문을 종료하기 위한 변수를 캡처 할 경우 원치
				 * 않는 동작을 유발한다는 것을 알 수 있다.)
				 * 
				 * 상호 작용 이벤트 처리 메서드 설정 방법
				 * - Button 클래스와 같이 사용자와 상호 작용을 할 수 있는 UI 클래스들은 on 계열
				 * 프로퍼티를 제공하며 해당 프로퍼티를 활용하면 특정 이벤트를 처리 할 수 있는
				 * 메서드를 설정하는 것이 가능하다. (즉, UI 클래스들이 제공하는 on 계열 프로퍼티를
				 * 활용하면 Unity 에디터가 아닌 스크립트에서 동적으로 이벤트 처리 메서드를 설정 할
				 * 수 있다.)
				 */
				oBtn?.onClick.AddListener(() => this.OnTouchBtn(nIdx));
			}
		}

		/** 버튼을 눌렀을 경우 */
		private void OnTouchBtn(int a_nIdx)
		{
			string oPath_Scene = SceneUtility.GetScenePathByBuildIndex(a_nIdx);
			CLoader_Scene.Inst.LoadScene(oPath_Scene);
		}
		#endregion // 함수
	}
}
