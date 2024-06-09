using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Example 2
 */
public class CExample_02 : MonoBehaviour
{
	public GameObject m_oPlayer = null;
	private Animation m_oPlayerAnim = null;

	/** 초기화 */
	public void Awake()
	{
		m_oPlayerAnim = m_oPlayer.GetComponent<Animation>();
	}

	/** 상태를 갱신한다 */
	public void Update()
	{
		// 전방 키를 눌렀을 경우
		if(Input.GetKey(KeyCode.UpArrow))
		{
			m_oPlayerAnim.CrossFade("RunF");
		}
		// 후방 키를 눌렀을 경우
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			m_oPlayerAnim.CrossFade("RunB");
		}
		// 좌방 키를 눌렀을 경우
		else if(Input.GetKey(KeyCode.LeftArrow))
		{
			m_oPlayerAnim.CrossFade("RunL");
		}
		// 우방 키를 눌렀을 경우
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			m_oPlayerAnim.CrossFade("RunR");
		}
		else
		{
			m_oPlayerAnim.CrossFade("Idle");
		}
	}
}
