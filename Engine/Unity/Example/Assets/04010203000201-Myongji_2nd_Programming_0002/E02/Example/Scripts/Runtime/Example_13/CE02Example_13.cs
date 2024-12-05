//#define E_EXAMPLE_E02_EXAMPLE_13_01
#define E_EXAMPLE_E02_EXAMPLE_13_02

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

/*
 * Unity UI 제작 방법
 * - ImGUI
 * - Unity GUI
 * - UI Toolkit
 * 
 * ImGUI 란?
 * - 과거 Unity 버전에서 UI 를 제작하기 위해서 제공되는 기능을 의미한다.
 * 
 * 단, ImGUI 는 코드만을 통해서 UI 를 제작하는 것이 가능했기 때문에 특정 사용처를 제외하고는 
 * 실질적으로 UI 를 제작하는데 거의 활용되지 않는다.
 * 
 * 따라서 ImGUI 를 기반으로 UI 를 제작하고 싶다면 커스텀 에디터 UI 를 제작할때 사용하면 된다. (즉, 
 * ImGUI 는 플레이 모드 상에서 보여지는 UI 이 외에 에디터 상에서 보여지는 UI 를 제작하는것이 
 * 가능하다.)
 * 
 * Unity GUI 란?
 * - 현재 가장 많이 활용되는 UI 를 제작하는데 활용되는 기능을 의미한다.
 * 
 * 해당 방법을 통해서 UI 를 제작 할 경우 에디터 상에서 UI 를 직접 배치하고 실시간으로 결과를 확인 
 * 할 수 있기 때문에 코드를 통해서 UI 를 제작하는 ImGUI 방식에 비해 손쉽게 UI 를 제작하는 것이 
 * 가능하다.
 * 
 * UI Toolkit 이란?
 * - 차세대 UI 제작 방식을 의미하며 Unity GUI 에서 발생하는 단점들을 개선한 방법으로 Unity GUI 에 
 * 비해 좀 더 수월하게 좋은 성능 발휘하는 UI 를 제작하는 것이 가능하다.
 * 
 * 단, 해당 방식은 아직 개발이 진행 중이기 때문에 당장 상용 프로젝트 사용하는 것이 리스크가 크기 
 * 때문에 현재는 쓰이지 않고 있다.
 */
namespace E02Example
{
	/**
	 * Example 13
	 */
	public partial class CE02Example_13 : CManager_Scene
	{
		#region 변수
		[Header("=====> Example 13 - UIs <=====")]
		[SerializeField] private Text m_oUIText_02 = null;
		[SerializeField] private TMP_Text m_oTMP_UIText_02 = null;
		[SerializeField] private TMP_InputField m_oTMP_UIInputField_02 = null;

		[SerializeField] private Button m_oUIBtn_02 = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();

#if E_EXAMPLE_E02_EXAMPLE_13_02
			m_oUIText_02.text = "Legacy Text";
			m_oTMP_UIText_02.text = "Text Mesh Pro";

			m_oUIBtn_02.onClick.AddListener(this.OnTouchBtn);

			m_oTMP_UIInputField_02.onEndEdit.AddListener(this.OnEndEdit_InputField);
			m_oTMP_UIInputField_02.onValueChanged.AddListener(this.OnChangeVal_InputField);
#endif // #if E_EXAMPLE_E02_EXAMPLE_13_02
		}

#if E_EXAMPLE_E02_EXAMPLE_13_01
		/** GUI 를 그린다 */
		public void OnGUI()
		{
			var stRect = new Rect(0.0f, 0.0f, Camera.main.pixelWidth, 75.0f);

			// 버튼을 눌렀을 경우
			if(GUI.Button(stRect, "Button"))
			{
				Func.ShowLog("버튼을 눌렀습니다.");
			}
		}
#elif E_EXAMPLE_E02_EXAMPLE_13_02
		/** 버튼을 눌렀을 경우 */
		private void OnTouchBtn()
		{
			Func.ShowLog("OnTouchBtn");
		}

		/** 입력이 완료되었을 경우 */
		private void OnEndEdit_InputField(string a_oStr)
		{
			Func.ShowLog("OnEndEdit_InputField: {0}", a_oStr);
		}

		/** 입력 필드가 변경되었을 경우 */
		private void OnChangeVal_InputField(string a_oStr)
		{
			Func.ShowLog("OnChangeVal_InputField: {0}", a_oStr);
		}
#endif // #if E_EXAMPLE_E02_EXAMPLE_13_01
		#endregion // 함수
	}
}
