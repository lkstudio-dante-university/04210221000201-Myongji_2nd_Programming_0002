using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E01
{
	/**
	 * 카메라 제어자
	 */
	public class CE01Controller_Camera : MonoBehaviour
	{
		#region 변수
		[Header("=====> Controller Camera - Etc <=====")]
		[SerializeField] private float m_fHeight = 0.0f;
		[SerializeField] private float m_fOffset = 0.0f;
		[SerializeField] private float m_fDistance = 0.0f;

		private Camera m_oCameraMain = null;

		[Header("=====> Controller Camera - Game Objects <=====")]
		[SerializeField] private GameObject m_oFollowTarget = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public void Awake()
		{
			m_oCameraMain = this.GetComponent<Camera>();
		}

		/** 상태를 갱신한다 */
		public void LateUpdate()
		{
			var stPos = m_oFollowTarget.transform.position + 
				(m_oFollowTarget.transform.forward * -m_fDistance);

			m_oCameraMain.transform.position = stPos + (Vector3.up * m_fHeight);
			m_oCameraMain.transform.LookAt(m_oFollowTarget.transform.position + (Vector3.up * m_fOffset));
		}
		#endregion // 함수
	}
}
