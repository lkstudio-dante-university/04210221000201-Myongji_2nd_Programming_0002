using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 확장 클래스 - 게임 객체
 */
public static partial class Extension
{
	#region 제네릭 클래스 함수
	/** 컴포넌트를 추가한다 */
	public static T ExAddComponent<T>(this GameObject a_oSender,
		bool a_bIsUnique = true) where T : Component
	{
		/*
		 * Unity 는 게임 객체에 동일한 종류의 컴포넌트를 중복으로 추가하는 것이 가능하기 때문에
		 * 새로운 컴포넌트를 추가하기 전에 항상 해당 컴포넌트가 이미 게임 객체에 존재하는지 검사 할
		 * 필요가 있다. (즉, 동일한 종류의 컴포넌트를 중복으로 추가하는 경우는 해당 과정을 생략해도
		 * 된다는 것을 알 수 있다.)
		 */
		return (a_bIsUnique && a_oSender.TryGetComponent(out T oComponent)) ?
			oComponent : a_oSender.AddComponent<T>();
	}
	#endregion // 제네릭 클래스 함수
}