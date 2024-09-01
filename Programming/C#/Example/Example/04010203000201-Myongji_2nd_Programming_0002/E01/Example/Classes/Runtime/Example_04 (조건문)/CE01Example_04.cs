//#define E04_IF_ELSE
#define E04_SWITCH_CASE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 제어문이란?
 * - 프로그램의 흐름을 제어하는 기능을 의미한다. (즉, 제어문을 활용하면 프로그램의 목적에 맞게 다양한 결과를
 * 만들어내는 것이 가능하다.)
 * 
 * C# 제어문 종류
 * - 조건문
 * - 반복문
 * - 점프문
 * 
 * 조건문이란?
 * - 프로그램의 흐름을 제어하는 제어문 중 하나로서 특정 조건에 따라 프로그램의 흐름을 분산시키는 기능을 의미한다. 
 * (즉, 조건문을 활용하면 다양한 결과를 만들어내는 프로그램을 제작하는 것이 가능하다.)
 * 
 * 단, 조건문은 여러 흐름 중 하나의 흐름만을 선택하는 것이 가능하기 때문에 주어진 조건을 만족하는 경우가 2 개 이상 일
 * 경우 처음 만족한 조건문에 해당하는 명령문을 실행한다. (즉, 여러 조건을 만족한다고 하더라도 하나의 명령문만 실행
 * 된다는 것을 알 수 있다.)
 * 
 * C# 조건문 종류
 * - if ~ else
 * - switch ~ case
 * 
 * Ex)
 * if(조건문 A)
 * {
 *		조건문 A 를 만족했을 경우 실행 할 명령문
 * }
 * else if(조건문 B)
 * {
 *		조건문 B 를 만족했을 경우 실행 할 명령문
 * }
 * else
 * {
 *		조건문 A 와 조건문 B 를 모두 만족하지 않았을 경우 실행 할 명령문
 * }
 * 
 * switch(데이터)
 * {
 * case 조건문 A:
 *		조건문 A 를 만족했을 경우 실행 할 명령문
 *		
 * case 조건문 B:
 *		조건문 B 를 만족했을 경우 실행 할 명령문
 *		
 * default:
 *		조건문 A 와 조건문 B 를 모두 만족하지 않았을 경우 실행 할 명령문
 * }
 * 
 * if ~ else 조건문 vs switch ~ case 조건문
 * - if ~ else 조건문은 비교 연산자를 비롯한 여러 연산자를 활용해서 조건문을 구성 할 수 있기 때문에 다양한 조건문을
 * 만들어내는 것이 가능하다.
 * 
 * 반면, switch ~ case 조건문은 동등 비교만을 지원하기 때문에 if ~ else 조건문에 비해 다양한 조건문을 구성 할 수
 * 없다는 제한이 존재한다.
 * 
 * 단, switch ~ case 조건문은 동등 비교만을 지원하기 때문에 C# 컴파일러에 의해서 최적화 될 여지가 있다는 장점이
 * 존재한다. (즉, switch ~ case 조건문은 특정 상황 일 경우 if ~ else 조건문보다 빠르게 동작한다는 것을 알 수 있다.)
 */
namespace Example._04010203000201_Myongji_2nd_Programming_0002.E01.Example.Classes.Runtime.Example_04
{
	/**
	 * Example 4
	 */
	internal class CE01Example_04
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E04_IF_ELSE
			int nScore = 0;

			Console.Write("점수 입력 : ");
			int.TryParse(Console.ReadLine(), out nScore);

			Console.Write("결과 : ");

			// F 학점 일 경우
			if(nScore < 60)
			{
				Console.WriteLine("F");
			}
			else
			{
				// A 학점 일 경우
				if(nScore >= 90)
				{
					Console.WriteLine("A");
				}
				// B 학점 일 경우
				else if(nScore >= 80)
				{
					Console.WriteLine("B");
				}
				// C 학점 일 경우
				else if(nScore >= 70)
				{
					Console.WriteLine("C");
				}
				else
				{
					Console.WriteLine("D");
				}
			}
#elif E04_SWITCH_CASE
			int nScore = 0;

			Console.Write("점수 입력 : ");
			int.TryParse(Console.ReadLine(), out nScore);

			Console.Write("결과 : ");

			/*
			 * switch ~ case 의 각 case 문은 반드시 break 키워드를 명시해줘야한다. (즉, break 키워드를 명시하지
			 * 않을 경우 컴파일 에러가 발생한다는 것을 알 수 있다.)
			 */
			switch(nScore / 10)
			{
				case 9:
				case 10:
					Console.WriteLine("A");
					break;

				case 8:
					Console.WriteLine("B");
					break;

				case 7:
					Console.WriteLine("C");
					break;

				case 6:
					Console.WriteLine("D");
					break;

				default:
					Console.WriteLine("F");
					break;
			}
#endif // #if E04_IF_ELSE
		}
	}
}
