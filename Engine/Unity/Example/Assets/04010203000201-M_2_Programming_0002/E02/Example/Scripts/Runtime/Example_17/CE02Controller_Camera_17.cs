using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 카메라 제어자
 */
public partial class CE02Controller_Camera_17 : CComponent
{
	#region 변수
	[Header("=====> Camera Controller - Etc <=====")]
	[SerializeField] private float m_fHeight = 350.0f;
	[SerializeField] private float m_fOffset = 150.0f;
	[SerializeField] private float m_fDistance = 750.0f;

	[SerializeField] private float m_fSpeed_Lerp = 15.0f;

	[Header("=====> Camera Controller - Game Objects <=====")]
	[SerializeField] private GameObject m_oTarget_Follow = null;
	#endregion // 변수

	#region 함수
	/** 초기화 */
	public override void Start()
	{
		base.Start();
		this.UpdatePos(true);
	}

	/** 상태를 갱신한다 */
	public void LateUpdate()
	{
		this.UpdatePos();
	}

	/** 위치를 갱신한다 */
	private void UpdatePos(bool a_bIsImmediate = false)
	{
		// 상태 갱신이 불가능 할 경우
		if(m_oTarget_Follow == null)
		{
			return;
		}

		var stPos_Base = m_oTarget_Follow.transform.position;
		var stPos_Height = Vector3.up * m_fHeight * 0.01f;
		var stPos_Offset = Vector3.up * m_fOffset * 0.01f;
		var stPos_Distance = -m_oTarget_Follow.transform.forward * m_fDistance * 0.01f;

		// 즉시 갱신 모드 일 경우
		if(a_bIsImmediate)
		{
			this.transform.position = stPos_Base +
				stPos_Distance + stPos_Height;
		}
		else
		{
			var stPos_Start = this.transform.position;

			var stPos_End = stPos_Base +
				stPos_Distance + stPos_Height;

			this.transform.position = Vector3.Lerp(stPos_Start,
				stPos_End, Time.deltaTime * m_fSpeed_Lerp);
		}

		this.transform.LookAt(stPos_Base + stPos_Offset);
	}
	#endregion // 함수
}
