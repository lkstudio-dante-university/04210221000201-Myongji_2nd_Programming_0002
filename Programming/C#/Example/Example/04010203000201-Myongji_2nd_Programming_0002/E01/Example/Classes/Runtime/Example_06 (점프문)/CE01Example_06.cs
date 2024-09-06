#define E06_BREAK
#define E06_CONTINUE
#define E06_GOTO

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 점프문이란?
 * - 프로그램의 흐름을 제어하는 제어문 중 하나로서 프로그램의 흐름을 특정 위치로 이동시키는 기능을 의미한다. (즉, 
 * 점프문을 활용하면 상황에 맞게 프로그램의 흐름을 제어하는 것이 가능하다.)
 * 
 * C# 점프문 종류
 * - break
 * - continue
 * - return
 * - goto
 * 
 * break 문이란?
 * - switch ~ case 조건문과 반복문 내부에서만 사용 할 수 있는 기능으로서 프로그램의 흐름을 제어문 밖으로 이동시키는
 * 역할을 수행한다.
 * 
 * continue 문이란?
 * - 반복문 내부에서만 사용 할 수 있는 기능으로서 프로그램의 현재 흐름을 생략하고 다음 흐름으로 이동시키는 역할을
 * 수행한다.
 * 
 * return 문이란?
 * - 메서드 내부에서만 사용 할 수 있는 기능으로서 프로그램의 흐름을 메서드를 호출한 곳으로 되돌리는 역할을 수행한다.
 * 
 * 또한, 메서드가 반환 값이 존재 할 경우 해당 값을 메서드를 호출한 곳으로 넘겨주는 역할도 수행한다. (즉, return 문의
 * 역할은 2 가지라는 것을 알 수 있다.)
 * 
 * goto 문이란?
 * - 제한 없이 프로그램의 흐름을 원하는 곳으로 이동시킬 수 있는 강력한 기능을 의미한다.
 * 단, goto 문을 남용 할 경우 프로그램의 흐름이 복잡해지기 때문에 가능하면 사용하지 않는 것을 추천한다.
 */
namespace Example._04010203000201_M_2_Programming_0002.E01.Example.Classes.Runtime.Example_06
{
	/**
	 * Example 6
	 */
	internal class CE01Example_06
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E06_BREAK
			int i = 0;

			while(true)
			{
				Console.Write("{0}, ", i + 1);
				i += 1;

				// 반복 종료가 가능 할 경우
				if(i >= 5)
				{
					break;
				}
			}

			Console.WriteLine();
#elif E06_CONTINUE
			int i = 0;
			int nTimes = 0;

			Console.Write("숫자 입력 : ");
			int.TryParse(Console.ReadLine(), out nTimes);

			Console.WriteLine("=====> while <=====");

			while(i < nTimes)
			{
				// 짝수 일 경우
				if((i + 1) % 2 <= 0)
				{
					i += 1;

					/*
					 * while 계열 반복문에서 continue 문을 사용 할 경우에는 반복을 종료시킬 명령문이 실행되었는지
					 * 주의가 필요하다. (즉, continue 문을 사용 할 경우 반복을 종료시킬 명령문의 실행을 생략함으로서
					 * 원치 않는 무한 루프에 빠질 수 있다는 것을 알 수 있다.)
					 */
					continue;
				}

				Console.Write("{0}, ", i + 1);
				i += 1;
			}

			Console.WriteLine("\n\n=====> for <=====");

			for(i = 0; i < nTimes; ++i)
			{
				// 짝수 일 경우
				if((i + 1) % 2 <= 0)
				{
					/*
					 * for 반복문에서는 while 문에 비해 좀더 안전하게 continue 문을 사용하는 것이 가능하다. (즉,
					 * for 반복문은 현재 반복 할 명령문의 흐름을 생략해도 반복절이 실행되기 때문에 무한 루프에
					 * 빠지는 실수를 줄이는 것이 가능하다.)
					 */
					continue;
				}

				Console.Write("{0}, ", i + 1);
			}

			Console.WriteLine();
#elif E06_GOTO
			int i = 0;
			int nTimes = 0;

			Console.Write("숫자 입력 : ");
			int.TryParse(Console.ReadLine(), out nTimes);

			/*
			 * goto 문을 사용해서 프로그램의 흐름을 이동시키기 위해서는 레이블을 명시해줘야한다. (즉, 레이블은
			 * 프로그램의 흐름이 이동 할 지점이라는 것을 알 수 있다.)
			 * 
			 * goto 레이블은 : (콜론) 을 통해서 간단하게 명시하는 것이 가능하다.
			 */
E06_GOTO_LOOP_START:
			Console.Write("{0}, ", i + 1);
			i += 1;

			// 반복 종료가 가능 할 경우
			if(i >= nTimes)
			{
				goto E06_GOTO_LOOP_END;
			}

			goto E06_GOTO_LOOP_START;

E06_GOTO_LOOP_END:
			Console.WriteLine();
#endif // #if E06_BREAK
		}
	}
}
