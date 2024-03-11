#define E08_COLLECTION_01
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
 * 키는 딕셔너리가 관리하는 데이터를 탐색하기 위한 식별자의 역할을 하기 때문에 중복을 허용하지 않는다.
 * 반면, 벨류는 실제 딕셔너리가 관리하는 데이터이기 때문에 중복이 가능하다는 차이점이 존재한다.
 */
namespace E01.Example.Classes.Example_08
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
			Random oRandom = new Random();
			HashSet<int> oValSet = new HashSet<int>();

			for(int i = 0; i < 10; ++i)
			{
				oValSet.Add(oRandom.Next(0, 10));
			}

			Console.WriteLine("=====> 셋 <=====");

			foreach(int nVal in oValSet)
			{
				Console.Write("{0}, ", nVal);
			}

			Console.WriteLine();
#elif E08_COLLECTION_02

#endif // E08_COLLECTION_01
		}
	}
}
