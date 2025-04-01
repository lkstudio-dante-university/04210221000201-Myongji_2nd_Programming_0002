using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 연산자란?
 * - 데이터를 제어하기 위한 특별한 의미를 지니는 기호 (심볼) 를 의미한다. (즉, 연산자를 활용하면 특정 데이터를
 * 프로그램의 목적에 맞게 제어하는 것이 가능하다.)
 * 
 * C# 의 연산자는 피 연산자의 개수에 따라 단항 연산자, 이항 연산자, 삼항 연산자로 구분된다.
 * 
 * C# 주요 연산자 종류
 * - 산술 연산자 (+, -, *, /, %)
 * - 비교 연산자 (<, >, <=, >=, ==, !=)
 * - 할당 연산자 (=, +=, -=, *=, /=, %= 등등...)
 * - 논리 연산자 (&&, ||, !)
 * - 증감 연산자 (++, --)
 * - 비트 연산자 (&, |, ^, ~, <<, >>)
 * - 기타 연산자 (., 형 변환 연산자, 조건 연산자, 우선 순위 연산자 등등...)
 */
namespace Example._04210203000201_Myongji_2nd_Programming_0002.E01.Example.Classes.Runtime.Example_03
{
	/**
	 * Example 3
	 */
	internal class CE01Example_03
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			int nValA = 0;
			int nValB = 0;

			Console.Write("정수 (2 개) 입력 : ");

			/*
			 * Console.ReadLine 메서드는 콘솔 창으로부터 한 라인을 입력받는 역할을 수행한다. (즉, 해당 메서드를
			 * 활용하면 사용자로부터 특정 데이터를 입력받는 것이 가능하다.)
			 * 
			 * 단, Console.ReadLine 메서드는 단순히 라인을 입력받는 역할만을 수행하기 때문에 해당 메서드를 통해서
			 * 읽어들인 라인을 특정 데이터로 변환하는 작업이 필요하며 이때 Split 메서드를 활용하면 된다. (즉, Split
			 * 메서드는 문자열을 특정 문자를 기준으로 분할하는 역할을 수행한다.)
			 * 
			 * Ex)
			 * string oLine = "A B C";
			 * string[] oTokens = oLine.Split();		<- ["A", "B", "C"]
			 * 
			 * 기본적으로 Split 메서드는 공백을 기준으로 문자열을 분할하기 때문에 위의 경우 ["A", "B", "C"] 와
			 * 같은 결과를 얻는다는 것을 알 수 있다.
			 */
			string[] oTokens = Console.ReadLine().Split();

			// 데이터 개수가 부족 할 경우
			if(oTokens.Length < 2)
			{
				/*
				 * return 키워드는 점프문 중 하나로서 메서드를 즉시 종료시키는 역할을 수행한다. (즉, 해당 키워드를
				 * 사용하면 프로그램의 흐름이 해당 메서드를 호출한 곳으로 되돌아간다는 것을 알 수 있다.)
				 */
				return;
			}

			/*
			 * 기본 자료형은 TryParse 메서드를 지원하며 해당 메서드를 활용하면 문자열 데이터를 해당 자료형으로
			 * 변환하는 것이 가능하다.
			 */
			int.TryParse(oTokens[0], out nValA);
			int.TryParse(oTokens[1], out nValB);

			//int.TryParse(oTokens[0], out int nValC);

			/*
			 * C# 은 강력 형식 언어 (Strong Type Language) 이기 때문에 특정 데이터를 사용하기 위해서는 반드시
			 * 처리하기 위한 방법 (자료형) 을 결정해줘야한다.
			 * 
			 * 만약, 방법을 명시하지 않을 경우 C# 컴파일러에 의해서 자동으로 처리되기 때문에 원치 않는 결과가
			 * 나올 수  있다.
			 * 
			 * Ex)
			 * int nValA = 5;
			 * int nValB = 10;
			 * 
			 * float fResult = nValA / nValB;		<- 0
			 * 
			 * 위의 결과 정수와 정수를 연산했기 때문에 결과는 0.5 가 아닌 0 이 나온다는 것을 알 수 있다. (즉, 
			 * 연산의 결과는 연산에 사용 된 피연산자의 자료형을 따라간다는 것을 알 수 있다.)
			 */
			Console.WriteLine("=====> 산술 연산자 <=====");
			Console.WriteLine("{0} + {1} = {2}", nValA, nValB, nValA + nValB);
			Console.WriteLine("{0} - {1} = {2}", nValA, nValB, nValA - nValB);
			Console.WriteLine("{0} * {1} = {2}", nValA, nValB, nValA * nValB);
			Console.WriteLine("{0} / {1} = {2}", nValA, nValB, nValA / (float)nValB);
			Console.WriteLine("{0} % {1} = {2}", nValA, nValB, nValA % nValB);

			Console.WriteLine("\n=====> 비교 연산자 <=====");
			Console.WriteLine("{0} < {1} = {2}", nValA, nValB, nValA < nValB);
			Console.WriteLine("{0} > {1} = {2}", nValA, nValB, nValA > nValB);
			Console.WriteLine("{0} <= {1} = {2}", nValA, nValB, nValA <= nValB);
			Console.WriteLine("{0} >= {1} = {2}", nValA, nValB, nValA >= nValB);
			Console.WriteLine("{0} == {1} = {2}", nValA, nValB, nValA == nValB);
			Console.WriteLine("{0} != {1} = {2}", nValA, nValB, nValA != nValB);

			/*
			 * 논리 연산자는 논리 자료형의 데이터만 피 연산자로 사용하는 것이 가능하기 떄문에 주의가 필요하다.
			 * (즉, 논리 자료형 이외에 다른 자료형의 데이터를 피 연산자로 명시 할 경우 컴파일 에러가 발생한다는
			 * 것을 알 수 있다.)
			 */
			Console.WriteLine("\n=====> 논리 연산자 <=====");
			Console.WriteLine("{0} && {1} = {2}", nValA, nValB, nValA != 0 && nValB != 0);
			Console.WriteLine("{0} || {1} = {2}", nValA, nValB, nValA != 0 || nValB != 0);
			Console.WriteLine("!{0} = {1}", nValA, !(nValA != 0));

			/*
			 * 증감 연산자는 연산자의 명시 위치에 따라 전위 증감 연산자와 후위 증감 연산자로 구분된다.
			 * 
			 * 전위 증감 연산자는 선 증감 후 연산 순서에 따라 동작하며 후위 증감 연산자는 선 연산 후 증감 순서로
			 * 동작한다는 차이점이 존재한다. (즉, 전위 증감 연산자는 데이터를 먼저 증감 시킨 후 연산에 활용하는
			 * 반면 후위 증감 연산자는 연산을 먼저 진행 후 데이터를 증감 시킨다는 것을 알 수 있다.)
			 * 
			 * Ex)
			 * int nValA = 0;
			 * int nValB = 0;
			 * 
			 * int nResultA = ++nValA;		<- 1
			 * int nResultB = nValB++;		<- 0
			 * 
			 * ResultA 는 증감 연산자를 사용했기 때문에 1 이 되지만 ResultB 는 후위 증감을 사용했기 때문에 0 이
			 * 된다는 것을 알 수 있다.
			 * 
			 * 단, 동일한 변수에 대한 증감 연산을 한 라인에 작성 할 경우 원치 않는 결과가 나올 수 있기 때문에
			 * 추천하지 않는다.
			 * 
			 * Ex)
			 * int nVal = 0;
			 * int nResult = ++nVal + ++nVal + nVal--;
			 * 
			 * 위와 같은 명령문은 컴파일러에 의해 결과가 달라 질 수 있기 때문에 올바른 명령문이 아니라는 것을 알 수
			 * 있다.
			 */
			Console.WriteLine("\n=====> 증감 연산자 <=====");
			Console.WriteLine("++{0}, --{1} = {2}, {3}", nValA, nValB, ++nValA, --nValB);
			Console.WriteLine("{0}++, {1}-- = {2}, {3}", nValA, nValB, nValA++, nValB--);

			Console.WriteLine("\n=====> 후위 증감 연산자 후 <=====");
			Console.WriteLine("{0}, {1}", nValA, nValB);

			Console.WriteLine("\n=====> 비트 연산자 <=====");
			Console.WriteLine("{0:b} & {1:b} = {2:b}", nValA, nValB, nValA & nValB);
			Console.WriteLine("{0:b} | {1:b} = {2:b}", nValA, nValB, nValA | nValB);
			Console.WriteLine("{0:b} ^ {1:b} = {2:b}", nValA, nValB, nValA ^ nValB);
			Console.WriteLine("~{0:b} = {1:b}", nValA, ~nValA);
			Console.WriteLine("{0:b} << 1 = {1:b}", nValA, nValA << 1);
			Console.WriteLine("{0:b} >> 1 = {1:b}", nValB, nValB >> 1);

			/*
			 * 조건 연산자는 유일하게 피 연산자를 3 개 요구하기 때문에 삼항 연산자로도 불리운다. (즉, 해당 연산자를
			 * 제외한 다른 연산자는 모두 단항 연산자이거나 이항 연산자라는 것을 알 수 있다.)
			 */
			int nResult = (nValA < nValB) ? nValA : nValB;

			Console.WriteLine("\n=====> 조건 연산자 <=====");
			Console.WriteLine("({0} < {1}) ? {2} : {3} = {4}", nValA, nValB, nValA, nValB, nResult);
		}
	}
}
