//#define E12_CLASS_01
//#define E12_CLASS_02
#define E12_CLASS_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Example._04010203000201_Myongji_2nd_Programming_0002.E01.Example.Classes.Runtime.Example_12
{
	/**
	 * Example 12
	 */
	internal class CE01Example_12
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E12_CLASS_01
			var oPlayerA = new CPlayer();
			oPlayerA.LV = 10;
			oPlayerA.HP = 30;
			oPlayerA.ATK = 15;
			oPlayerA.Name = "Player A";

			var oPlayerB = new CPlayer(50, 150, 75, "Player B");

			Console.WriteLine("=====> 플레이어 A <=====");
			oPlayerA.ShowInfo();

			Console.WriteLine("\n=====> 플레이어 B <=====");
			oPlayerB.ShowInfo();
#elif E12_CLASS_02
			var oValues = new CArray(10);

			for(int i = 0; i < oValues.NumValues; ++i)
			{
				oValues[i] = i + 1;
			}

			Console.WriteLine("=====> 배열 <=====");

			for(int i = 0; i < oValues.NumValues; ++i)
			{
				Console.Write("{0}, ", oValues[i]);
			}

			Console.WriteLine();
#elif E12_CLASS_03
			//CData.ValFloat = 10.0f;
			//CData.ShowClassInfo();

			//var oDataA = new CData();
			//oDataA.ValInt = 10;

			//var oDataB = new CData();
			//oDataB.ValInt = 20;

			///*
			// * 클래스 멤버는 클래스에 종속되기 때문에 객체를 통하지 않고 접근하는 것이 가능하다. (즉, 클래스 멤버는
			// * 해당 클래스를 통해서 생성 된 모든 객체가 공유하는 멤버라는 것을 알 수 있다.)
			// */
			//CData.ValFlt = 3.14f;

			//Console.WriteLine("=====> 데이터 A <=====");
			//oDataA.ShowInfo();

			//Console.WriteLine("\n=====> 데이터 B <=====");
			//oDataB.ShowInfo();

			//Console.WriteLine("\n=====> 클래스 메서드 <=====");
			//CData.ShowInfoClass();
#endif // #if E12_CLASS_01
		}

#if E12_CLASS_01
		/** 플레이어 */
		private class CPlayer
		{
			private int m_nLV = 0;
			private int m_nHP = 0;
			private int m_nATK = 0;

			/*
			 * 프로퍼티란?
			 * - 접근자 메서드를 좀더 편리하게 구현 및 사용 할 수 있는 기능을 의미한다. (즉, 전통적인 접근자 메서드는
			 * 메서드를 통해 구현되기 때문에 개수가 많아질수록 명령문을 작성하는데 시간이 많이 걸린다는 단점이 
			 * 존재한다.)
			 * 
			 * 프로퍼티는 크게 get 영역과 set 영역으로 이루어져있으며 get 영역에는 멤버 변수의 데이터를 반환하는
			 * 명령문을 작성하고 set 영역에는 멤버 변수의 데이터를 변경하는 명령문이 작성된다.
			 * 
			 * 또한, 프로퍼티를 활용해서 접근자 메서드를 구현하면 변수에 접근하듯이 명령문을 작성하는 것이 가능하다.
			 * 
			 * Ex)
			 * class CClassSome
			 * {
			 *		private int m_nVal = 0;
			 *		
			 *		public int Val
			 *		{
			 *			get
			 *			{
			 *				return m_nVal;
			 *			}
			 *			set
			 *			{
			 *				m_nVal = value;
			 *			}
			 *		}
			 * }
			 * 
			 * var oObjSome = new CClassSome();
			 * oObjSome.Val = 10;
			 * 
			 * Console.WriteLine("{0}", oObjSome.Val);
			 * 
			 * 위와 같이 프로퍼티는 변수에 접근하듯이 사용하는 것이 가능하다. (즉, 프로퍼티에 데이터를 할당하면
			 * set 영역에 있는 명령문이 동작하며 프로퍼티의 데이터를 가져오면 get 영역에 있는 명령문이 동작한다는
			 * 것을 알 수 있다.
			 */
			public int LV
			{
				get
				{
					return m_nLV;
				}
				set
				{
					/*
					 * 프로퍼티에 입력으로 들어온 데이터는 value 키워드를 통해서 가져오는 것이 가능하다. (즉, value
					 * 키워드는 외부에서 전달한 데이터를 저장하고 있는 매개 변수와 같은 개념이다.)
					 */
					m_nLV = value;
				}
			}

			public int HP
			{
				get
				{
					return m_nHP;
				}
				set
				{
					m_nHP = value;
				}
			}

			public int ATK
			{
				get
				{
					return m_nATK;
				}
				set
				{
					m_nATK = value;
				}
			}

			/*
			 * 자동 구현 프로퍼티란?
			 * - 멤버 변수와 프로퍼티를 동시에 선언 및 구현 할 수 있는 기능을 의미한다. (즉, 프로퍼티는 단순히
			 * Getter 와 Setter 를 구현해주는 기능이기 때문에 데이터를 저장 및 읽어들이기 위한 별도의 변수가
			 * 필요하다는 것을 알 수 있다.)
			 * 
			 * 단, 자동 구현 프로퍼티는 가장 단순한 형태의 Getter 와 Setter 만을 구현해주기 때문에 복잡한 명령문이
			 * 필요한 Getter 와 Setter 는 자동 구현 프로퍼티로 구현하는 것이 불가능하다.
			 */
			public string Name { get; set; } = string.Empty;

			/** 생성자 */
			public CPlayer() : this(0, 0, 0, string.Empty)
			{
				// Do Something
			}

			/** 생성자 */
			public CPlayer(int a_nLV, int a_nHP, int a_nATK, string a_oName)
			{
				m_nLV = a_nLV;
				m_nHP = a_nHP;
				m_nATK = a_nATK;
				this.Name = a_oName;
			}

			/** 정보를 출력한다 */
			public void ShowInfo()
			{
				Console.WriteLine("LV : {0}", this.LV);
				Console.WriteLine("HP : {0}", this.HP);
				Console.WriteLine("ATK : {0}", this.ATK);
				Console.WriteLine("Name : {0}", this.Name);
			}
		}
#elif E12_CLASS_02
		/** 배열 */
		private class CArray
		{
			private int[] m_oValues = null;
			public int NumValues => m_oValues.Length;

			/** 생성자 */
			public CArray(int a_nSize)
			{
				m_oValues = new int[a_nSize];
			}

			/*
			 * 인덱서란?
			 * - 객체를 대상으로 [] (인덱스 연산자) 를 사용 할 수 있게 해주는 기능을 의미한다. (즉, 일반적으로
			 * 객체에는 인덱스 연산자를 사용하는 것이 불가능하다는 것을 알 수 있다.)
			 */
			/** 인덱서 */
			public int this[int a_nIdx]
			{
				get
				{
					/*
					 * Debug.Assert 메서드는 입력으로 주어진 조건식이 거짓 일 경우 프로그램을 중단시키는 역할을
					 * 수행한다. (즉, 해당 메서드를 활용하면 프로그램을 개발하는 과정에서 의도치않게 전달되는
					 * 데이터를 검사하는 것이 가능하다.)
					 * 
					 * 또한, 해당 메서드는 디버그 환경에서만 정상적으로 동작하기 때문에 개발 중에 자주 활용되는
					 * 메서드이다. (즉, 프로그램이 실제 사용자에게 배포되는 릴리즈 환경에서는 해당 메서드가 호출되지
					 * 않고 무시된다는 것을 알 수 있다.)
					 */
					Debug.Assert(this.IsValidIdx(a_nIdx));
					return m_oValues[a_nIdx];
				}
				set
				{
					Debug.Assert(this.IsValidIdx(a_nIdx));
					m_oValues[a_nIdx] = value;
				}
			}

			/** 인덱스 유효 여부를 검사한다 */
			private bool IsValidIdx(int a_nIdx)
			{
				return a_nIdx >= 0 && a_nIdx < m_oValues.Length;
			}
		}
#elif E12_CLASS_03
		/*
		 * 클래스 (정적) 멤버란?
		 * - 객체에 종속되는 일반적인 멤버와 달리 클래스 자체에 종속되는 멤버를 의미한다. (즉, 일반적인 멤버는
		 * 객체마다 개별적으로 존재하지만 클래스 멤버는 클래스에게 종속되기 때문에 각 클래스 별로 1 개만 존재한다는
		 * 것을 알 수 있다.)
		 */
		/** 데이터 */
		private class CData
		{
			public int ValInt { get; set; } = 0;
			public static float ValFlt { get; set; } = 0.0f;

			/** 정보를 출력한다 */
			public void ShowInfo()
			{
				Console.WriteLine("{0}, {1}", this.ValInt, CData.ValFlt);
			}

			/** 정보를 출력한다 */
			public static void ShowInfoClass()
			{
				Console.WriteLine("{0}", CData.ValFlt);

				/*
				 * 클래스 메서드 내부에서는 클래스 변수에만 접근하는 것이 가능하다. (즉, 멤버 변수는 객체에 종속되기
				 * 때문에 객체를 생성하지 않고도 호출 가능하면 클래스 메서드 내부에서는 접근이 불가능하다는 것을
				 * 알 수 있다.)
				 */
				//Console.WriteLine("{0}", CData.ValInt);
			}
		}
#endif // #if E12_CLASS_01
	}
}
