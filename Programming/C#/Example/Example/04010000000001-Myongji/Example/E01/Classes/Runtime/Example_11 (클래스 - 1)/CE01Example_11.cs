//#define E11_CLASS_01
//#define E11_CLASS_02
#define E11_CLASS_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 클래스란?
 * - 변수와 메서드 등을 하나로 묶어서 그룹화 시킬 수 있는 기능을 의미한다. (즉, 클래스를 활용하면 연관 된 변수와 
 * 메서드 등을 하나로 묶어서 관리 및 제어하는 것이 가능하다)
 * 
 * C# 은 객체 지향 프로그래밍 패러다임을 지원하는 프로그래밍 언어이기 때문에 객체 (사물) 을 표현하는 것이 가능하며
 * 이러한 객체는 클래스를 통해서 정의하는 것이 가능하다. (즉, 사물이 지니는 특징을 크게 2 가지로 나누어서 사물의
 * 속성은 변수를 통해서 표현하고 사물의 행위는 메서드를 통해서 표현 할 수 있다.)
 * 
 * C# 클래스 선언 방법
 * - class + 클래스 이름 + 클래스 멤버 (변수, 메서드 등등...)
 * 
 * Ex)
 * class CClassSome
 * {
 *		int m_nVal = 0;
 *		
 *		void ShowInfo()
 *		{
 *			// Do Something
 *		}
 * }
 * 
 * var oObjSome = new CClassSome();
 * 
 * 위와 같이 선언 된 클래스는 자료형처럼 사용하는 것이 가능하기 때문에 new 키워드를 통해서 객체를 생성하는 것이
 * 가능하다. (즉, 클래스는 객체를 생성하기 위한 틀처럼 활용된다는 것을 알 수 있다.)
 * 
 * 객체 지향 프로그래밍이란?
 * - 프로그램의 구조를 설계하기 위한 방법 중 하나로서 특정 역할을 수행하는 사물들을 정의하고 사물 간에 상호작용을
 * 통해 프로그램을 제작하는 것을 의미한다. (즉, 객체 지향 프로그래밍에서는 사물이 가장 핵심이 된다는 것을 알 수 있다.)
 */
namespace _04010000000001_Myongji.Example.E01.Classes.Runtime.Example_11
{
	/**
	 * Example 11
	 */
	internal class CE01Example_11
	{
		public static void LevelUp(ref int a_nLV,
			ref int a_nHP, ref int a_nATK, ref int a_nDEF)
		{
			a_nLV += 1;
			a_nHP += 10;
			a_nATK += 15;
			a_nDEF += 5;
		}

		/** 초기화 */
		public static void Start(string[] args)
		{
			int nPlayerALV = 0;
			int nPlayerAHP = 0;
			int nPlayerAATK = 0;
			int nPlayerADEF = 0;

			int nPlayerBLV = 0;
			int nPlayerBHP = 0;
			int nPlayerBATK = 0;
			int nPlayerBDEF = 0;

			LevelUp(ref nPlayerBLV,
				ref nPlayerAHP, ref nPlayerAATK, ref nPlayerADEF);



#if E11_CLASS_01
			/*
			 * 클래스를 통해서 생성 된 객체는 하위에 변수와 메서드 등을 지니고 있으며 이러한 멤버는 
			 * . (멤버 접근 연산자) 를 통해서 접근하는 것이 가능하다. (즉, 일반적으로 클래스의 멤버는 객체마다
			 * 개별적으로 지니고 있다는 것을 알 수 있다.)
			 * 
			 * 일반적인 멤버 변수 및 멤버 메서드 등은 각 객체마다 개별적으로 존재하기 때문에 특정 멤버에 접근하기
			 * 위해서는 반드시 객체를 지정해 줄 필요가 있다. (즉, 객체를 지정하지 않으면 멤버에 접근하는 것이
			 * 불가능하다.)
			 */
			var oPlayerA = new CPlayer();
			oPlayerA.m_nLV = 10;
			oPlayerA.m_nHP = 30;
			oPlayerA.m_nATK = 15;

			var oPlayerB = new CPlayer();
			oPlayerB.m_nLV = 50;
			oPlayerB.m_nHP = 150;
			oPlayerB.m_nATK = 75;

			Console.WriteLine("=====> 플레이어 A <=====");
			oPlayerA.ShowInfo();

			Console.WriteLine("\n=====> 플레이어 B <=====");
			oPlayerB.ShowInfo();
#elif E11_CLASS_02
			var oPlayerA = new CPlayer();
			oPlayerA.m_nLV = 10;
			oPlayerA.m_nHP = 30;
			oPlayerA.m_nATK = 15;

			var oPlayerB = new CPlayer(50, 150, 75);

			Console.WriteLine("=====> 플레이어 A <=====");
			oPlayerA.ShowInfo();

			Console.WriteLine("\n=====> 플레이어 B <=====");
			oPlayerB.ShowInfo();
#elif E11_CLASS_03
			var oPlayerA = new CPlayer();
			oPlayerA.SetLV(10);
			oPlayerA.SetHP(30);
			oPlayerA.SetATK(15);

			var oPlayerB = new CPlayer(50, 150, 75);

			Console.WriteLine("=====> 플레이어 A <=====");
			oPlayerA.ShowInfo();

			Console.WriteLine("\n=====> 플레이어 B <=====");
			oPlayerB.ShowInfo();
#endif // #if E11_CLASS_01
		}

#if E11_CLASS_01
		/** 플레이어 */
		private class CPlayer
		{
			/*
			 * 클래스는 변수 및 메서드 등을 그룹화시키는 기능이기 때문에 클래스 내부에는 변수 및 메서드 등을 자유롭게
			 * 명시하는 것이 가능하다.
			 * 
			 * 또한, 이렇게 클래스 내부에 선언 된 변수 및 메서드 등은 일반적으로 멤버라고 지칭된다.
			 */
			public int m_nLV = 0;
			public int m_nHP = 0;
			public int m_nATK = 0;

			/** 정보를 출력한다 */
			public void ShowInfo()
			{
				/*
				 * 클래스 내부에 구현 된 메서드는 일반적인 메서드와 달리 동일한 클래스에 존재하는 변수에 접근하는 
				 * 것이  가능하다. (즉, 동일한 클래스에 존재하는 변수의 데이터는 메서드의 입력으로 전달 할 필요가 
				 * 없다는 것을 알 수 있다.)
				 */
				Console.WriteLine("LV : {0}", m_nLV);
				Console.WriteLine("HP : {0}", m_nHP);
				Console.WriteLine("ATK : {0}", m_nATK);
			}
		}
#elif E11_CLASS_02
		/** 플레이어 */
		private class CPlayer
		{
			public int m_nLV = 0;
			public int m_nHP = 0;
			public int m_nATK = 0;

			/*
			 * 생성자란?
			 * - 객체가 생성 될 때 가장 먼저 호출되는 특수한 메서드를 의미한다. (즉, 생성자는 new 키워드를 통해서
			 * 객체를 생성 할 때 C# 컴파일러에 의해서 자동으로 호출된다는 것을 알 수 있다.)
			 * 
			 * 생성자는 객체를 생성 할 때 가장 먼저 호출되는 메서드이기 때문에 객체를 생성과 동시에 초기화하는데 
			 * 활용된다. (즉, 생성자를 활용하면 객체를 초기화하는 것이 가능하다.)
			 * 
			 * 또한, 특정 객체를 생성하기 위해서는 반드시 해당 객체의 생성자가 호출되어야한다. (즉, 생성자가 호출되지
			 * 않았다는 것은 객체가 정상적으로 생성되지 않았다는 것을 의마한다.)
			 * 
			 * 따라서, 클래스에 생성자를 구현하지 않았을 경우 C# 컴파일러에 의해서 자동으로 생성자가 구현되며 이러한
			 * 생성자를 기본 생성자라고 한다. (즉, C# 컴파일러가 자동으로 생성자를 구현해주기 때문에 생성자가 없는
			 * 클래스도 객체화 시키는 것이 가능하다.)
			 * 
			 * 단, 클래스에 생성자가 존재 할 경우 C# 컴파일러는 더이상 기본 생성자를 구현해주지 않기 때문에 기본
			 * 생성자가 필요 할 경우 이를 직접 구현해줘야한다. (즉, 생성자 또한 메서드이기 때문에 메서드 오버로딩을
			 * 이용해서 여러 생성자를 구현하는 것이 가능하다.)
			 * 
			 * 위임 생성자란?
			 * - 생성자에서 동일한 클래스에 존재하는 다른 생성자를 호출 할 수 있는 기능을 의미한다. (즉, 위임 생성자를
			 * 활용하면 객체를 초기화하기 위한 명령문의 중복을 줄이는 것이 가능하다.)
			 * 
			 * C# 클래스는 this 키워드를 지원하며 해당 키워드를 이용하면 다른 생성자를 호출하는 것이 가능하다.
			 * (즉, this 키워드는 객체 자기 자신을 의미한다.)
			 */
			/** 생성자 */
			public CPlayer() : this(0, 0, 0)
			{
				// Do Something
			}

			/** 생성자 */
			public CPlayer(int a_nLV, int a_nHP, int a_nATK)
			{
				/*
				 * this 키워드는 객체 자신을 나타내는 키워드이기 때문에 해당 키워드를 활용하면 객체가 지니고 있는
				 * 다른 멤버에 접근하는 것이 가능하다. (즉, this 키워드가 있기 때문에 멤버 메서드 내부에서 멤버 
				 * 변수에 자유롭게 접근하는 것이 가능하다.)
				 */
				this.m_nLV = a_nLV;
				this.m_nHP = a_nHP;
				this.m_nATK = a_nATK;
			}

			/** 정보를 출력한다 */
			public void ShowInfo()
			{
				Console.WriteLine("LV : {0}", m_nLV);
				Console.WriteLine("HP : {0}", m_nHP);
				Console.WriteLine("ATK : {0}", m_nATK);
			}
		}
#elif E11_CLASS_03
		/*
		 * 접근 제어 지시자 (한정자) 란?
		 * - 클래스 멤버의 보호 수준을 의미한다. (즉, 보호 수준에 따라 클래스의 각 멤버에 접근 할 수 있는 범위가
		 * 제한된다는 것을 알 수 있다.)
		 * 
		 * C# 은 클래스를 통해 사물의 여러 특징을 표현하기 때문에 이러한 특징 중 외부에서 함부로 접근하면 안되는
		 * 민감한 속성은 외부로부터 안전하게 보호 할 필요가 있다. (즉, 중요도가 상대적으로 떨어지는 속성은 낮은
		 * 보호 수준으로 설정하고 중요도가 높은 속성은 높은 보호 수준으로 지정하는 것이 가능하다.)
		 * 
		 * C# 주요 보호 수준 종류
		 * - public			<- 모든 곳에서 접근 허용
		 * - protected		<- 클래스 내부 또는 자식 클래스에서만 접근 허용
		 * - private		<- 클래스 내부에서만 접근 허용
		 * 
		 * 보호 수준을 지정하는 것은 사용자 (프로그래머) 에 따라 다르지만 일반적으로 멤버 변수는 private 수준으로
		 * 지정하고 멤버 함수는 public 수준으로 지정하는 것이 일반적인 관례이다. (즉, 멤버 변수는 데이터를 지니고 
		 * 있기 때문에 외부로부터 안전하게 보호하는 것이 일반적이다.)
		 */
		/** 플레이어 */
		private class CPlayer
		{
			private int m_nLV = 0;
			private int m_nHP = 0;
			private int m_nATK = 0;

			/** 생성자 */
			public CPlayer() : this(0, 0, 0)
			{
				// Do Something
			}

			/** 생성자 */
			public CPlayer(int a_nLV, int a_nHP, int a_nATK)
			{
				m_nLV = a_nLV;
				m_nHP = a_nHP;
				m_nATK = a_nATK;
			}

			/*
			 * 접근자 메서드란?
			 * - 일반적으로 클래스가 지니고 있는 멤버 변수는 private 수준으로 보호되기 때문에 외부에서 해당 변수에
			 * 직접적으로 접근하는 것은 불가능하다.
			 * 
			 * 따라서, 외부에서 특정 변수에 데이터를 변경하거나 가져오기 위한 방법이 필요하며 이러한 역할을 하는
			 * 메서드를 접근자 메서드라고 한다. (즉, 접근자 메서드를 활용하면 클래스 외부에서도 멤버 변수가 지니고
			 * 있는 데이터를 간접적으로 제어하는 것이 가능하다.)
			 * 
			 * 단, 접근자 메서드의 제공은 필수가 아닌 선택 사항이기 때문에 접근자 메서드를 지원하지 않는 private
			 * 멤버 변수는 외부에서 접근 할 방법이 없다는 것을 알 수 있다.
			 */
			/** 레벨을 변경한다 */
			public void SetLV(int a_nLV)
			{
				//if(a_nLV > 50)
				//{
				//	Console.WriteLine("너 누구냐?");
				//	return;
				//}

				m_nLV = a_nLV;
			}

			/** 체력을 변경한다 */
			public void SetHP(int a_nHP)
			{
				m_nHP = a_nHP;
			}

			/** 공격력을 변경한다 */
			public void SetATK(int a_nATK)
			{
				m_nATK = a_nATK;
			}

			/** 정보를 출력한다 */
			public void ShowInfo()
			{
				Console.WriteLine("LV : {0}", m_nLV);
				Console.WriteLine("HP : {0}", m_nHP);
				Console.WriteLine("ATK : {0}", m_nATK);
			}
		}
#endif // #if E11_CLASS_01
	}
}
