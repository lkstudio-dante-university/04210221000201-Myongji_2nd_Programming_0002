#define E11_CLASS_01
#define E11_CLASS_02
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
 * class CPlayer
 * {
 *		public int m_nLV;
 *		public int m_nHP;
 *		public int m_nATK;
 *		
 *		public void ShowInfo()
 *		{
 *			// Do Something
 *		}
 * }
 * 
 * var oPlayer = new CPlayer();
 * 
 * 위와 같이 선언 된 클래스는 자료형처럼 사용하는 것이 가능하기 때문에 new 키워드를 통해서 객체를 생성하는 것이
 * 가능하다. (즉, 클래스는 객체를 생성하기 위한 틀처럼 활용된다는 것을 알 수 있다.)
 */
namespace E01.Example.Classes.Example_11
{
	/**
	 * Example 11
	 */
	internal class CE01Example_11
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E11_CLASS_01
			/*
			 * 클래스를 통해서 생성 된 객체는 하위에 변수와 메서드 등을 지니고 있으며 이러한 멤버는
			 * . (멤버 접근 연산자) 를 통해서 접근하는 것이 가능하다. (즉, 일반적으로 클래스의 멤버는 객체마다
			 * 개별적으로 지니고 있다는 것을 알 수 있다.)
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

#elif E11_CLASS_03

#endif // #if E11_CLASS_01
		}

#if E11_CLASS_01
		/** 플레이어 */
		private class CPlayer
		{
			public int m_nLV = 0;
			public int m_nHP = 0;
			public int m_nATK = 0;

			/** 정보를 출력한다 */
			public void ShowInfo()
			{
				/*
				 * 클래스 내부에 구현 된 메서드는 일반적인 메서드와 달리 동일한 클래스에 존재하는 변수에 접근하는
				 * 것이 가능하다. (즉, 동일한 클래스에 존재하는 변수의 데이터는 메서드의 입력으로 전달 할 필요가
				 * 없다는 것을 알 수 있다.)
				 */
				Console.WriteLine("LV : {0}", m_nLV);
				Console.WriteLine("HP : {0}", m_nHP);
				Console.WriteLine("ATK : {0}", m_nATK);
			}
		}
#elif E11_CLASS_02

#elif E11_CLASS_03

#endif // #if E11_CLASS_01
	}
}
