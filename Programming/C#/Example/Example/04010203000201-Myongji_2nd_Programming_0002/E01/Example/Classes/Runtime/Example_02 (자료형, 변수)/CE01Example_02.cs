using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 자료형이란?
 * - 데이터를 해석하기 위한 방법을 의미한다. (즉, 동일한 형태의 데이터라고 하더라도 자료형에 처리 결과가 달라질 수
 * 있다.)
 * 
 * 또한, 자료형은 처리 할 수 있는 데이터의 최대 범위를 제한하는 역할도 수행하기 때문에 제작하는 기능에 따라 적절한
 * 자료형을 사용하는 것이 중요하다. (즉, 적절하지 않은 자료형을 사용 할 경우 프로그램이 오작동하거나 효율성이
 * 떨어진다는 것을 알 수 있다.)
 * 
 * C# 의 자료형은 크게 값 형식 자료형과 참조 형식 자료형으로 구분된다.
 * 
 * 값 형식 자료형이란?
 * - 데이터 자체를 다루는 자료형을 의미하며 해당 형식 자료형으로 선언 된 변수를 다른 변수에 할당 할 경우 사본 
 * 데이터가 만들어진다는 특징이 존재한다. (즉, 사본 변수가 지닌 데이터를 변경해도 원본 변수가 지닌 데이터는 영향을 
 * 받지 않는다는 것을 알 수 있다.)
 * 
 * 또한, 값 형식 자료형의 데이터는 시스템에 의해서 메모리가 관리되기 때문에 참조 형식 자료형의 데이터보다 내부적으로 
 * 메모리 관리가 수월하다는 장점이 존재한다.
 * 
 * 참조 형식 자료형이란?
 * - 데이터를 지니고 있는 대상의 참조 값을 다루는 자료형을 의미하며 해당 형식 자료형으로 선언 된 변수를 다른 변수에 
 * 할당 할 경우 약한 참조가 발생한다는 특징이 존재한다. (즉, 사본 변수를 통해 참조하고 있는 대상의 데이터를 변경 할 
 * 경우 원본 변수도 영향을 받는다는 것을 알 수 있다.)
 * 
 * 또한, 참조 형식 자료형의 데이터는 가비지 컬렉션에 의해서 메모리가 관리되기 때문에 잘못 사용 할 경우 프로그램의
 * 성능을 저하시킬 수 있다는 단점이 존재한다.
 * 
 * 가비지 컬렉션이란?
 * - C# 에서 동적으로 할당 된 메모리를 관리해주는 기능을 의미한다. (즉, 가비지 컬렉션은 CLR 이 제공해주는 여러 기능
 * 중 하나라는 것을 알 수 있다.)
 * 
 * C# 은 가비지 컬렉션이 존재하기 때문에 동적으로 할당 된 메모리도 자동으로 관리하는 것이 가능하다. (즉, C# 의 
 * 참조 형식 자료형의 데이터는 가비지 컬렉션에 의해서 관리된다는 것을 알 수 있다.)
 * 
 * 단, 가비지 컬렉션이 수행되기 위해서는 컴퓨터의 자원을 필요로하기 때문에 빈번하게 수행 될 경우 프로그램의 성능이
 * 저하되는 단점이 존재한다.
 * 
 * 따라서, C# 으로 제작 된 프로그램이 좋은 성능을 발휘하기 위해서는 가능하면 가비지 컬렉션이 수행되는 횟수를 줄이는
 * 것이 관건이다.
 * 
 * C# 값 형식 자료형 종류
 * // 정수
 * - byte or sbyte : 1 Bytes
 * - short or ushort : 2 Bytes
 * - int or uint : 4 Bytes
 * - long or ulong : 8 Bytes
 * 
 * // 실수
 * - float : 4 Bytes
 * - double : 8 Bytes
 * - decimal : 16 Bytes
 * 
 * // 논리
 * - bool : 1 Bytes
 * 
 * // 문자
 * - char : 2 Bytes
 * 
 * // 기타
 * - struct
 * 
 * C# 참조 형식 자료형 종류
 * - class
 * - object
 * - string
 * 
 * object 자료형이란?
 * - C# 의 모든 자료형은 직/간접적으로 object 자료형을 상속하도록 설계되어있다. (즉, C# 의 모든 자료형은 클래스라는
 * 것을 알 수 있다.)
 * 
 * C# 은 객체 지향 프로그래밍을 지원하기 때문에 object 자료형을 사용하면 모든 형식의 데이터를 제어 할 수 있다는
 * 장점이 존재한다.
 * 
 * 단, object 자료형은 참조 형식 자료형에 속하기 때문에 동일한 참조 형식 자료형의 데이터를 제어 할 때는 별다른
 * 문제가 없지만 값 형식 자료형의 데이터를 제어 할 경우 내부적으로 발생하는 Boxing/Unboxing 에 의해서 프로그램의
 * 성능을 저하시킬 수 있다는 단점이 존재한다.
 * 
 * Boxing/Unboxing 이란?
 * - object 자료형 변수에 값 형식 자료형의 데이터를 할당 할 경우 내부적으로 해당 데이터를 저장하기 위한 메모리 
 * 동적 할당이 발생하며 이를 Boxing 이라고 한다.
 * 
 * 반대로 Boxing 에 의해 할당 된 메모리로부터 데이터를 가져오는 것을 Unboxing 이라고 한다. (즉, Unboxing 은
 * 데이터를 가져오는 것이기 때문에 Boxing 에 비해서 큰 문제가 되지 않는다는 것을 알 수 있다.)
 * 
 * C# 에서 Boxing 은 가비지 컬렉션이 자주 수행되는 원인이 될 수 있기 때문에 가능하면 사용하지 않는 것을 추천한다.
 * 
 * 변수란?
 * - 데이터를 저장하거나 읽어들일 수 있는 공간을 의미한다. (즉, 변수를 활용하면 특정 데이터를 저장 후 필요에 따라
 * 재사용 할 수 있다는 것을 알 수 있다.)
 * 
 * 변수는 메모리 상에 생성되는 공간이기 때문에 해당 공간에 접근하기 위한 방법이 필요하며 C# 은 이를 위해서 변수에
 * 이름을 부여 할 수 있는 기능을 제공한다. (즉, C# 사용자는 변수 이름을 통해 특정 변수를 제어하는 것이 가능하다.)
 * 
 * 단, 변수 이름에 사용되는 문자는 알파벳을 비롯한 다양한 문자를 지원하지만 알파벳 대/소문자, _ (언더 스코어), 
 * 숫자만을 활용해서 변수 이름을 작성하는 것을 추천한다. (즉, 해당 종류의 문자만을 활용해서 변수 이름을 작성하는 것이
 * 오랜 관례라는 것을 알 수 있다.)
 * 
 * 또한, 숫자는 첫 문자에는 사용하는 것이 불가능하기 때문에 주의가 필요하다.
 * 
 * Ex)
 * int nValA = 0;		<- 첫 문자가 숫자가 아니기 때문에 컴파일 에러가 발생하지 않는다.
 * int 01nVal = 0;		<- 첫 문자가 숫자이기 때문에 컴파일 에러가 발생한다.
 */
namespace Example._04010203000201_M_2_Programming_0002.E01.Example.Classes.Runtime.Example_02
{
	/**
	 * Example 2
	 */
	internal class CE01Example_02
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			/*
			 * C# 의 모든 자료형은 클래스이기 때문에 . (멤버 지정 연산자) 를 통해 하위에 존재하는 여러 기능을
			 * 사용하는 것이 가능하다.
			 * 
			 * 또한, C# 의 변수는 사용되기 전에 반드시 초기화가 되어있어야하기 때문에 특정 변수를 선언 할 때
			 * 초기화를 해주는 것을 추천한다.
			 */
			byte nByteA = byte.MaxValue;
			sbyte nByteB = sbyte.MaxValue;

			short nShortA = short.MaxValue;
			ushort nShortB = ushort.MaxValue;

			int nIntA = int.MaxValue;
			uint nIntB = uint.MaxValue;

			long nLongA = long.MaxValue;
			ulong nLongB = ulong.MaxValue;

			/*
			 * Console.Write 계열 메서드는 서식화 된 출력을 지원하기 때문에 다양한 문장을 출력하는 것이 가능하다.
			 * (즉, 서식화 된 출력을 지원하기 때문에 특정 데이터를 사용해서 문장을 구성 할 수 있다는 것을 알 수
			 * 있다.)
			 * 
			 * 단, 서식 문자에 명시되는 숫자를 잘못 사용 할 경우 내부적으로 예외가 발생하기 때문에 주의 할 필요가
			 * 있다. (즉, 서식 문자에 명시하는 숫자는 매개 변수의 개수와 연관 되어있다는 것을 알 수 있다.)
			 */
			Console.WriteLine("=====> 정수 <=====");
			Console.WriteLine("byte : {0}, {1}", nByteA, nByteB);
			Console.WriteLine("short : {0}, {1}", nShortA, nShortB);
			Console.WriteLine("int : {0}, {1}", nIntA, nIntB);
			Console.WriteLine("long : {0}, {1}", nLongA, nLongB);

			/*
			 * decimal 자료형이란?
			 * - 고정 소수점 방식으로 동작하는 자료형을 의미한다. (즉, 고정 소수점 방식을 사용하기 때문에 부동 소수점
			 * 오차가 존재하지 않는다는 것을 알 수 있다.)
			 * 
			 * decimal 자료형은 오차 없이 소수점을 표현하는 것이 가능하지만 많은 메모리를 필요로하며 연산 속도가
			 * 느리다는 단점이 존재한다. (즉, 부동 소수점 방식은 FPU 에 의해서 빠르게 연산 되지만 고정 소수점 방식은
			 * 따로 연산하기 위한 장치가 존재하지 않는다는 것을 알 수 있다.)
			 */
			float fFloat = float.MaxValue;
			double dblDouble = double.MaxValue;
			decimal dmDecimal = decimal.MaxValue;

			Console.WriteLine("\n=====> 실수 <=====");
			Console.WriteLine("float : {0}", fFloat);
			Console.WriteLine("double : {0}", dblDouble);
			Console.WriteLine("decimal : {0}", dmDecimal);

			bool bIsBoolA = true;
			bool bIsBoolB = false;

			char chCharA = 'A';
			char chCharB = 'B';
			char chCharC = 'C';

			string oStrA = "ABC";
			string oStrB = "DEF";

			Console.WriteLine("\n=====> 기타 <=====");
			Console.WriteLine("bool : {0}, {1}", bIsBoolA, bIsBoolB);
			Console.WriteLine("char : {0}, {1}, {2}", chCharA, chCharB, chCharC);
			Console.WriteLine("string : {0}, {1}", oStrA, oStrB);

			/*
			 * object 자료형 변수에 값 형식 자료형의 데이터를 할당 할 경우 Boxing 이 발생한다. (즉, 내부적으로
			 * 메모리 동적 할당이 발생한다는 것을 알 수 있다.)
			 */
			object oObjA = 10;
			object oObjB = 3.14f;
			object oObjC = "Hello, World!";

			/*
			 * object 자료형 변수로부터 데이터를 가져오기 위해서는 형 변환 연산자를 사용해야한다. (즉, 형 변환
			 * 연산자를 사용 할 경우 내부적으로 데이터를 가져오기 위한 Unboxing 이 발생한다는 것을 알 수 있다.)
			 */
			Console.WriteLine("\n=====> object <=====");
			Console.WriteLine("{0}, {1}, {2}", (int)oObjA, (float)oObjB, (string)oObjC);
		}
	}
}
