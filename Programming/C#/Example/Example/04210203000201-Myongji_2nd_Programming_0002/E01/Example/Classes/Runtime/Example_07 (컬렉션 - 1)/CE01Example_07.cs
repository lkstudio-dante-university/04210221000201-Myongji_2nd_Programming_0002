//#define E07_COLLECTION_01
//#define E07_COLLECTION_02
//#define E07_COLLECTION_03
//#define E07_COLLECTION_04
#define E07_COLLECTION_05

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 컬렉션이란?
 * - 여러 데이터를 효율적으로 관리 할 수 있는 기능을 의미한다. (즉, 컬렉션을 활용하면 대량의 데이터를 제어하는 것이
 * 가능하다.)
 * 
 * C# 은 데이터를 관리하기 위한 여러가지 컬렉션을 제공하며 이러한 컬렉션은 내부적인 구현 방식에 따라 크게 
 * 선형 컬렉션과 비선형 컬렉션으로 구분된다.
 * 
 * 선형 컬렉션이란?
 * - 내부적으로 데이터를 1 차원적인 형태로 관리하는 컬렉션을 의미한다.
 * 
 * 따라서, 구현 방식이 비선형 컬렉션에 비해서 상대적으로 간단하지만 관리하는 데이터의 개수가 많아질수록 성능이
 * 저하되는 단점이 존재한다.
 * 
 * C# 주요 선형 컬렉션 종류
 * - 배열
 * - 리스트
 * - 스택 / 큐
 * 
 * 배열 (Array) 이란?
 * - 내부적으로 관리하는 데이터의 순서가 존재하는 컬렉션을 의미한다.
 * 
 * 단, 배열은 처음 생성 할 때 배열이 관리 할 데이터의 개수를 미리 지정 할 필요가 있으며 이후 더이상 변경하는 것이
 * 불가능하기 때문에 최대로 제어 할 데이터의 개수가 정해져있지 않을 경우 적합하지 않다는 것을 알 수 있다.
 * 
 * 배열이 관리하는 데이터에 접근하기 위해서는 [] (인덱스 연산자) 와 인덱스 번호를 사용해야 한다. (즉, 잘못된 인덱스
 * 번호를 사용 할 경우 런타임 에러가 발생한다는 것을 알 수 있다.)
 * 
 * 인덱스 번호는 0 ~ 배열 길이 - 1 범위를 지니고 있기 때문에 잘못된 번호를 명시하지 않도록 주의가 필요하다.
 * 
 * 리스트 (List) 란?
 * - 내부적으로 관리하는 데이터의 순서가 존재하는 컬렉션을 의미한다. (즉, 배열과 유사하다는 것을 알 수 있다.)
 * 
 * 단, 배열은 처음 길이가 정해지면 더이상 변경하는 것이 불가능 한 반면 리스트는 원하는 만큼 데이터를 추가하거나
 * 제거하는 것이 가능하기 때문에 관리 할 데이터의 최대 개수가 정해져있지 않을 경우 사용하는 것을 추천한다.
 * 
 * 스택 (Stack) 이란?
 * - LIFO (Last In First Out) 구조로 동작하는 컬렉션을 의미한다. (즉, 스택은 특정 위치에 존재하는 데이터에 자유롭게
 * 접근하는 것이 불가능하다는 것을 알 수 있다.)
 * 
 * 큐 (Queue) 란?
 * - FIFO (First In First Out) 구조로 동작하는 컬렉션을 의미한다. (즉, 큐 또한 스택과 마찬가지로 특정 위치에
 * 존재하는 데이터에 자유롭게 접근하는 것이 불가능하다.)
 */
namespace Example._04210203000201_Myongji_2nd_Programming_0002.E01.Example.Classes.Runtime.Example_07
{
	/**
	 * Example 7
	 */
	internal class CE01Example_07
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E07_COLLECTION_01
			int[] oValuesA = new int[5];
			oValuesA[0] = 1;
			oValuesA[1] = 2;
			oValuesA[2] = 3;

			/*
			 * 배열을 생성 후 초기화 값을 명시 할 경우 반드시 배열의 길이만큼 초기화 값을 명시해줘야한다. (즉, 배열의
			 * 길이와 초기화 값의 개수가 다를 경우 컴파일 에러가 발생한다는 것을 알 수 있다.)
			 */
			int[] oValuesB = new int[5]
			{
				1, 2, 3, 4, 5
			};

			/*
			 * 특정 배열을 생성 할 경우 기본적으로 길이를 명시해줘야한다.
			 * 
			 * 만약, 길이를 명시하지 않을 경우에는 반드시 초기화 값을 명시해서 컴파일러가 해당 배열의 길이를 
			 * 계산 할 수 있도록 해줘야한다. (즉, 길이가 명시되지 않은 배열에 초기화를 해주지 않을 경우 컴파일 에러가
			 * 발생한다는 것을 알 수 있다.)
			 */
			int[] oValuesC = new int[]
			{
				1, 2, 3
			};

			Console.WriteLine("=====> 배열 A <=====");

			/*
			 * 배열은 Length 프로퍼티를 제공하며 해당 프로퍼티를 사용해서 배열의 길이를 가져오는 것이 가능하다.
			 */
			for(int i = 0; i < oValuesA.Length; ++i)
			{
				Console.Write("{0}, ", oValuesA[i]);
			}

			Console.WriteLine("\n\n=====> 배열 B <=====");

			for(int i = 0; i < oValuesB.Length; ++i)
			{
				Console.Write("{0}, ", oValuesB[i]);
			}

			Console.WriteLine("\n\n=====> 배열 C <=====");

			for(int i = 0; i < oValuesC.Length; ++i)
			{
				Console.Write("{0}, ", oValuesC[i]);
			}

			Console.WriteLine();
#elif E07_COLLECTION_02
			/*
			 * 배열은 , 기호를 사용해서 차원을 명시하는 것이 가능하다. (즉, 해당 기호를 사용하면 2 차원 이상의
			 * 배열을 명시하는 것이 가능하다.)
			 */
			int[,] oMatrixA = new int[3, 3];
			oMatrixA[0, 0] = 1;
			oMatrixA[0, 1] = 2;
			oMatrixA[0, 2] = 3;

			/*
			 * 2 차원 이상의 배열을 초기화 할 경우에는 반드시 { } 의 조합을 통해 명시 된 초기화 값의 차원을
			 * 지정해줘야한다.
			 */
			int[,] oMatrixB = new int[3, 3]
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 },
				{ 7, 8, 9 }
			};

			/*
			 * 2 차원 이상의 배열 또한 생성 시 배열의 길이를 생략하는 것이 가능하다.
			 */
			int[,] oMatrixC = new int[,]
			{
				{ 1, 2 },
				{ 3, 4 }
			};

			Console.WriteLine("=====> 행렬 A <=====");

			/*
			 * 2 차원 이상의 배열로부터 길이를 가져오기 위해서는 Length 프로퍼티가 아닌 GetLength 메서드를
			 * 사용해야한다. (즉, Length 프로퍼티는 배열의 총 길이를 가져오기 때문에 특정 차원의 길이를 가져오는
			 * 것이 불가능하다.)
			 * 
			 * GetLength 메서드에 명시하는 번호는 0 을 기준으로 1 씩 증가한다. (즉, 0 은 가장 최상위 차원 번호라는
			 * 것을 알 수 있다.)
			 */
			for(int i = 0; i < oMatrixA.GetLength(0); ++i)
			{
				for(int j = 0; j < oMatrixA.GetLength(1); ++j)
				{
					Console.Write("{0}, ", oMatrixA[i, j]);
				}

				Console.WriteLine();
			}

			Console.WriteLine("\n=====> 행렬 B <=====");

			for(int i = 0; i < oMatrixB.GetLength(0); ++i)
			{
				for(int j = 0; j < oMatrixB.GetLength(1); ++j)
				{
					Console.Write("{0}, ", oMatrixB[i, j]);
				}

				Console.WriteLine();
			}

			Console.WriteLine("\n=====> 행렬 C <=====");

			for(int i = 0; i < oMatrixC.GetLength(0); ++i)
			{
				for(int j = 0; j < oMatrixC.GetLength(1); ++j)
				{
					Console.Write("{0}, ", oMatrixC[i, j]);
				}

				Console.WriteLine();
			}
#elif E07_COLLECTION_03
			/*
			 * 배열은 [] 의 조합을 통해 가변 배열을 명시하는 것이 가능하다.
			 * 
			 * 가변 배열이란?
			 * - 배열을 관리하는 배열을 의미한다. (즉, 일반적으로 배열은 특정 자료형의 데이터를 관리하지만
			 * 가변 배열은 배열을 관리한다는 것을 알 수 있다.)
			 */
			int[][] oValues = new int[3][];

			for(int i = 0; i < oValues.Length; ++i)
			{
				oValues[i] = new int[(i + 1) * 3];
			}

			for(int i = 0; i < oValues.Length; ++i)
			{
				for(int j = 0; j < oValues[i].Length; ++j)
				{
					oValues[i][j] = j + 1;
				}
			}

			Console.WriteLine("=====> 가변 배열 <=====");

			for(int i = 0; i < oValues.Length; ++i)
			{
				for(int j = 0; j < oValues[i].Length; ++j)
				{
					Console.Write("{0}, ", oValues[i][j]);
				}

				Console.WriteLine();
			}
#elif E07_COLLECTION_04
			List<int> oListValuesA = new List<int>();
			List<List<int>> oListValuesB = new List<List<int>>();

			for(int i = 0; i < 10; ++i)
			{
				/*
				 * 리스트와 같이 길이가 정해지지않은 컬렉션은 Add 와 같은 메서드를 통해서 데이터를 추가하는 과정을
				 * 거치고 나서야 [] (인덱스 연산자) 를 사용하는 것이 가능하다. (즉, 데이터를 추가하지 않고 특정
				 * 데이터에 접근하는 시도를 할 경우 런타임 에러가 발생한다는 것을 알 수 있다.)
				 */
				oListValuesA.Add(i + 1);
			}

			for(int i = 0; i < 10; ++i)
			{
				List<int> oListValues = new List<int>();

				for(int j = 0; j < 10; ++j)
				{
					int nBase = i * 10;
					oListValues.Add(nBase + j);
				}

				/*
				 * 리스트가 제어 할 데이터로 리스트를 명시함으로서 2 차원 이상의 배열과 유사한 구조를 만들어내는 것이 
				 * 가능하다.
				 */
				oListValuesB.Add(oListValues);
			}

			Console.WriteLine("=====> 리스트 A <=====");

			for(int i = 0; i < oListValuesA.Count; ++i)
			{
				Console.Write("{0}, ", oListValuesA[i]);
			}

			Console.WriteLine("\n\n=====> 리스트 B <=====");

			for(int i = 0; i < oListValuesB.Count; ++i)
			{
				for(int j = 0; j < oListValuesB[i].Count; ++j)
				{
					Console.Write("{0,2}, ", oListValuesB[i][j]);
				}

				Console.WriteLine();
			}
#elif E07_COLLECTION_05
			Stack<int> oStackValues = new Stack<int>();
			Queue<int> oQueueValues = new Queue<int>();

			for(int i = 0; i < 10; ++i)
			{
				oStackValues.Push(i + 1);
				oQueueValues.Enqueue(i + 1);
			}

			Console.WriteLine("=====> 스택 <=====");

			while(oStackValues.Count >= 1)
			{
				Console.Write("{0}, ", oStackValues.Pop());
			}

			Console.WriteLine("\n\n=====> 큐 <=====");

			while(oQueueValues.Count >= 1)
			{
				Console.Write("{0}, ", oQueueValues.Dequeue());
			}

			Console.WriteLine();
#endif // E07_COLLECTION_01
		}
	}
}
