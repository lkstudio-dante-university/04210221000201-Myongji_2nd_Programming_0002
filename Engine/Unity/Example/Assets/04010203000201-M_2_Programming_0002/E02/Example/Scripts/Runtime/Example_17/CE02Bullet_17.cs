using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 총알
 */
public partial class CE02Bullet_17 : CComponent
{
	#region 변수
	private Rigidbody m_oRigidbody = null;
	#endregion // 변수

	#region 함수
	/** 초기화 */
	public override void Awake()
	{
		base.Awake();

		m_oRigidbody = this.GetComponent<Rigidbody>();
		m_oRigidbody.useGravity = false;
	}

	/** 총알을 발사한다 */
	public void Shoot(Vector3 a_stVelocity)
	{
		m_oRigidbody.velocity = Vector3.zero;
		m_oRigidbody.AddForce(a_stVelocity, ForceMode.VelocityChange);
	}
	#endregion // 함수
}
