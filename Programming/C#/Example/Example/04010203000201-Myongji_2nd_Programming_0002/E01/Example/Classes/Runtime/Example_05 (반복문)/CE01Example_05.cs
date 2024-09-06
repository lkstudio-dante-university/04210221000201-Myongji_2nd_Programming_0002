#define E05_WHILE
#define E05_FOR
#define E05_DO_WHILE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 반복문이란?
 * - 프로그램의 흐름을 제어하는 제어문 중 하나로서 조건을 만족 할 동안 프로그램의 특정 부분을 반복해서 실행하는 기능을
 * 의미한다. (즉, 반복문을 활용하면 반영구적으로 실행되는 프로그램을 제작하는 것이 가능하다.)
 * 
 * 단, 반복문의 조건을 잘못 작성 할 경우 반복 할 명령문을 무한히 실행하는 무한 루프에 빠질 수 있기 때문에 주위가
 * 필요하다.
 * 
 * C# 반복문 종류
 * - while
 * - for
 * - do ~ while
 * 
 * Ex)
 * while(조건문)
 * {
 *		조건문을 만족했을 경우 실행 할 명령문
 * }
 * 
 * for(초기절; 조건절; 반복절)
 * {
 *		조건절을 만족했을 경우 실행 할 명령문
 * }
 * 
 * do
 * {
 *		조건문을 만족했을 경우 실행 할 명령문
 * } while(조건문)
 */
namespace Example._04010203000201_M_2_Programming_0002.E01.Example.Classes.Runtime.Example_05
{
	/**
	 * Example 5
	 */
	internal class CE01Example_05
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E05_WHILE
			int i = 0;
			int nTimes = 0;

			Console.Write("횟수 입력 : ");
			int.TryParse(Console.ReadLine(), out nTimes);

			while(i < nTimes)
			{
				Console.Write("{0}, ", i + 1);
				i += 1;
			}

			Console.WriteLine();
#elif E05_FOR
			int nTimes = 0;

			Console.Write("횟수 입력 : ");
			int.TryParse(Console.ReadLine(), out nTimes);

			for(int i = 0; i < nTimes; ++i)
			{
				Console.Write("{0}, ", i + 1);
			}

			Console.WriteLine();
#elif E05_DO_WHILE
			/*
			 * do ~ while 반복문은 다른 반복문과 달리 반복에 대한 조건문을 나중에 검사하며 이러한 구조의 반복문을
			 * 후위 판단 반복문이라고 한다.
			 * 
			 * 전위 (사전) 판단 반복문 vs 후위 (사후) 판단 반복문
			 * - 전위 판단 반복문은 반복 할 명령문을 실행하기 전에 조건문을 먼저 검사하기 때문에 처음부터 조건이
			 * 거짓이라면 반복 할 명령문이 한번도 실행되지 않는다.
			 * 
			 * 반면, 후위 판단 반복문은 반복 할 명령문을 실행 후 조건문을 검사하기 때문에 처음부터 조건이 거짓이라고
			 * 하더라도 반드시 1 번 이상 실행되는 차이점이 존재한다.
			 */
			do
			{
				Console.WriteLine("Hello, World!");
			} while(false);
#endif // #if E05_WHILE
		}
	}
}
