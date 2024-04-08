using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E01
{
	/**
	 * Example 1
	 */
	public class CE01Example_01 : MonoBehaviour
	{
		#region 변수
		[Header("=====> Example 1 - Etc <=====")]
		private Animator m_oAnimator = null;

		[Header("=====> Example 1 - Game Objects <=====")]
		[SerializeField] private GameObject m_oPlayer = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public void Awake()
		{
			m_oAnimator = m_oPlayer.GetComponentInChildren<Animator>();
		}

		/** 상태를 갱신한다 */
		public void Update()
		{
			float fSpeed = 5.0f;
			float fHorizontal = Input.GetAxisRaw("Horizontal");

			m_oPlayer.transform.Translate(Vector3.right * fHorizontal * fSpeed * Time.deltaTime, Space.World);
			m_oAnimator.SetBool("IsMove", !Mathf.Approximately(fHorizontal, 0.0f));

			// 공격 키를 눌렀을 경우
			if(Input.GetKeyDown(KeyCode.Space))
			{
				m_oAnimator.SetTrigger("Attack");
			}

			// 방향 키를 눌렀을 경우
			if(!Mathf.Approximately(fHorizontal, 0.0f))
			{
				float fDirection = (fHorizontal >= 0.0f) ? 1.0f : -1.0f;
				m_oPlayer.transform.localEulerAngles = new Vector3(0.0f, 90.0f * fDirection, 0.0f);
			}
		}
		#endregion // 함수
	}
}
