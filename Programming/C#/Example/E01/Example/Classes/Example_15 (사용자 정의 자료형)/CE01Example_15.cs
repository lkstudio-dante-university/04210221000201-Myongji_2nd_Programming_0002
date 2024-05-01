//#define E15_CUSTOM_DATA_TYPE_01
#define E15_CUSTOM_DATA_TYPE_02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 사용자 정의 자료형이란?
 * - 사용자 (프로그래머) 가 필요에 의해 직접 정의해서 사용하는 자료형을 의미한다. (즉, 사용자 정의 자료형을 활용하면
 * 프로그램의 목적에 맞는 자료형을 정의하는 것이 가능하다.)
 * 
 * C# 은 클래스를 비롯한 다양한 사용자 정의 자료형을 제공하기 때문에 상황에 맞게 자료형을 정의하는 것이 가능하다.
 * 
 * C# 사용자 정의 자료형 종류
 * - 클래스
 * - 구조체
 * - 열거형
 * 
 * 구조체란?
 * - 클래스와 마찬가지로 변수와 메서드 등을 하나로 묶어서 관리 할 수 있는 기능의 의미한다. (즉, 구조체를 활용하면
 * 연관 된 데이터를 묶어서 관리하는 것이 가능하다.)
 * 
 * C# 구조체 정의 방법
 * - struct + 구조체 이름 + 구조체 멤버 (변수, 메서드 등등...)
 * 
 * Ex)
 * struct STSomeStruct
 * {
 *		int m_nVal;
 *		
 *		void ShowInfo()
 *		{
 *			// Do Something
 *		}
 * }
 * 
 * STSomeStruct stSomeStruct;
 * 
 * 위와 같이 구조체 또한 클래스와 마찬가지로 자료형처럼 사용하는 것이 가능하다.
 * 
 * 단, 구조체는 사물을 정의하는데 사용하지 않기 때문에 클래스처럼 객체를 생성한다는 표현보다는 구조체 변수를 선언한다고
 * 표현한다.
 * 
 * 클래스 vs 구조체
 * - 클래스와 구조체 모두 연관 된 데이터를 묶어서 관리하는 것이 가능하다.
 * 
 * 클래스는 참조 형식 자료형에 속하며 사물 (객체) 을 정의하는데 활용되기 때문에 상속을 비롯한 다양한 기능을 지원하는
 * 장점이 존재한다.
 * 
 * 반면, 구조체는 값 형식 자료형에 속하며 단순한 데이터를 다루는데 주로 활용된다. (즉, 구조체는 상속을 사용하는 것이
 * 불가능하며 클래스에 비해 여러 제한 사항이 있다는 것을 알 수 있다.)
 * 
 * 단, 구조체는 값 형식 자료형이기 때문에 가비지 컬렉션에 의해 성능 저하가 발생하지 않는 장점이 존재한다. (즉, 단순한
 * 데이터의 집합은 구조체를 사용하는 것이 좀 더 좋은 선택이라는 것을 알 수 있다.)
 * 
 * 열거형이란?
 * - 심볼릭 상수를 정의 할 수 있는 기능을 의미한다. (즉, 열거형을 활용하면 상수를 좀 더 수월하게 정의하는 것이
 * 가능하다.)
 * 
 * C# 열거형 정의 방법
 * - enum + 열거형 이름 + 열거형 상수
 * 
 * Ex)
 * enum ESomeEnum
 * {
 *		ENUM_CONST_A,
 *		ENUM_CONST_B,
 *		ENUM_CONST_C
 * }
 * 
 * ESomeEnum eSomeEnumm = ESomeEnum.ENUM_CONST_A;
 * 
 * 위와 같이 열거형을 활용하면 간단하게 심볼릭 상수를 정의하는 것이 가능하다.
 * 또한, 열거형은 사용자 정의 자료형 중 하나이기 때문에 열거형을 자료형처럼 사용하는 것이 가능하다.
 */
namespace E01.Example.Classes.Example_15
{
	/**
	 * Example 15
	 */
	internal class CE01Example_15
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E15_CUSTOM_DATA_TYPE_01
			STData stDataA = new STData();
			stDataA.m_nVal = 10;
			stDataA.m_fVal = 3.14f;

			STData stDataB = new STData(20, 3.14f);

			Console.WriteLine("=====> 구조체 A <=====");
			Console.WriteLine("{0}, {1}", stDataA.m_nVal, stDataA.m_fVal);

			Console.WriteLine("\n=====> 구조체 B <=====");
			Console.WriteLine("{0}, {1}", stDataB.m_nVal, stDataB.m_fVal);
#elif E15_CUSTOM_DATA_TYPE_02
			ETypeItem eTypeItem = GetItemAcquire();

			switch(eTypeItem)
			{
				case ETypeItem.GOLD:
					Console.WriteLine("재화를 획득했습니다.");
					break;
				
				case ETypeItem.EQUIP:
					Console.WriteLine("장비를 획득했습니다.");
					break;
				
				case ETypeItem.POTION:
					Console.WriteLine("물약을 획득했습니다.");
					break;
			}
#endif // #if E15_CUSTOM_DATA_TYPE_01
		}

#if E15_CUSTOM_DATA_TYPE_01
		/** 데이터 */
		private struct STData
		{
			public int m_nVal;
			public float m_fVal;

			/*
			 * 구조체 또한 클래스와 마찬가지로 생성자를 구현하는 것이 가능하다.
			 * 
			 * 단, 클래스와 달리 구조체는 기본 생성자를 구현하는 것이 불가능하다. (즉, 구조체는 항상 C# 컴파일러에
			 * 의해서 기본 생성자가 자동으로 구현된다는 차이점이 존재한다.)
			 */
			/** 생성자 */
			public STData(int a_nVal, float a_fVal)
			{
				m_nVal = a_nVal;
				m_fVal = a_fVal;
			}
		}
#elif E15_CUSTOM_DATA_TYPE_02
		/*
		 * 열거형 상수에 값을 할당하지않으면 C# 컴파일러에 의해서 자동으로 0 부터 차례대로 값이 할당된다. (즉, 
		 * C# 컴파일러에 의해서 자동으로 중복되지 않는 수가 할당되기 때문에 값을 중복적으로 할당하는 실수를 줄이는
		 * 것이 가능하다.)
		 * 
		 * 만약, 특정 열거형 상수에 값을 할당하면 다음 열거형 상수는 자동으로 이전 열거형 상수에서 +1 증가 된 값으로
		 * 할당된다.
		 * 
		 * Ex)
		 * enum ESomeEnum
		 * {
		 *		ENUM_CONST_A,
		 *		ENUM_CONST_B = 10,
		 *		ENUM_CONST_C
		 * }
		 * 
		 * 위의 경우 ENUM_CONST_A 는 C# 컴파일러에 의해서 자동으로 0 이 할당되며 ENUM_CONST_C 는 11 이 할당된다.
		 * (즉, ENUM_CONST_B 에 10 을 명시적으로 할당했기 때문에 ENUM_CONST_C 는 +1 증가 된 11 이 할당된다는 것을
		 * 알 수 있다.)
		 */
		/** 아이템 타입 */
		private enum ETypeItem
		{
			GOLD,
			EQUIP,
			POTION
		}

		/** 획득 아이템을 반환한다 */
		private static ETypeItem GetItemAcquire()
		{
			var oRandom = new Random();

			/*
			 * 열거형은 정수와 자유롭게 변환하는 것이 가능하다. (즉, 열거형은 상수를 정의하는 기능이기 때문에 정수와 
			 * 호환이 된다는 것을 알 수 있다.)
			 * 
			 * Ex)
			 * enum ESomeEnum
			 * {
			 *		ENUM_CONST
			 * }
			 * 
			 * int nVal = (int)ESomeEnum.ENUM_CONST;
			 * 
			 * 위와 같이 ENUM_CONST 는 0 이기 때문에 nVal 변수에는 0 이 할당된다는 것을 알 수 있다.
			 */
			return (ETypeItem)oRandom.Next((int)ETypeItem.GOLD, (int)ETypeItem.POTION + 1);
		}
#endif // #if E15_CUSTOM_DATA_TYPE_01
	}
}
