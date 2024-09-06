using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._04010203000201_M_2_Programming_0002.E01.Training.Classes.Runtime.Training_06
{
	/**
	 * 캐릭터
	 */
	internal class CT01Character_06
	{
		public int ID { get; private set; } = 0;
		public STT01Data_06 Data { get; private set; }

		/** 생성자 */
		public CT01Character_06(int a_nID)
		{
			this.ID = a_nID;
			this.Data = CT01Table_06.Inst.GetData(a_nID);
		}

		/** 공격한다 */
		public void Attack(CT01Character_06 a_oTarget)
		{
			var stData = a_oTarget.Data;
			int nDamage = Math.Max(0, this.Data.m_nATK - stData.m_nDEF);

			stData.m_nHP = Math.Max(0, stData.m_nHP - nDamage);
			a_oTarget.Data = stData;
		}

		/** 정보를 출력한다 */
		public void ShowInfo()
		{
			Console.WriteLine("Name : {0}", this.Data.m_oName);
			Console.WriteLine("HP : {0}", this.Data.m_nHP);
			Console.WriteLine("ATK : {0}", this.Data.m_nATK);
			Console.WriteLine("DEF : {0}", this.Data.m_nDEF);
		}
	}
}
