#define E10_METHOD_01
#define E10_METHOD_02
#define E10_METHOD_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01.Example.Classes.Example_10
{
	/**
	 * Example 10
	 */
	internal class CE01Example_10
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E10_METHOD_01
			int nSumValA = GetSumVal(1, 2, 3);
			int nSumValB = GetSumVal(1, 2, 3, 4, 5, 6);
			int nSumValC = GetSumVal(1, 2, 3, 4, 5, 6, 7, 8, 9);

			Console.WriteLine("{0}, {1}, {2}", nSumValA, nSumValB, nSumValC);
#elif E10_METHOD_02
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

			int nSumVal = GetSumVal(nValA, nValB);
			float fSumVal = GetSumVal((float)nValA, (float)nValB);

			Console.WriteLine("{0}, {1}", nSumVal, fSumVal);
#elif E10_METHOD_03
			var oListVals = new List<int>();
			SetupVals(oListVals, 10);

			Console.WriteLine("=====> 리스트 요소 <=====");
			PrintVals(oListVals);

			var stResult = GetValMinMax(oListVals);

			/*
			 * 튜플의 각 요소에 별도의 이름을 명시하지 않았을 경우 기본적으로 Item1 부터 차례대로 각 요소의 이름이
			 * 설정된다. (즉, 필요에 따라 좀 더 명확한 이름을 작성하는 것이 가능하다.)
			 */
			Console.WriteLine("\n최소 값 : {0}", stResult.Item1);
			Console.WriteLine("최대 값 : {0}", stResult.Item2);
#endif // #if E10_METHOD_01
		}

#if E10_METHOD_01
		/*
		 * params 키워드는 가변 매개 변수를 전달받는 역할을 수행한다. (즉, 해당 키워드를 활용하면 메서드의 입력
		 * 데이터 개수를 지정하지 않고 메서드를 구현하는 것이 가능하다.)
		 * 
		 * 일반적으로 메서드의 입력 데이터는 개수가 지정되어있지만 params 키워드를 통해 가변 매개 변수를 선언 할 경우 
		 * 원하는 만큼 데이터를 전달하는 것이 가능하다.
		 */
		/** 합계를 반환한다 */
		public static int GetSumVal(params int[] a_oVals)
		{
			int nSumVal = 0;

			for(int i = 0; i < a_oVals.Length; ++i)
			{
				nSumVal += a_oVals[i];
			}

			return nSumVal;
		}
#elif E10_METHOD_02
		/*
		 * 메서드 오버로딩을 활용하면 동일한 이름의 메서드를 여러 개 구현하는 것이 가능하다. (즉, 일반적으로 메서드
		 * 이름은 변수와 같은 중복을 허용하지 않는다는 것을 알 수 있다.)
		 * 
		 * C# 은 메서드의 입력 데이터만을 가지고 메서드 오버로딩 가능 여부를 판별하기 떄문에 주의가 필요하다.
		 * (즉, 반환 형은 메서드 오버로딩 여부를 판별하는데 사용하지 않는다는 것을 알 수 있다.)
		 * 
		 * Ex)
		 * void SomeMethod(int a_nVal);
		 * void SomeMethod(int a_nValA, int a_nValB);
		 * 
		 * 위의 경우 입력 데이터의 개수가 다르기 때문에 메서드 오버로딩이 가능하다.
		 * 
		 * void SomeMethod(int a_nValA, int a_nValB);
		 * void SomeMethod(float a_fValA, float a_fValB);
		 * 
		 * 위의 경우 입력 데이터의 자료형이 다르기 때문에 역시 메서드 오버로딩이 성립한다는 것을 알 수 있다.
		 * 
		 * int SomeMethod(int a_nVal);
		 * void SomeMethod(int a_nVal);
		 * 
		 * 위의 경우 반환 형은 다르지만 입력 데이터가 동일하기 때문에 메서드 오버로딩이 성립하지 않는다. (즉, 컴파일
		 * 에러가 발생한다는 것을 알 수 있다.)
		 */
		/** 합계를 반환한다 */
		public static int GetSumVal(int a_nValA, int a_nValB)
		{
			return a_nValA + a_nValB;
		}

		/** 합계를 반환한다 */
		public static float GetSumVal(float a_fValA, float a_fValB)
		{
			return a_fValA + a_fValB;
		}
#elif E10_METHOD_03
		/** 값을 설정한다 */
		public static void SetupVals(List<int> a_oListVals, int a_nNumVals)
		{
			var oRandom = new Random();
			a_oListVals.Clear();

			for(int i = 0; i < a_nNumVals; ++i)
			{
				a_oListVals.Add(oRandom.Next(0, 100));
			}
		}

		/*
		 * C# 의 튜플과 같은 기능을 활용하면 메서드가 2 개 이상의 결과 값을 반환하는 것이 가능하다. (즉, 메서드 자체는
		 * 여전히 하나의 데이터만 결과 값으로 반환 할 수 있다.)
		 */
		/** 최소, 최대 값을 반환한다 */
		public static (int, int) GetValMinMax(List<int> a_oListVals)
		{
			int nMinVal = int.MaxValue;
			int nMaxVal = int.MinValue;

			for(int i = 0; i < a_oListVals.Count; ++i)
			{
				nMinVal = Math.Min(nMinVal, a_oListVals[i]);
				nMaxVal = Math.Max(nMaxVal, a_oListVals[i]);
			}

			return (nMinVal, nMaxVal);
		}

		/** 값을 출력한다 */
		public static void PrintVals(List<int> a_oListVals)
		{
			for(int i = 0; i < a_oListVals.Count; ++i)
			{
				Console.Write("{0}, ", a_oListVals[i]);
			}

			Console.WriteLine();
		}
#endif // #if E10_METHOD_01
	}
}
