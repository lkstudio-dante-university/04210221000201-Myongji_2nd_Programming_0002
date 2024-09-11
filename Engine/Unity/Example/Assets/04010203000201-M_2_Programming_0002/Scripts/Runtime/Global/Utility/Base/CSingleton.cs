using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 싱글턴이란?
 * - 객체의 생성 개수를 1 개로 제한하는 객체 생성 패턴을 의미한다. (즉, 싱글턴 패턴 구조를 적용하면
 * 프로그램 전체에서 접근 가능한 전역 객체를 생성하는 것이 가능하다.)
 * 
 * Unity 는 기본적으로 씬이 전환 될 때 기존 씬에 존재하는 모든 객체를 제거하기 때문에 씬 간에
 * 데이터를 공유하고 싶다면 싱글턴 패턴과 같은 구조를 적용 할 필요가 있다. (즉, 싱글 모드가 아닌
 * 추가 모드로 씬을 추가 할 경우에는 객체가 제거되지 않는다는 것을 알 수 있다.)
 */

/**
 * 싱글턴
 */
public partial class CSingleton<TInst> : CComponent where TInst : CSingleton<TInst>
{
	#region 클래스 변수
	private static TInst m_tInst = null;
	#endregion // 클래스 변수

	#region 클래스 프로퍼티
	public static TInst Inst
	{
		get
		{
			// 인스턴스가 없을 경우
			if(CSingleton<TInst>.m_tInst == null)
			{
				var oGameObj = new GameObject(typeof(TInst).ToString());
				CSingleton<TInst>.m_tInst = oGameObj.ExAddComponent<TInst>();
			}

			return CSingleton<TInst>.m_tInst;
		}
	}
	#endregion // 클래스 프로퍼티

	#region 함수
	/** 초기화 */
	public override void Awake()
	{
		base.Awake();
		Debug.Assert(CSingleton<TInst>.m_tInst == null);

		CSingleton<TInst>.m_tInst = this as TInst;

		/*
		 * DontDestroyOnLoad 메서드란?
		 * - 씬이 전환되어도 특정 객체를 제거하지 않도록 지정하는 역할을 수행하는 메서드이다. (즉,
		 * 해당 메서드를 통해 설정 된 객체는 명시적으로 제거하기 전까지는 항상 씬에 존재한다는 것을
		 * 알 수 있다.)
		 */
		DontDestroyOnLoad(CSingleton<TInst>.m_tInst.gameObject);
	}
	#endregion // 함수

	#region 클래스 함수
	/** 인스턴스를 생성한다 */
	public static TInst Create()
	{
		return CSingleton<TInst>.Inst;
	}
	#endregion // 클래스 함수
}
