using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 총알
 */
public partial class CE02Bullet_17 : CComponent
{
	#region 변수
	[Header("=====> Bullet - Etc <=====")]
	private Collider m_oCollider = null;
	private Rigidbody m_oRigidbody = null;
	#endregion // 변수

	#region 함수
	/** 초기화 */
	public override void Awake()
	{
		base.Awake();

		m_oCollider = this.GetComponentInChildren<Collider>();
		m_oCollider.enabled = false;
		m_oCollider.isTrigger = true;

		m_oRigidbody = this.GetComponentInChildren<Rigidbody>();
		m_oRigidbody.useGravity = false;

		var oDispatcher_Trigger = this.GetComponent<CDispatcher_Trigger>();
		oDispatcher_Trigger.SetCallback_Begin(this.HandleOnTrigger_Enter);
	}

	/** 초기화 */
	public override void Start()
	{
		base.Start();
		m_oCollider.enabled = true;
	}

	/** 총알을 발사한다 */
	public void Shoot(Vector3 a_stVelocity)
	{
		m_oRigidbody.linearVelocity = Vector3.zero;
		m_oRigidbody.AddForce(a_stVelocity, ForceMode.VelocityChange);
	}

	/** 충돌이 발생했을 경우 */
	private void HandleOnTrigger_Enter(CDispatcher_Trigger a_oSender,
		Collider a_oCollider)
	{
		Destroy(this.gameObject);
	}
	#endregion // 함수
}
