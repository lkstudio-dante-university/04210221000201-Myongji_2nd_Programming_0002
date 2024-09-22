//#define E08_COLLECTION_01
#define E08_COLLECTION_02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 비선형 컬렉션이란?
 * - 내부적으로 데이터를 1 차원이 아닌 복잡한 형태로 관리하는 컬렉션을 의미한다.
 * 
 * 따라서, 구현 방식이 선형 컬렉션에 비해서 상대적으로 난해하지만 대량의 데이터도 빠르게 처리 할 수 있다는 장점이
 * 존재한다.
 * 
 * C# 주요 비선형 컬렉션 종류
 * - 셋
 * - 딕셔너리
 * 
 * 셋 (Set) 이란?
 * - 수학의 집합과 같이 중복되지 않는 데이터를 관리하는 컬렉션을 의미한다. (즉, 셋을 활용하면 간단하게 중복되는 
 * 데이터를 제거하는 것이 가능하다.)
 * 
 * 딕셔너리 (Dictionary) 란?
 * - 데이터를 키와 벨류의 쌍으로 관리하는 탐색에 특화된 컬렉션을 의미한다. (즉, 딕셔너리를 활용하면 대량의 데이터를
 * 좀 더 빠른 시간 안에 제어하는 것이 가능하다.)
 * 
 * 키는 딕셔너리가 관리하는 데이터를 탐색하기 위한 식별자의 역할을 하기 때문에 중복을 허용하지 않는다. 반면, 벨류는 
 * 실제 딕셔너리가 관리하는 데이터이기 때문에 중복이 가능하다는 차이점이 존재한다.
 */
namespace Example._04010203000201_M_2_Programming_0002.E01.Example.Classes.Runtime.Example_08
{
	/*
	 * Example 8
	 */
	internal class CE01Example_08
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E08_COLLECTION_01
			/*
			 * Random 클래스란?
			 * - 난수를 생성해주는 역할을 수행하는 클래스를 의미한다. (즉, Random 클래스를 활용하면 불규칙한 결과를
			 * 만들어내는 프로그램을 제작하는 것이 가능하다.)
			 */
			Random oRandom = new Random();
			HashSet<int> oSetValues = new HashSet<int>();

			for(int i = 0; i < 10; ++i)
			{
				oSetValues.Add(oRandom.Next(0, 10));
			}

			Console.WriteLine("=====> 셋 <=====");

			/*
			 * foreach 반복문이란?
			 * - 열거 가능한 데이터를 대상으로 사용 가능한 반복문을 의미한다. (즉, 해당 반복문은 컬렉션을 대상으로
			 * 동작하도록 설계 된 특별한 반복문이라는 것을 알 수 있다.)
			 */
			foreach(int nVal in oSetValues)
			{
				Console.Write("{0}, ", nVal);
			}

			Console.WriteLine();
#elif E08_COLLECTION_02
			Dictionary<string, int> oDictValues = new Dictionary<string, int>();

			for(int i = 0; i < 10; ++i)
			{
				oDictValues.Add($"Key_{i + 1}", i + 1);
			}

			Console.WriteLine("=====> 딕셔너리 <=====");

			/*
			 * var 키워드란?
			 * - 변수의 자료형을 컴파일러가 자동으로 결정하도록 하는 키워드를 의미한다. (즉, var 키워드를 활용하면
			 * 자료형을 잘 알지 못하더라도 변수를 선언하는 것이 가능하다.)
			 * 
			 * 단, 컴파일러는 변수의 초기 값을 기반으로 해당 변수의 자료형을 결정하기 때문에 var 키워드로 선언 된
			 * 변수는 반드시 초기 값을 명시해줘야한다. (즉, 초기 값을 명시하지 않으면 컴파일 에러가 발생한다는 것을
			 * 알 수 있다.)
			 */
			foreach(var stKeyVal in oDictValues)
			{
				Console.Write("{0}:{1}, ", stKeyVal.Key, stKeyVal.Value);
			}

			Console.WriteLine();
#endif // E08_COLLECTION_01
		}
	}
}
