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
 * 또한, 확장 메서드를 구현하기 위한 정적 클래스는 전역 영역에 정의되어야한다. (즉, 특정 영역에 속한 정적 클래스에는
 * 확장 메서드를 구현하는 것이 불가능하다.)
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
 * 
 * 연산자 오버로딩이란?
 * - 객체를 대상으로 연산자를 사용 할 수 있게 해주는 기능을 의미한다. (즉, 연산자 오버로딩을 활용하면 객체를 변수처럼 
 * 제어하는 것이 가능하다.)
 * 
 * 클래스를 대상으로 연산자를 사용하기 위해서는 해당 연산자에 대한 기능을 정의 할 필요가 있으며 이는 operator 이름으로
 * 시작되는 특별한 메서드를 통해 정의하는 것이 가능하다. (즉, 객체를 대상으로 연산자를 사용 할 경우 해당 연산자의
 * 역할을 수행 할 operator 계열 메서드가 호출된다는 것을 알 수 있다.)
 * 
 * Ex)
 * class CSomeClass
 * {
 *		int m_nVal;
 *		
 *		static int operator +(CSomeClass a_oSomeObjA, CSomeClass a_oSomeObjB)
 *		{
 *			return a_oSomeObjA.m_nVal + a_oSomeObjB.m_nVal;
 *		}
 * }
 * 
 * var oSomeObjA = new CSomeClass();
 * var oSomeObjB = new CSomeClass();
 * 
 * int nResult = oSomeObjA + oSomeObjB;
 * 
 * 위와 같이 객체를 대상으로 연산자를 사용 할 경우 C# 컴파일러는 operator 계열 메서드를 호출해준다는 것을 알 수
 * 있다.
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
	public static void ExPrintValues(this List<int> a_oSender)
	{
		for(int i = 0; i < a_oSender.Count; ++i)
		{
			Console.Write("{0}, ", a_oSender[i]);
		}
	}
}
#endif // #if E14_CLASS_02

namespace Example._04010203000201_M_2_Programming_0002.E01.Example.Classes.Runtime.Example_14
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

			Console.WriteLine("=====> 자식 클래스 <=====");
			oDerived.ShowInfo();
#elif E14_CLASS_02
			var oRandom = new Random();
			var oListValues = new List<int>();

			for(int i = 0; i < 10; ++i)
			{
				oListValues.Add(oRandom.Next(1, 100));
			}

			/*
			 * 확장 메서드를 구현하면 클래스의 멤버처럼 사용하는 것이 가능하기 때문에 아래와 같이 객체에 접근해서 
			 * 호출하는 것이 가능하다.
			 */
			Console.WriteLine("=====> 리스트 <=====");
			oListValues.ExPrintValues();

			Console.WriteLine("\n\n합계 : {0}", oListValues.ExGetValSum());
#elif E14_CLASS_03
			var oVec3A = new CVec3(10.0f, 0.0f, 0.0f);
			var oVec3B = new CVec3(0.0f, 10.0f, 0.0f);

			float fVal = 10.0f;

			Console.WriteLine("=====> 연산자 오버로딩 <=====");
			Console.WriteLine("{0} + {1} = {2}", oVec3A, oVec3B, oVec3A + oVec3B);
			Console.WriteLine("{0} - {1} = {2}", oVec3A, oVec3B, oVec3A - oVec3B);
			Console.WriteLine("{0} * {1} = {2}", oVec3A, fVal, oVec3A * fVal);
			Console.WriteLine("{0} / {1} = {2}", oVec3B, fVal, oVec3B / fVal);
			Console.WriteLine("{0} Dot {1} = {2}", oVec3A, oVec3B, oVec3A.GetDot(oVec3B));
			Console.WriteLine("{0} Cross {1} = {2}", oVec3A, oVec3B, oVec3A.GetCross(oVec3B));
#endif // #if E14_CLASS_01
		}

#if E14_CLASS_01
		/*
		 * abstract 키워드란?
		 * - 클래스 또는 메서드를 추상으로 만드는 역할을 수행하는 키워드를 의미한다. (즉, 클래스에 abstract 키워드를
		 * 명시하면 해당 클래스는 추상 클래스가 된다는 것을 알 수 있다.)
		 * 
		 * 추상 클래스는 일반적인 클래스와 달리 객체화시키는 것이 불가능하다. (즉, 추상 클래스는 자식 클래스를 통해
		 * 간접적으로만 객체화시킬 수 있다는 것을 알 수 있다.)
		 */
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
			public abstract void ShowInfo();
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
				Console.WriteLine("Int : {0}", this.ValInt);
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

			public float Length => MathF.Sqrt(MathF.Pow(this.X, 2.0f) + MathF.Pow(this.Y, 2.0f) + MathF.Pow(this.Z, 2.0f));

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

			/** 내적 결과를 반환한다 */
			public float GetDot(CVec3 a_oVec3)
			{
				float fX = (this.X * a_oVec3.X);
				float fY = (this.Y * a_oVec3.Y);
				float fZ = (this.Z * a_oVec3.Z);

				return fX + fY + fZ;
			}

			/** 외적 결과를 반환한다 */
			public CVec3 GetCross(CVec3 a_oVec3)
			{
				float fX = (this.Y * a_oVec3.Z) - (this.Z * a_oVec3.Y);
				float fY = (this.Z * a_oVec3.X) - (this.X * a_oVec3.Z);
				float fZ = (this.X * a_oVec3.Y) - (this.Y * a_oVec3.X);

				return new CVec3(fX, fY, fZ);
			}

			/** 정규 벡터를 반환한다 */
			public CVec3 GetNormalize()
			{
				float fLength = this.Length;
				return new CVec3(this.X / fLength, this.Y / fLength, this.Z / fLength);
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
