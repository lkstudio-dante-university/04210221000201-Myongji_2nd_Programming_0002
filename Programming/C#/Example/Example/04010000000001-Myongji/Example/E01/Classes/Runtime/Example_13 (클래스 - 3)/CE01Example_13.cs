//#define E13_CLASS_01
//#define E13_CLASS_02
#define E13_CLASS_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 객체 지향 프로그래밍 3 대 요소
 * - 캡슐화 (정보 은닉)
 * - 상속
 * - 다형성
 * 
 * 캡슐화 (정보 은닉) 란?
 * - 클래스가 지니고 있는 멤버 중 민감한 멤버는 외부로부터 보호함으로서 객체를 좀 더 안전하게 제어하는 개념을
 * 의미한다. (즉, C# 은 접근 제어 지시자를 통해서 특정 클래스를 캡슐화하는 것이 가능하다.)
 * 
 * 상속이란?
 * - 클래스 간에 부모 - 자식 관계를 형성시킬 수 있는 기능을 의미한다. (즉, 자식 클래스는 부모 클래스가 지니고 있는
 * 멤버를 사용하는 것이 가능하다.)
 * 
 * 자식 클래스는 부모 클래스에 존재하는 멤버를 포함하기 때문에 상속을 활용하면 클래스 별로 중복되는 멤버를 줄이는
 * 것이 가능하다. (즉, 클래스 별로 공통되는 멤버는 특정 클래스에 선언하고 해당 클래스를 상속함으로서 중복을 최소화
 * 시키는 것이 가능하다.)
 * 
 * 단, C# 은 여러 부모 클래스를 상속하는 다중 상속을 지원하지 않기 때문에 상속 할 부모는 1 개로 제한된다는 특징이
 * 존재한다. (즉, 프로그래밍 언어에 따라 여러 클래스를 상속하는 것도 가능하다는 것을 알 수 있다.)
 * 
 * 또한, 상속을 무분별하게 사용 할 경우 클래스 간에 관계가 복잡해질 수 있기 때문에 현재 상속은 is a 의 관계가 성립
 * 할 때만 사용하는 것이 일반적이다.
 * 
 * C# 클래스 상속 방법
 * - class + 클래스 이름 + 부모 클래스
 * 
 * Ex)
 * class CBase
 * {
 *		// Do Something
 * }
 * 
 * class CDerived : CBase
 * {
 *		// Do Something
 * }
 * 
 * 위와 같이 Derived 클래스는 Base 클래스를 상속하고 있기 때문에 Base 클래스와 Derived 클래스는 부모 - 자식 관계를
 * 형성한다는 것을 알 수 있다. (즉, Derived 클래스는 Base 클래스에 존재하는 멤버를 사용하는 것이 가능하다.)
 * 
 * 다형성이란?
 * - 사물을 바라보는 시선에 따라 다양한 형태를 지니는 개념을 의미한다. (즉, 하나의 사물이 여러 역할을 수행한다는 것을
 * 알 수 있다.)
 * 
 * C# 은 클래스의 상속을 활용해서 제한적인 형태로 다형성을 흉내내는 것이 가능하다. (즉, 자식 클래스를 통해 생성 된
 * 객체를 부모 클래스 형으로 참조함으로서 다형성을 흉내 낼 수 있다.)
 * 
 * Ex)
 * class CBase
 * {
 *		// Do Something
 * }
 * 
 * class CDerived : CBase
 * {
 *		// Do Something
 * }
 * 
 * CBase oBase = new CDerived();
 * 
 * 위와 같이 Derived 클래스를 통해 생성 된 객체를 Base 형의 변수로 참조함으로서 Derived 객체를 Base 객체로 인지하는
 * 것이 가능하다.
 */
namespace _04010000000001_Myongji.Example.E01.Classes.Runtime.Example_13
{
	/**
	 * Example 13
	 */
	internal class CE01Example_13
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E13_CLASS_01
			var oBase = new CBase(10, 3.14f);
			var oDerived = new CDerived(20, 3.14f, "Hello, World!");

			/*
			 * ValFlt 멤버는 protected 보호 수준으로 명시되어있기 때문에 외부에서 접근이 불가능하다는 것을 알 수
			 * 있다.
			 */
			//oBase.ValFlt = 3.14f;

			Console.WriteLine("=====> 부모 클래스 <=====");
			oBase.ShowInfo();

			Console.WriteLine("\n=====> 자식 클래스 <=====");
			oDerived.ShowInfo();
#elif E13_CLASS_02
			CBase oBase = new CBase(10);

			/*
			 * Derived 변수는 Base 형 변수이지만 다형성에 의해서 Derived 클래스를 통해 생성 된 객체를 참조하는 것이
			 * 가능하다.
			 * 
			 * 단, 반대의 경우는 컴파일 에러가 발생한다. (즉, 자식 클래스 객체는 부모 클래스 형으로 참조하는 것이
			 * 가능하지만 부모 클래스 객체를 자식 클래스 형으로 참조하는 것은 불가능하다는 것을 알 수 있다.)
			 * 
			 * 만약, 현재 참조하고 있는 객체가 자식 클래스를 통해 생성 된 객체인지 검사하고 싶다면 is 키워드 또는
			 * as 키워드를 사용하면 된다.
			 * 
			 * is 키워드 vs as 키워드
			 * - 두 키워드 모두 형 변환이 가능한지 검사하는 역할을 수행한다.
			 * 
			 * is 키워드는 값 형식과 참조 형식 데이터에 모두 사용하는 것이 가능하며 결과 값으로 참 또는 거짓이
			 * 반환된다.
			 * 
			 * 반면, as 키워드는 참조 형식 데이터에만 사용하는 것이 가능하며 결과 값으로 형 변환이 가능할 경우
			 * 형 변환 된 참조 값이 반환되며 형 변환이 불가능 할 경우 null 값이 반환된다는 차이점이 존재한다.
			 */
			CBase oDerived = new CDerived(10, 3.14f);

			Console.WriteLine("=====> 부모 클래스 <=====");
			oBase.ShowInfo();

			Console.WriteLine("\n=====> 자식 클래스 <=====");

			/*
			 * Derived 변수는 Derived 클래스를 통해 생성 된 객체를 참조하고 있지만 Base 형으로 참조하고 있기 때문에
			 * Derived 클래스에 존재하는 ShowInfo 메서드가 아닌 Base 클래스에 존재하는 ShowInfo 메서드가 호출 된다는
			 * 것을 알 수 있다.
			 */
			oDerived.ShowInfo();
#elif E13_CLASS_03
			CBase oBase = new CBase(10);
			CBase oDerived = new CDerived(10, 3.14f);

			Console.WriteLine("=====> 부모 클래스 <=====");
			oBase.ShowInfo();

			Console.WriteLine("\n=====> 자식 클래스 <=====");

			/*
			 * ShowInfo 메서드는 Derived 클래스에서 재정의하고 있기 때문에 Base 에 존재하는 ShowInfo 메서드 대신에
			 * Derived 클래스에 존재하는 ShowInfo 메서드가 호출된다는 것을 알 수 있다.
			 */
			oDerived.ShowInfo();
#endif // #if E13_CLASS_01
		}

#if E13_CLASS_01
		/** 부모 클래스 */
		private class CBase
		{
			public int ValInt { get; set; } = 0;
			protected float ValFlt { get; set; } = 0.0f;

			/** 생성자 */
			public CBase(int a_nValInt, float a_fValFlt)
			{
				this.ValInt = a_nValInt;
				this.ValFlt = a_fValFlt;
			}

			/** 정보를 출력한다 */
			public void ShowInfo()
			{
				Console.WriteLine("Int : {0}", this.ValInt);
				Console.WriteLine("Float : {0}", this.ValFlt);
			}
		}

		/** 자식 클래스 */
		private class CDerived : CBase
		{
			public string ValStr { get; set; } = string.Empty;

			/*
			 * 상속 관계에 놓인 클래스의 생성자 호출 순서는 반드시 부모 클래스 -> 자식 클래스 순서로 호출되어야한다.
			 * (즉, 자식 클래스의 생성자가 호출되기 전에 부모 클래스의 생성자가 먼저 호출된다는 것을 알 수 있다.)
			 * 
			 * 따라서, 자식 클래스의 생성자에서는 반드시 부모 클래스의 생성자를 호출해줘야하며 만약 호출하지 않았을
			 * 경우 C# 컴파일러에 의해서 자동으로 부모 클래스의 기본 생성자를 호출하는 명령문이 추가된다. (즉, 부모
			 * 클래스에 기본 생성자가 없을 경우 컴파일 에러가 발생한다는 것을 알 수 있다.)
			 */
			/** 생성자 */
			public CDerived(int a_nValInt, float a_fValFlt, string a_oValStr) : base(a_nValInt, a_fValFlt)
			{
				this.ValStr = a_oValStr;
			}

			/*
			 * new 키워드는 부모 클래스와 자식 클래스에 동일한 이름의 멤버가 존재 할 경우 발생하는 컴파일 경고를
			 * 제거하는 역할을 수행한다. (즉, 부모 클래스와 자식 클래스에 동일한 이름의 멤버가 존재 할 경우
			 * C# 컴파일러는 이를 실수로 간주하고 경고를 발생시킨다는 것을 알 수 있다.)
			 */
			/** 정보를 출력한다 */
			public new void ShowInfo()
			{
				/*
				 * base 키워드는 부모 클래스를 참조하는 키워드를 의미한다. (즉, 해당 키워드를 활용하면 부모 클래스에
				 * 존재하는 멤버에 접근하는 것이 가능하다.)
				 * 
				 * 해당 키워드는 this 키워드와 마찬가지로 생략하는 것이 가능하지만 부모 클래스와 자식 클래스에 동일한
				 * 이름의 멤버가 존재 할 경우 우선 순위는 자식 클래스가 더 높기 때문에 이 경우에는 반드시 base
				 * 키워드를 사용해서 부모 클래스에 접근한다는 것을 명시해줘야한다.
				 */
				base.ShowInfo();
				Console.WriteLine("String : {0}", this.ValStr);

				/*
				 * ValFlt 멤버는 protected 보호 수준으로 명시되어 있기 때문에 자식 클래스에서 접근하는 것이 
				 * 가능하다.
				 */
				//this.ValFlt = 3.14f;
			}
		}
#elif E13_CLASS_02
		/** 부모 클래스 */
		private class CBase
		{
			public int ValInt { get; private set; } = 0;

			/** 생성자 */
			public CBase(int a_nValInt)
			{
				this.ValInt = a_nValInt;
			}

			/** 정보를 출력한다 */
			public void ShowInfo()
			{
				Console.WriteLine("Int : {0}", this.ValInt);
			}
		}

		/** 자식 클래스 */
		private class CDerived : CBase
		{
			public float ValFlt { get; private set; } = 0.0f;

			/** 생성자 */
			public CDerived(int a_nValInt, float a_fValFlt) : base(a_nValInt)
			{
				this.ValFlt = a_fValFlt;
			}

			/** 정보를 출력한다 */
			public new void ShowInfo()
			{
				base.ShowInfo();
				Console.WriteLine("Float : {0}", this.ValFlt);
			}
		}
#elif E13_CLASS_03
		/** 부모 클래스 */
		private class CBase
		{
			public int ValInt { get; private set; } = 0;

			/** 생성자 */
			public CBase(int a_nValInt)
			{
				this.ValInt = a_nValInt;
			}

			/*
			 * 가상 메서드란?
			 * - 메서드가 호출 될 때 호출 될 메서드를 동적으로 결정하는 기능을 의미한다. (즉, 가상 메서드는 호출 한
			 * 메서드와 실제 호출되는 메서드가 달라 질 수 있다는 것을 알 수 있다.)
			 * 
			 * 특정 메서드를 가상 메서드로 구현하고 싶다면 virtual 키워드를 사용하면 된다.
			 * 또한, virtual 키워드는 메서드 뿐만 아니라 프로퍼티와 인덱서에도 사용하는 것이 가능하다.
			 */
			/** 정보를 출력한다 */
			public virtual void ShowInfo()
			{
				Console.WriteLine("Int : {0}", this.ValInt);
			}
		}

		/** 자식 클래스 */
		private class CDerived : CBase
		{
			public float ValFlt { get; private set; } = 0.0f;

			/** 생성자 */
			public CDerived(int a_nValInt, float a_fValFlt) : base(a_nValInt)
			{
				this.ValFlt = a_fValFlt;
			}

			/*
			 * override 키워드는 부모 클래스에 존재하는 가상 메서드를 재정의하는 역할을 수행한다. (즉, 자식 
			 * 클래스에서 부모 클래스의 가상 메서드를 재정의하면 부모 클래스의 메서드 대신에 자식 클래스의 메서드가 
			 * 호출된다.)
			 */
			/** 정보를 출력한다 */
			public override void ShowInfo()
			{
				base.ShowInfo();
				Console.WriteLine("Float : {0}", this.ValFlt);
			}
		}
#endif // #if E13_CLASS_01
	}
}
