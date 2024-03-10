/*
 * using 키워드란?
 * - 특정 네임 스페이스 하위에 존재하는 기능을 가져오는 역할을 수행한다. (즉, 해당 키워드를 통해서 특정
 * 네임 스페이스에 존재하는 기능을 가져옴으로서 C# 이 제공하는 여러 라이브러리를 사용하는 것이 가능하다.)
 * 
 * 만약, using 키워드를 사용하지 않고 특정 네임 스페이스 하위에 존재하는 기능을 사용하고 싶다면 네임 스페이스
 * 경로를 명시해주면 된다. (즉, 기능을 사용 할 때 마다 네임 스페이스 경로를 명시해야되기 때문에 자주 사용 할 경우
 * 귀찮아진다는 것을 알 수 있다.)
 * 
 * Ex)
 * Console.WriteLine("ABC");
 * System.Console.WriteLine("ABC");
 * 
 * 위와 같이 System 네임 스페이스 하위에 존재하는 Console 클래스를 사용하기 위해서 매번 네임 스페이스 경로를
 * 입려해주거나 using 키워드를 통해 네임 스페이스 하위에 존재하는 기능을 가져오면 된다. (즉, using 키워드로
 * 가져온 기능은 네임 스페이스 경로를 명시하지 않고 사용하는 것이 가능하다.)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 네임 스페이스란?
 * - 구조체 및 클래스와 같은 자료형을 명시 할 수 있는 영역을 의미한다. (즉, 네임 스페이스를 활용하면 특정 기능과
 * 연관 된 자료형끼리 그룹을 지어서 관리하는 것이 가능하다.)
 */
namespace E01.Example.Classes.Example_01
{
	/**
	 * Example 1
	 */
	internal class CE01Example_01
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			/*
			 * Console 클래스는 문자열을 비롯한 여러 데이터를 콘솔 창에 출력하거나 입력받는 역할을 수행한다. (즉,
			 * 해당 클래스를 활용하면 손쉽게 원하는 문장을 화면 상에 출력하는 것이 가능하다.)
			 * 
			 * Console.Write 메서드 vs Console.WriteLine 메서드
			 * - 두 메서드 모두 특정 데이터를 콘솔 창에 출력하는 역할을 수행한다.
			 * Console.Write 메서드는 입력으로 명시 된 데이터를 단순히 콘솔 창에 출력하는 역할을 수행한다.
			 * 
			 * 반면, Console.WriteLine 메서드는 데이터를 콘솔 창에 출력 후 개행 처리까지 해주는 차이점이 존재한다.
			 * (즉, 하나의 문장을 출력하기 위해서 Write 메서드가 여러 번 호출 되어야 할 경우 Write 메서드가 좀 더
			 * 효율적이라는 것을 알 수 있다.)
			 */
			Console.WriteLine("Hello, World!");
		}
	}
}
