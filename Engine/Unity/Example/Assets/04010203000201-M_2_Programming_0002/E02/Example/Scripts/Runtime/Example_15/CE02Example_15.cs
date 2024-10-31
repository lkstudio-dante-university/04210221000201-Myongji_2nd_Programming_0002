using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 메카님 (Mecanim) 이란?
 * - Unity 에서 애니메이션을 제어하기 위한 시스템을 의미한다. (즉, 메카님을 활용하면 간단하게 특정
 * 사물에 애니메이션을 적용하는 것이 가능하다.)
 * 
 * 메카님은 애니메이션을 제어하는 기본적인 기능 이외에도 애니메이션 리타겟팅 기능을 지원하기 때문에
 * 특정 애니메이션을 여러 모델에 적용하는 것이 가능하다. (즉, 애니메이션 리타겟팅 기능을 활용하면
 * 특정 애니메이션을 재사용하는 것이 가능하다.)
 * 
 * 단, 특정 애니메이션을 리타겟팅하기 위해서는 아바타라고 불리는 데이터가 필요하며 해당 데이터는
 * 사람과 같이 이족 보행하는 대상으로만 생성하는 것이 가능하다. (즉, 이족 보생 대상이 아니라면
 * 애니메이션 리타겟팅을 통해 애니메이션을 재사용하는 것이 불가능하다.)
 */
namespace E02Example
{
	/**
	 * Example 15
	 */
	public partial class CE02Example_15 : CManager_Scene
	{
		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
		}
		#endregion // 함수
	}
}
