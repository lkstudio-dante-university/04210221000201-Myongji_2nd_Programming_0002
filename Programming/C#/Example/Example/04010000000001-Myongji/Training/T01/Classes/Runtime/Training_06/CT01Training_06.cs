using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04010000000001_Myongji.Training.T01.Classes.Runtime.Training_06
{
	/**
	 * Training 6
	 */
	internal class CT01Training_06
	{
		/** 결과 */
		private enum EResult
		{
			NONE = -1,
			PLAYER_WIN,
			MONSTER_WIN,
			MAX_VAL
		}

		/** 캐릭터 타입 */
		private enum ETypeCharacter
		{
			NONE = -1,
			PLAYER = 1,
			MONSTER,
			MAX_VAL
		}

		/** 초기화 */
		public static void Start(string[] args)
		{
			string oPathDir = "../../../04010000000001-Myongji/Training/T01/Resources/Training_06";
			CT01Table_06.Inst.LoadDatas(oPathDir + "/T01Training_06_01.csv");

			var oPlayer = new CT01Character_06((int)ETypeCharacter.PLAYER);
			var oMonster = new CT01Character_06((int)ETypeCharacter.MONSTER);

			while(true)
			{
				Console.Clear();
				oPlayer.Attack(oMonster);

				Console.WriteLine("=====> 플레이어 공격 후 <=====");
				oPlayer.ShowInfo();

				Console.WriteLine();
				oMonster.ShowInfo();

				var eResult = GetResult(oPlayer, oMonster);

				// 승패가 결정났을 경우
				if(eResult != EResult.NONE)
				{
					ShowResult(eResult);
					break;
				}

				oMonster.Attack(oPlayer);

				Console.WriteLine("\n=====> 몬스터 공격 후 <=====");
				oPlayer.ShowInfo();

				Console.WriteLine();
				oMonster.ShowInfo();

				eResult = GetResult(oPlayer, oMonster);

				// 승패가 결정났을 경우
				if(eResult != EResult.NONE)
				{
					ShowResult(eResult);
					break;
				}

				Thread.Sleep(1000);
			}
		}

		/** 결과를 반환한다 */
		private static EResult GetResult(CT01Character_06 a_oPlayer,
			CT01Character_06 a_oMonster)
		{
			// 몬스터 체력이 없을 경우
			if(a_oMonster.Data.m_nHP <= 0)
			{
				return EResult.PLAYER_WIN;
			}

			return (a_oPlayer.Data.m_nHP <= 0) ?
				EResult.MONSTER_WIN : EResult.NONE;
		}

		/** 결과를 출력한다 */
		private static void ShowResult(EResult a_eResult)
		{
			Console.WriteLine();

			switch(a_eResult)
			{
				case EResult.PLAYER_WIN:
					Console.WriteLine("플레이어가 이겼습니다.");
					break;

				case EResult.MONSTER_WIN:
					Console.WriteLine("몬스터가 이겼습니다.");
					break;
			}
		}
	}
}
