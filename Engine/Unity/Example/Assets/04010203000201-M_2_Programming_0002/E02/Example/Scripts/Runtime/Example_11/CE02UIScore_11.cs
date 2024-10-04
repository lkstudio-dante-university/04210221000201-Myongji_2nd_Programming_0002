using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using DG.Tweening;

namespace E02Example
{
	/**
	 * UI 점수
	 */
	public partial class CE02UIScore_11 : CComponent
	{
		#region 변수
		[Header("=====> UI Score - Etc <=====")]
		private Tween m_oAnim_Show = null;

		[Header("=====> UI Score - UIs <=====")]
		[SerializeField] private TMP_Text m_oTMP_UIText_Score = null;
		#endregion // 변수

		#region 함수
		/** 제거되었을 경우 */
		public override void OnDestroy()
		{
			base.OnDestroy();

			/*
			 * DOTween 으로 생성 된 애니메이션은 Unity 렌더링 루프와 무관하게 개별적인 루프를
			 * 지니고 있으므로 게임 객체가 제거 될 경우 반드시 해당 객체와 연관 된 DOTween
			 * 애니메이션도 제거해 줄 필요가 있다. (즉, DOTween 애니메이션을 제거하지 않으면
			 * 이미 제거 된 게임 객체를 대상으로 애니메이션이 실행되기 때문에 내부적으로 문제가
			 * 발생한다는 것을 알 수 있다.)
			 */
			m_oAnim_Show?.Kill();
		}

		/** 점수를 출력한다 */
		public void ShowScore(int a_nScore)
		{
			/*
			 * Mathf.Sign 메서드는 부호를 검사하는 역할을 수행한다. (즉, 해당 메서드의 입력으로
			 * 전달 된 값이 양수 일 경우 양수 값이 반환되며 음수 일 경우 음수 값이 반환된다.)
			 */
			bool bIsIncr = Mathf.Sign(a_nScore).ExIsGreat(0.0f);

			m_oTMP_UIText_Score.text = string.Format("{0}{1}", bIsIncr ? "+" : "", a_nScore);
			m_oTMP_UIText_Score.color = bIsIncr ? Color.white : Color.red;

			float fPos_Y = m_oTMP_UIText_Score.transform.localPosition.y;

			var oAnim_Show = DOTween.Sequence();
			oAnim_Show.Append(m_oTMP_UIText_Score.transform.DOLocalMoveY(fPos_Y + 50.0f, 1.0f));
			oAnim_Show.AppendCallback(() => this.OnCompleteAnim_Show(oAnim_Show));

			Access.AssignVal(ref m_oAnim_Show, oAnim_Show);
		}

		/** 출력 애니메이션이 완료되었을 경우 */
		private void OnCompleteAnim_Show(Sequence a_oSender)
		{
			/*
			 * Destroy 메서드는 게임 객체를 제거하는 역할을 수행한다. (즉, 해당 메서드를 활용하면
			 * 특정 게임 객체를 씬에서 제거하는 것이 가능하다.)
			 * 
			 * Destroy 메서드 vs DestroyImmediate 메서드
			 * - 두 메서드 모두 게임 객체를 제거하는 역할을 수행한다.
			 * 
			 * Destroy 메서드는 게임 객체를 제거하는 메서드이지만 게임 객체를 바로 제거하는 것이
			 * 아니라 Unity 의 렌더링 루프가 모두 완료 된 후 제거되는 특징이 존재한다. (즉,
			 * 메서드 호출 직후에는 아직 게임 객체가 씬 상에 존재한다는 것을 알 수 있다.)
			 * 
			 * 반면 DestroyImmediate 메서드는 호출 즉시 게임 객체를 제거하는 차이점이 존재한다.
			 * (즉, 해당 메서드를 활용하면 호출 즉시 게임 객체가 씬에서 제거된다는 것을 알 수 
			 * 있다.)
			 * 
			 * Unity 는 렌더링 루프가 수행되면서 게임 객체를 대상으로 여러 함수들을 호출하기 때문에
			 * 렌더링 루프가 실행되는 도중에 게임 객체를 제거하는 것은 굉장히 위함한 일이다.
			 * 
			 * 따라서 호출 즉시 게임 객체를 제거하는 DestroyImmediate 메서드는 사용을 권장하지
			 * 않기 때문에 가능하면 Destroy 메서드를 활용하는 것을 추천한다. (즉, Destroy 메서드는
			 * 게임 객체를 안전하게 제거 할 수 있는 시점에 게임 객체를 제거하기 때문에 
			 * DestroyImmediate 메서드보다 안전하게 사용하는 것이 가능하다.)
			 */
			Destroy(this.gameObject);
		}
		#endregion // 함수
	}
}
