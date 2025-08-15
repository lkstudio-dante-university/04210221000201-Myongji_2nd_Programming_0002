using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

namespace E02Example
{
	/**
	 * Example 18
	 */
	public partial class CE02Example_18 : CManager_Scene
	{
		#region 변수
		[Header("=====> Example 18 - UIs <=====")]
		[SerializeField] private TMP_Text m_oTMP_UIText_Result = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
			m_oTMP_UIText_Result.text = $"Score : {CE02Storage_Result_17.Inst.Score}";
		}

		/** 다시하기 버튼을 눌렀을 경우 */
		public void OnTouchBtn_Retry()
		{
			CLoader_Scene.Inst.LoadScene(KDefine.G_N_SCENE_E02_EXAMPLE_17);
		}

		/** 그만두기 버튼을 눌렀을 경우 */
		public void OnTouchBtn_Leave()
		{
			CLoader_Scene.Inst.LoadScene(KDefine.G_N_SCENE_E02_EXAMPLE_16);
		}
		#endregion // 함수
	}
}
