#define E09_METHOD_01
#define E09_METHOD_02
#define E09_METHOD_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 메서드 (함수) 란?
 * - 프로그램을 구성하는 명령문의 일부 또는 전체를 따로 때어내서 재사용 할 수 있는 기능을 의미한다. (즉, 메서드를
 * 활용하면 중복적으로 발생하는 명령문을 최소화시키는 것이 가능하다.)
 * 
 * 따라서, 메서드 내부에는 메서드가 호출되었을 때 실행 할 명령문이 존재하며 이러한 명령문은 메서드가 호출 될 때마다
 * 실행된다는 특징이 존재한다. (즉, 메서드를 호출하지 않으면 명령문이 동작하지 않는다는 것을 알 수 있다.)
 * 
 * C# 메서드 구현 방법
 * - 반환 형 (출력) + 메서드 이름 + 매개 변수 (입력) + 메서드 몸체
 * 
 * Ex)
 * public static int SomeMethod(int a_nValA, int a_nValB)
 * {
 *		// 메서드가 호출되었을 때 실행 할 명령문
 * }
 * 
 * C# 메서드는 입력 데이터와 출력 데이터의 존재 유무에 따라 크게 4 가지 형태로 구현된다. 
 * 단, 입력 데이터는 필요에 따라 여러 개를 명시하는 것이 가능하지만 출력 데이터는 1 개만 명시하는 것이 가능하다.
 * 
 * C# 메서드 유형
 * - 입력 O, 출력 O		<- int SomeMethodA(int a_nValA, int a_nValB)
 * - 입력 O, 출력 X		<- void SomeMethodB(int a_nValA, int a_nValB)
 * - 입력 X, 출력 O		<- int SomeMethodC()
 * - 입력 X, 출력 X		<- void SomeMethodD()
 */
namespace E01.Example.Classes.Example_09
{
	/**
	 * Example 9
	 */
	internal class CE01Example_09
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E09_METHOD_01
			int nValA = 0;
			int nValB = 0;

			char chOperator = '\0';

			Console.Write("수식 입력 : ");
			var oTokens = Console.ReadLine().Split();

			// 데이터 개수가 부족 할 경우
			if(oTokens.Length < 3)
			{
				return;
			}

			int.TryParse(oTokens[0], out nValA);
			int.TryParse(oTokens[2], out nValB);

			char.TryParse(oTokens[1], out chOperator);

			/*
			 * 호출하는 메서드가 입력 데이터를 요구 할 경우 일반적으로 입력 데이터의 개수만큼 데이터를 전달 할 필요가
			 * 있다. (즉, 입력 데이터의 개수와 실제 전달되는 데이터의 개수에 차이가 존재 할 경우 컴파일 에러가
			 * 발생한다.)
			 */
			decimal dmResult = GetResultCalc(nValA, chOperator, nValB);
			Console.WriteLine("{0} {1} {2} = {3}", nValA, chOperator, nValB, dmResult);
#elif E09_METHOD_02
			int nValA = 0;
			int nValB = 0;

			Console.Write("정수 (2 개) 입력 : ");
			var oTokens = Console.ReadLine().Split();

			// 데이터 개수가 부족 할 경우
			if(oTokens.Length < 2)
			{
				return;
			}

			int.TryParse(oTokens[0], out nValA);
			int.TryParse(oTokens[1], out nValB);

			/*
			 * C# 메서드는 기본적으로 데이터를 복사하는 값에 의한 호출로 동작하기 때문에 특정 메서드에서 다른 메서드
			 * 내부에 존재하는 변수를 제어하는 것이 불가능하다. (즉, 일반적으로 메서드 내부에서 선언 된 변수는 메서드
			 * 내부에서만 접근하는 것이 가능하다.)
			 */
			SwapByVal(nValA, nValB);

			Console.WriteLine("=====> 값에 의한 호출 <=====");
			Console.WriteLine("{0}, {1}", nValA, nValB);

			/*
			 * ref 키워드는 참조를 전달하는 역할을 수행한다. (즉, 해당 키워드를 활용하면 특정 메서드에서 다른 메서드
			 * 내부에 존재하는 변수를 제어하는 것이 가능하다.)
			 */
			SwapByRef(ref nValA, ref nValB);

			Console.WriteLine("\n=====> 참조에 의한 호출 <=====");
			Console.WriteLine("{0}, {1}", nValA, nValB);
#elif E09_METHOD_03
			int nValA = 0;
			int nValB = 0;

			/*
			 * ref 키워드 vs out 키워드
			 * - 두 키워드 모두 특정 메서드에 참조를 전달하는 역할을 수행한다.
			 * 
			 * ref 키워드는 단순히 참조를 전달하는 역할만을 수행하기 때문에 초기화되지 않은 변수에는 사용하는 것이
			 * 불가능하다. (즉, C# 은 기본적으로 초기화되지 않은 변수는 사용하는 것이 불가능하다는 것을 알 수 있다.)
			 * 
			 * 반면, out 키워드는 참조를 전달받는 메서드 내부에서 반드시 값을 할당한다는 것을 보장하기 때문에 
			 * 초기화되지 않은 변수에도 사용하는 것이 가능하다. (즉, 참조를 전달받은 메서드 내부에서 변수에 값을
			 * 할당하지 않을 경우 컴파일 에러가 발생한다.)
			 */
			SetValByRef(ref nValA, 10);
			SetValByOut(out nValB, 20);

			Console.WriteLine("{0}, {1}", nValA, nValB);
#endif // E09_METHOD_01
		}

#if E09_METHOD_01
		/** 수식 결과를 반환한다 */
		private static decimal GetResultCalc(int a_nValA, char a_chOperator, int a_nValB)
		{
			switch(a_chOperator)
			{
				case '+':
					return a_nValA + a_nValB;

				case '-':
					return a_nValA - a_nValB;

				case '*':
					return a_nValA * a_nValB;

				case '/':
					return a_nValA / (decimal)a_nValB;
			}

			return 0;
		}
#elif E09_METHOD_02
		/** 값을 교환한다 */
		public static void SwapByVal(int a_nValA, int a_nValB)
		{
			int nTemp = a_nValA;
			a_nValA = a_nValB;
			a_nValB = nTemp;
		}

		/** 값을 교환한다 */
		public static void SwapByRef(ref int a_nValA, ref int a_nValB)
		{
			int nTemp = a_nValA;
			a_nValA = a_nValB;
			a_nValB = nTemp;
		}
#elif E09_METHOD_03
		/** 값을 변경한다 */
		public static void SetValByRef(ref int a_nVal, int a_nSetVal)
		{
			a_nVal = a_nSetVal;
		}

		/** 값을 변경한다 */
		public static void SetValByOut(out int a_nVal, int a_nSetVal)
		{
			a_nVal = a_nSetVal;
		}
#endif // E09_METHOD_01
	}
}
