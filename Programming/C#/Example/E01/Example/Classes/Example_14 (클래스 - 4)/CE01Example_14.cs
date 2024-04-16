//#define E14_CLASS_01
//#define E14_CLASS_02
#define E14_CLASS_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 추상 클래스란?
 * - 직접 객체화 시킬 수 없는 클래스를 의미하며 abstract 키워드를 통해서 특정 클래스를 추상 클래스로 정의하는 것이 
 * 가능하다.
 * 
 * 추상 클래스는 직접 객체화 시키는 것은 불가능하지만 자식 클래스를 통해 간접적으로 객체화 시키는 것은 가능하다. 
 * (즉, 추상 클래스는 주로 상속을 목적으로 사용되는 클래스라는 것을 알 수 있다.)
 * 
 * 정적 클래스란?
 * - 정적 (클래스) 멤버로만 이루어진 클래스를 의미한다. (즉, 정적 클래스는 일반적인 멤버를 선언하는 것이 불가능하다.)
 * 
 * 정적 클래스는 특정 클래스를 상속하는 것도 불가능하고 객체화 시키는 것도 불가능하다는 제한이 존재한다. 단, 정적 
 * 클래스를 활용하면 확장 메서드를 구현하는 것이 가능하다.
 * 
 * 확장 메서드란?
 * - 특정 클래스가 가진 기능을 메서드를 통해서 확장하는 기능을 의미한다. (즉, 확장 메서드를 활용하면 상속을 사용하지
 * 않고도 클래스에 새로운 메서드를 추가하는 것이 가능하다.)
 * 
 * 확장 메서드를 구현하면 해당 메서드는 클래스의 멤버처럼 사용하는 것이 가능하기 때문에 라이브러리 형태로 지원되는
 * 클래스에도 새로운 기능을 구현하는 것이 가능하다.
 * 
 * 단, 확장 메서드는 클래스 외부에 존재하기 때문에 public 보호 수준 이외에는 접근하는 것이 불가능하다는 단점이
 * 존재한다.
 * 
 * Ex)
 * static class CExtension
 * {
 *		static void SomeExtensionMethod(this CSomeClass a_oSender)
 *		{
 *				// Do Something
 *		}
 * }
 * 
 * 위와 같이 정적 클래스와 this 키워드를 활용하면 확장 메서드를 구현하는 것이 가능하다.
 */
#if E14_CLASS_02
/** 확장 클래스 */
public static class CExtension
{
	/** 합계를 반환한다 */
	public static int ExGetValSum(this List<int> a_oSender)
	{
		int nValSum = 0;

		for(int i = 0; i < a_oSender.Count; ++i)
		{
			nValSum += a_oSender[i];
		}

		return nValSum;
	}

	/** 값을 출력한다 */
	public static void ExPrintVals(this List<int> a_oSender)
	{
		for(int i = 0; i < a_oSender.Count; ++i)
		{
			Console.Write("{0}, ", a_oSender[i]);
		}
	}
}
#endif // #if E14_CLASS_02

namespace E01.Example.Classes.Example_14
{
	/**
	 * Example 14
	 */
	internal class CE01Example_14
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E14_CLASS_01
			/*
			 * Base 클래스는 추상 클래스이기 때문에 new 키워드를 통해서 객체화 시키는 것이 불가능하다는 것을 알 수
			 * 있다. (즉, 컴파일 에러가 발생한다.)
			 */
			//CBase oBase = new CBase(10);

			CBase oDerived = new CDerived(10, 3.14f);

			Console.WriteLine("\n=====> 자식 클래스 <=====");
			oDerived.ShowInfo();
#elif E14_CLASS_02
			var oRandom = new Random();
			var oListVals = new List<int>();

			for(int i = 0; i < 10; ++i)
			{
				oListVals.Add(oRandom.Next(1, 100));
			}

			/*
			 * 확장 메서드를 구현하면 클래스의 멤버처럼 사용하는 것이 가능하기 때문에 아래와 같이 객체에 접근해서 
			 * 호출하는 것이 가능하다.
			 */
			Console.WriteLine("=====> 리스트 <=====");
			oListVals.ExPrintVals();

			Console.WriteLine("\n\n합계 : {0}", oListVals.ExGetValSum());
#elif E14_CLASS_03
			var oVec3A = new CVec3(10.0f, 0.0f, 0.0f);
			var oVec3B = new CVec3(0.0f, 10.0f, 0.0f);

			float fVal = 10.0f;

			Console.WriteLine("=====> 연산자 오버로딩 <=====");
			Console.WriteLine("{0} + {1} = {2}", oVec3A, oVec3B, oVec3A + oVec3B);
			Console.WriteLine("{0} - {1} = {2}", oVec3A, oVec3B, oVec3A - oVec3B);
			Console.WriteLine("{0} * {1} = {2}", oVec3A, fVal, oVec3A * fVal);
			Console.WriteLine("{0} / {1} = {2}", oVec3B, fVal, oVec3B / fVal);
#endif // #if E14_CLASS_01
		}

#if E14_CLASS_01
		/** 부모 클래스 */
		private abstract class CBase
		{
			public int ValInt { get; private set; } = 0;

			/** 생성자 */
			public CBase(int a_nValInt)
			{
				this.ValInt = a_nValInt;
			}

			/*
			 * 추상 (순수 가상) 메서드란?
			 * - 가상 메서드와 같이 실제 호출 될 메서드를 동적으로 결정하는 기능을 의미하지만 가상 메서드와 달리 
			 * 추상 메서드는 구현부를 지니는 것이 불가능하다. (즉, 추상 메서드는 반드시 자식 클래스에서 재정의해야지만
			 * 사용하는 것이 가능하다.)
			 * 
			 * 또한, 특정 클래스가 추상 메서드를 하나로도 지니고 있을 경우 해당 클래스는 new 키워드를 사용해서 객체화 
			 * 시키는 것이 불가능한 추상 클래스가 된다.
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

			/** 정보를 출력한다 */
			public override void ShowInfo()
			{
				base.ShowInfo();
				Console.WriteLine("Float : {0}", this.ValFlt);
			}
		}
#elif E14_CLASS_03
		/** 3 차원 벡터 */
		private class CVec3
		{
			public float X { get; set; } = 0.0f;
			public float Y { get; set; } = 0.0f;
			public float Z { get; set; } = 0.0f;

			/** 생성자 */
			public CVec3() : this(0.0f, 0.0f, 0.0f)
			{
				// Do Something
			}

			/** 생성자 */
			public CVec3(float a_fX, float a_fY, float a_fZ)
			{
				this.X = a_fX;
				this.Y = a_fY;
				this.Z = a_fZ;
			}

			/** 문자열로 변환한다 */
			public override string ToString()
			{
				return string.Format("({0}, {1}, {2})", this.X, this.Y, this.Z);
			}

			/** 덧셈 결과를 반환한다 */
			public static CVec3 operator +(CVec3 a_oVec3A, CVec3 a_oVec3B)
			{
				return new CVec3(a_oVec3A.X + a_oVec3B.X, a_oVec3A.Y + a_oVec3B.Y, a_oVec3A.Z + a_oVec3B.Z);
			}

			/** 뺄셈 결과를 반환한다 */
			public static CVec3 operator -(CVec3 a_oVec3A, CVec3 a_oVec3B)
			{
				return new CVec3(a_oVec3A.X - a_oVec3B.X, a_oVec3A.Y - a_oVec3B.Y, a_oVec3A.Z - a_oVec3B.Z);
			}

			/** 스칼라 곱셈 결과를 반환한다 */
			public static CVec3 operator *(CVec3 a_oVec3, float a_fVal)
			{
				return new CVec3(a_oVec3.X * a_fVal, a_oVec3.Y * a_fVal, a_oVec3.Z * a_fVal);
			}

			/** 스칼라 나눗셈 결과를 반환한다 */
			public static CVec3 operator /(CVec3 a_oVec3, float a_fVal)
			{
				return new CVec3(a_oVec3.X / a_fVal, a_oVec3.Y / a_fVal, a_oVec3.Z / a_fVal);
			}
		}
#endif // #if E14_CLASS_01
	}
}
