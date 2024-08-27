using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E01
{
	/**
	 * Example 2
	 */
	public class CE01Example_02 : MonoBehaviour
	{
		#region 변수
		[Header("=====> Example - Etc <=====")]
		[SerializeField] private float m_fSpeedPlayerMove = 0.0f;
		[SerializeField] private float m_fSpeedPlayerRotate = 0.0f;

		private Animation m_oAnimPlayer = null;

		[Header("=====> Example - Game Objects <=====")]
		[SerializeField] private GameObject m_oPlayer = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public void Awake()
		{
			m_oAnimPlayer = m_oPlayer.GetComponent<Animation>();
		}

		/** 상태를 갱신한다 */
		public void Update()
		{
			float fMouseX = Input.GetAxis("Mouse X");
			float fVertical = Input.GetAxis("Vertical");
			float fHorizontal = Input.GetAxis("Horizontal");

			var stDirection = (m_oPlayer.transform.forward * fVertical) +
				(m_oPlayer.transform.right * fHorizontal);

			stDirection = (stDirection.magnitude <= 1.0f) ? stDirection : stDirection.normalized;
			m_oPlayer.transform.position += stDirection * m_fSpeedPlayerMove * Time.deltaTime;

			// 마우스 버튼을 눌렀을 경우
			if(Input.GetMouseButton(1))
			{
				m_oPlayer.transform.Rotate(Vector3.up, 
					fMouseX * m_fSpeedPlayerRotate * Time.deltaTime, Space.World);
			}

			// 대기 상태 일 경우
			if(stDirection.magnitude <= 0.0f)
			{
				m_oAnimPlayer.CrossFade("Idle");
			}
			else
			{
				// 상 / 하 키를 눌렀을 경우
				if(fVertical != 0.0f)
				{
					m_oAnimPlayer.CrossFade((fVertical > 0.0f) ? "RunF" : "RunB");
				}
				else
				{
					m_oAnimPlayer.CrossFade((fHorizontal < 0.0f) ? "RunL" : "RunR");
				}
			}
		}
		#endregion // 함수
	}
}
