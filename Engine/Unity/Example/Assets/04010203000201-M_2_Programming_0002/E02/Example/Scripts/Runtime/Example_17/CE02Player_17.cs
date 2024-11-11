using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 플레이어
 */
public partial class CE02Player_17 : CComponent
{
	#region 변수
	[Header("=====> Player - Etc <=====")]
	[SerializeField] private float m_fSpeed = 500.0f;
	[SerializeField] private float m_fSpeed_Rotate = 180.0f;

	private Animation m_oAnim = null;

	[Header("=====> Player - Game Objects <=====")]
	[SerializeField] private GameObject m_oPrefab_Bullet = null;
	[SerializeField] private GameObject m_oSpawnPos_Bullet = null;
	#endregion // 변수

	#region 함수
	/** 초기화 */
	public override void Awake()
	{
		base.Awake();
		m_oAnim = this.GetComponent<Animation>();
	}

	/** 상태를 갱신한다 */
	public override void OnUpdate(float a_fTime_Delta)
	{
		base.OnUpdate(a_fTime_Delta);

		float fVertical = Input.GetAxisRaw("Vertical");
		float fHorizontal = Input.GetAxisRaw("Horizontal");

		var stDirection = (this.transform.forward * fVertical) +
			(this.transform.right * fHorizontal);

		// 보정이 필요 할 경우
		if(stDirection.magnitude.ExIsGreat(1.0f))
		{
			stDirection = stDirection.normalized;
		}

		this.transform.localPosition += (stDirection * m_fSpeed) * 
			a_fTime_Delta;

		// 앞 / 뒤로 이동했을 경우
		if(!fVertical.ExIsEquals(0.0f))
		{
			m_oAnim.CrossFade(fVertical.ExIsGreat(0.0f) ? 
				"RunF" : "RunB");
		}
		// 좌 / 우로 이동했을 경우
		else if(!fHorizontal.ExIsEquals(0.0f))
		{
			m_oAnim.CrossFade(fHorizontal.ExIsGreat(0.0f) ?
				"RunR" : "RunL");
		}
		else
		{
			m_oAnim.CrossFade("Idle");
		}

		// 회전이 가능 할 경우
		if(Input.GetMouseButton((int)EBtn_Mouse.RIGHT))
		{
			float fMouseX = Input.GetAxisRaw("Mouse X");

			this.transform.Rotate(Vector3.up,
				fMouseX * m_fSpeed_Rotate * a_fTime_Delta, Space.World);
		}

		// 스페이스 키를 눌렀을 경우
		if(Input.GetKeyDown(KeyCode.Space))
		{
			var oBullet = Factory.CreateGameObj_Clone<CE02Bullet_17>("Bullet",
				m_oPrefab_Bullet, this.transform.parent.gameObject);

			oBullet.transform.forward = this.transform.forward;
			oBullet.transform.position = m_oSpawnPos_Bullet.transform.position;

			oBullet.Shoot(this.transform.forward * 150.0f);
		}
	}
	#endregion // 함수
}
