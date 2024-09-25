using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 확장 클래스 - 벡터
 */
public static partial class Extension
{
	#region 클래스 함수
	/** 로컬 => 월드로 변환한다 */
	public static Vector3 ExToWorld(this Vector3 a_stSender,
		GameObject a_oGameObj_Parent, bool a_bIsCoord = true)
	{
		var stVec = new Vector4(a_stSender.x,
			a_stSender.y, a_stSender.z, a_bIsCoord ? 1.0f : 0.0f);

		/*
		 * Transform 컴포넌트를 활용하면 위치를 월드 <=> 로컬 로 변환하는 것이 가능하다. (즉,
		 * Transform 컴포넌트에 존재하는 행렬을 활용하면 손쉽게 공간 변환이 가능하다는 것을 알 수
		 * 있다.)
		 * 
		 * 게임 객체의 계층 구조는 행렬 연산을 통해서 표현되기 때문에 Transform 컴포넌트에 존재하는
		 * localToWorldMatrix 행렬과 worldToLocalMatrix 행렬을 통해 월드 <=> 로컬 상에 공간
		 * 변환이 가능하다.
		 * 
		 * 단, 3 차원 공간 상의 변환은 4 x 4 행렬을 사용하기 때문에 위치 또한 x, y, z 와 더불어
		 * w 요소가 필요하다. (즉, w 요소가 1 일 경우 위치를 나타내며 0 일 경우 방향을 나타낸다는
		 * 것을 알 수 있다.)
		 */
		return a_oGameObj_Parent.transform.localToWorldMatrix * stVec;
	}

	/** 월드 => 로컬로 변환한다 */
	public static Vector3 ExToLocal(this Vector3 a_stSender,
		GameObject a_oGameObj_Parent, bool a_bIsCoord = true)
	{
		var stVec = new Vector4(a_stSender.x,
			a_stSender.y, a_stSender.z, a_bIsCoord ? 1.0f : 0.0f);

		return a_oGameObj_Parent.transform.worldToLocalMatrix * stVec;
	}
	#endregion // 클래스 함수
}
