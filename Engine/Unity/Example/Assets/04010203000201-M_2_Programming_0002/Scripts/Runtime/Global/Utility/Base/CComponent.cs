using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 컴포넌트
 */
public partial class CComponent : MonoBehaviour
{
	#region 함수
	/** 초기화 */
	public virtual void Awake()
	{
		// Do Something
	}

	/** 초기화 */
	public virtual void Start()
	{
		// Do Something
	}

	/** 상태를 리셋한다 */
	public virtual void Reset()
	{
		// Do Something
	}

	/** 제거되었을 경우 */
	public virtual void OnDestroy()
	{
		// Do Something
	}

	/** 상태를 갱신한다 */
	public virtual void OnUpdate(float a_fTime_Delta)
	{
		// Do Something
	}
	#endregion // 함수
}
