using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E02Example
{
	/**
	 * 장애물
	 */
	public partial class CE02Obstacle_07 : CComponent
	{
		#region 변수
		[Header("=====> Obstacle - Game Objects <=====")]
		[SerializeField] private GameObject m_oGameObj_SafeArea = null;
		[SerializeField] private GameObject m_oGameObj_UpObstacle = null;
		[SerializeField] private GameObject m_oGameObj_DownObstacle = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();

			float fRate_SafeArea = 0.35f;
			float fRate_UpObstacle = Random.Range(0.1f, 0.9f);
			float fRate_DownObstacle = 1.0f - fRate_UpObstacle;

			var stScale_SafeArea = m_oGameObj_SafeArea.transform.localScale;
			var stScale_UpObstacle = m_oGameObj_UpObstacle.transform.localScale;
			var stScale_DownObstacle = m_oGameObj_DownObstacle.transform.localScale;

			m_oGameObj_SafeArea.transform.localScale = new Vector3(stScale_SafeArea.x,
				KDefine.G_SIZE_HEIGHT_SCREEN * fRate_SafeArea, stScale_SafeArea.z);

			m_oGameObj_UpObstacle.transform.localScale = new Vector3(stScale_UpObstacle.x,
				KDefine.G_SIZE_HEIGHT_SCREEN * fRate_UpObstacle * (1.0f - fRate_SafeArea), stScale_UpObstacle.z);

			m_oGameObj_DownObstacle.transform.localScale = new Vector3(stScale_DownObstacle.x,
				KDefine.G_SIZE_HEIGHT_SCREEN * fRate_DownObstacle * (1.0f - fRate_SafeArea), stScale_DownObstacle.z);

			var stPos_SafeArea = m_oGameObj_SafeArea.transform.localPosition;
			var stPos_UpObstacle = m_oGameObj_UpObstacle.transform.localPosition;
			var stPos_DownObstacle = m_oGameObj_DownObstacle.transform.localPosition;

			m_oGameObj_UpObstacle.transform.localPosition = new Vector3(stPos_UpObstacle.x,
				(KDefine.G_SIZE_HEIGHT_SCREEN / 2.0f) - (m_oGameObj_UpObstacle.transform.localScale.y / 2.0f), stPos_UpObstacle.z);

			m_oGameObj_DownObstacle.transform.localPosition = new Vector3(stPos_DownObstacle.x,
				(KDefine.G_SIZE_HEIGHT_SCREEN / -2.0f) + (m_oGameObj_DownObstacle.transform.localScale.y / 2.0f), stPos_DownObstacle.z);

			m_oGameObj_SafeArea.transform.localPosition = new Vector3(stPos_SafeArea.x,
				m_oGameObj_UpObstacle.transform.localPosition.y - (m_oGameObj_UpObstacle.transform.localScale.y / 2.0f) - (m_oGameObj_SafeArea.transform.localScale.y / 2.0f), stPos_SafeArea.z);
		}
		#endregion // 함수
	}
}
