using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._04210203000201_Myongji_2nd_Programming_0002.E01.Training.Classes.Runtime.Training_03
{
	/**
	 * Training 3
	 */
	internal class CT01Training_03
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			var oUnitA = new CUnit();
			oUnitA.HP = 100;
			oUnitA.ATK = 10;

			var oUnitB = new CUnit();
			oUnitB.HP = 100;
			oUnitB.ATK = 5;

			oUnitA.Attack(oUnitB);

			Console.WriteLine("=====> 유닛 A 공격 후 <=====");
			Console.WriteLine("유닛 A : {0}", oUnitA.HP);
			Console.WriteLine("유닛 B : {0}", oUnitB.HP);

			oUnitB.Attack(oUnitA);

			Console.WriteLine("\n=====> 유닛 B 공격 후 <=====");
			Console.WriteLine("유닛 A : {0}", oUnitA.HP);
			Console.WriteLine("유닛 B : {0}", oUnitB.HP);
		}

		/** 유닛 */
		private class CUnit
		{
			public int HP { get; set; } = 0;
			public int ATK { get; set; } = 0;

			/** 타겟을 공격한다 */
			public void Attack(CUnit a_oTarget)
			{
				a_oTarget.HP = Math.Max(0, a_oTarget.HP - ATK);
			}
		}
	}
}
