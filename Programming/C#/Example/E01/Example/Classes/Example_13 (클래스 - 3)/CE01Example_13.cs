#define E13_CLASS_01
#define E13_CLASS_02
#define E13_CLASS_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01.Example.Classes.Example_13
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

#elif E13_CLASS_02

#elif E13_CLASS_03

#endif // #if E13_CLASS_01
		}

#if E13_CLASS_01
		/** 부모 클래스 */
		private class CBase
		{
			public int ValInt { get; private set; } = 0;

			/** 생성자 */
			public CBase(int a_nVal)
			{
				this.ValInt = a_nVal;
			}
		}

		/** 자식 클래스 */
		private class CDerived : CBase
		{
			public float ValFlt { get; private set; } = 0.0f;

			/*
			 * 클래스가 상속 관계에 있을 때 클래스가 지닌 생성자의 호출 순서는 반드시 부모 ~ 자식 순으로 
			 * 이루어져야한다.
			 * 
			 * 단, 생성한 객체의 
			 */
			/** 생성자 */
			public CDerived(int a_nValInt, float a_fValFlt) : base(a_nValInt)
			{
				this.ValFlt = a_fValFlt;
			}
		}
#elif E13_CLASS_02

#elif E13_CLASS_03

#endif // #if E13_CLASS_01
	}
}
