/*
 * #define 명령어는 전처리기 심볼을 선언하는 역할을 수행한다. (즉, 해당 명령어는 C# 명령어가 아니기 때문에 
 * C# 컴파일러가 아닌 전처리기에 의해서 처리된다.)
 * 
 * 전처리기란?
 * - C# 으로 제작 된 명령문이 컴파일되기 전에 명령문을 튜닝하는 역할을 수행한다. (즉, C# 으로 제작 된 명령문은 전처리 
 * 과정을 거치고 나면 변화가 발생 할 수 있다는 것을 알 수 있다.)
 * 
 * 전처리기에 의해 처리 되는 명령문은 모두 # 기호로 시작하는 특징이 존재하기 때문에 C# 의 명령문과 쉽게 구분이
 * 가능하다.
 * 
 * 주로 활용되는 전처리기 명령어
 * - #define
 * - #if ~ #else ~ #endif
 * 
 * 전처리기는 C# 과 달리 { } 기호를 통해 영역을 구분하는 것이 불가능하기 때문에 반드시 #endif 명령어를 통해서 특정 
 * 전처리기 조건문이 종료되었다는 것을 명시해줘야한다.
 * 
 * Ex)
 * #if 조건 1
 *		// 조건 1 을 만족 할 경우
 *		
 * #elif 조건 2
 *		// 조건 2 를 만족 할 경우
 *		
 * #else
 *		// 조건 1 과 조건 2 를 모두 만족하지 않을 경우
 *		
 * #endif
 */
//#define E01_EXAMPLE
//#define P01_PRACTICE
#define T01_TRAINING

/*
 * C# 이란?
 * - Microsoft 에서 개발 된 고수준 프로그래밍 언어를 의미하며 게임을 비롯한 다양한 분야에서 활용되는 언어이다.
 * (즉, .Net 프레임워크를 활용하는데 최적화 된 언어라는 것을 알 수 있다.)
 * 
 * C# 은 Java 의 가상 머신과 비슷한 CLR (Common Language Runtime) 상에서 실행되기 때문에 크로스 플랫폼을 지원하는
 * 특징이 존재한다. (즉, C# 으로 제작 된 프로그램은 손쉽게 여러 플랫폼에서 구동시키는 것이 가능하다.)
 * 
 * 따라서, C# 은 JIT (Just In Time) 방식으로 동작하는 하이브리드 언어이기 때문에 컴파일 언어의 장점과 인터프리터
 * 언어의 장점을 모두 지니고 있다는 것을 알 수 있다.
 * 
 * CLR (Common Language Runtime) 이란?
 * - C# 으로 제작 된 프로그램을 구동시키는 환경을 의미한다. (즉, C# 으로 제작 된 명령문은 컴퓨터가 이해 할 수 있는
 * 기계어 코드로 변환되지 않는다는 것을 알 수 있다.)
 * 
 * C# 은 컴파일 과정을 거치고 나면 중간 언어 인 IL (Immediate Language) 코드로 변환되며 이를 CLR 이 읽어들여서
 * 최종적으로 기계어 코드로 변환시킨다. (즉, 기계어 코드가 실시간으로 생성되기 때문에 현재 실행 환경에 맞는 최적화 된
 * 코드가 생성된다는 것을 알 수 있다.)
 * 
 * 또한, CLR 은 기계어로 코드로 변환하는 것 뿐만 아니라 예외 처리, 언어 간의 호환성, 메모리 관리 등 프로그램이 
 * 구동되기 위해서 필요한 여러 기능을 지원하는 특징이 존재한다. (즉, CLR 은 C# 뿐만 아니라 다양한 언어를 지원하며 
 * 이를 활용해서 다양한 프로그램을 제작하는 것이 가능하다.)
 */

#if E01_EXAMPLE
/*
 * C# 의 모든 자료형의 위치는 네임 스페이스 경로로 명시해야한다. (즉, 해당 자료형이 선언 된 파일의 물리적인 경로가
 * 아니라 논리적인 경로가 사용된다는 것을 알 수 있다.)
 * 
 * 또한, C# 의 모든 명령문은 ; (세미 콜론) 기호로 마무리 되어야한다. (즉, C# 컴파일러는 해당 기호를 통해 명령문을
 * 식별한다는 것을 알 수 있다.)
 */
//E01.Example.Classes.Example_01.CE01Example_01.Start(args);
//E01.Example.Classes.Example_02.CE01Example_02.Start(args);
//E01.Example.Classes.Example_03.CE01Example_03.Start(args);
//E01.Example.Classes.Example_04.CE01Example_04.Start(args);
//E01.Example.Classes.Example_05.CE01Example_05.Start(args);
//E01.Example.Classes.Example_06.CE01Example_06.Start(args);
//E01.Example.Classes.Example_07.CE01Example_07.Start(args);
E01.Example.Classes.Example_08.CE01Example_08.Start(args);
//E01.Example.Classes.Example_09.CE01Example_09.Start(args);
#elif P01_PRACTICE

#elif T01_TRAINING
E01.Training.Classes.Training_01.CT01Training_01.Start(args);
#endif // #if E01_EXAMPLE
