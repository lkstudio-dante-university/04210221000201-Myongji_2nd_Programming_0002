//#define E02_PREFAB_03
#define E02_SCRIPT_03

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 프리팹이란?
 * - 게임 객체를 에셋화시킬 수 있는 기능을 의미한다. (즉, 프리팹을 활용하면 특정 객체를 손쉽게
 * 재사용하는 것이 가능하다.)
 * 
 * Unity 는 컴포넌트 기반 구조로 되어있기 때문에 새로운 객체를 생성하는 과정이 번거롭다는 단점이
 * 존재한다. (즉, 게임 객체를 생성하고 컴포넌트를 추가 및 초기화하는 여러 과정이 필요하다는 것을
 * 의미한다.)
 * 
 * 따라서 Unity 에서 새로운 객체를 생성 할 때는 기존에 미리 제작한 원본을 통해 사본 객체를 생성하는 
 * 것이 일반적이며 이때 주로 프리팹이 활용된다. (즉, 프리팹은 게임 객체를 에셋으로 저장 및 활용 할
 * 수 있는 기능이기 때문에 프리팹을 통해 사본 객체를 생성하는 것이 가능하다.)
 * 
 * 또한 프리팹을 통해 생성 된 사본 객체들은 원본 프리팹과 변경 사항을 공유하는 특징이 존재한다.
 * (즉, 사본 객체의 변경 사항을 원본 프리팹에 적용함으로서 해당 프리팹으로부터 생성 된 모든 사본
 * 객체에 변경 사항을 반영하는 것이 가능하다.)
 */
namespace E02Example
{
	/**
	 * Example 3
	 */
	public partial class CE02Example_03 : CManager_Scene
	{
		#region 변수
		[Header("=====> Example 3 - Game Objects <=====")]
		[SerializeField] private GameObject m_oPrefab_Targets = null;
		[SerializeField] private GameObject m_oPrefab_OriginTarget = null;

		[SerializeField] private GameObject m_oGameObj_Target = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
		}

		/** 상태를 갱신한다 */
		public override void Update()
		{
			base.Update();

#if E02_PREFAB_03
			// 스페이스 키를 눌렀을 경우
			if(Input.GetKeyDown(KeyCode.Space))
			{
				var oGameObj = Factory.CreateGameObj_Clone("Target",
					m_oPrefab_OriginTarget, m_oPrefab_Targets);

				oGameObj.transform.localScale = m_oPrefab_OriginTarget.transform.localScale;
			}
#elif E02_SCRIPT_03
			// 상 / 하 키를 눌렀을 경우
			if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
			{
				float fSign = Input.GetKey(KeyCode.UpArrow) ? 1.0f : -1.0f;

				/*
				 * Translate 메서드는 게임 객체를 특정 위치로 이동시키는 역할을 수행한다. (즉,
				 * 해당 메서드를 활용하면 게임 객체의 방향을 고려해서 물체를 이동시키는 명령문을
				 * 좀 더 간단하게 작성하는 것이 가능하다.)
				 * 
				 * 단, 입력으로 요구되는 게임 객체의 이동 간격은 월드 공간 상의 단위를 사용하는
				 * 특징이 존재한다. (즉, 비율을 고려하지 않고 이동 간격을 명시해야한다는 것을
				 * 알 수 있다.)
				 */
				m_oGameObj_Target.transform.Translate(0.0f, 
					0.0f, 5.0f * fSign * Time.deltaTime, Space.Self);
			}

			// 좌 / 우 키를 눌렀을 경우
			if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
			{
				float fSign = Input.GetKey(KeyCode.LeftArrow) ? -1.0f : 1.0f;

				/*
				 * Rotate 메서드는 게임 객체를 회전시키는 역할을 수행한다. (즉, 해당 메서드를
				 * 활용하면 간단하게 게임 객체를 특정 방향으로 회전시키는 것이 가능하다.)
				 * 
				 * 게임 객체를 회전하기 위한 방식은 크게 오일러 회전 방식과 사원수 회전 방식이
				 * 존재하며 해당 메서드는 오일러 회전을 위한 입력 데이터 or 사원수 회전 방식을 위한
				 * 입력 데이터를 요구한다. (즉, 상황에 따라 게임 객체를 회전하기 위한 명령문을
				 * 작성하는 것이 가능하다.)
				 */
				m_oGameObj_Target.transform.Rotate(0.0f, 
					180.0f * fSign * Time.deltaTime, 0.0f, Space.Self);
			}
#endif // E02_PREFAB_03
		}
		#endregion // 함수
	}
}
