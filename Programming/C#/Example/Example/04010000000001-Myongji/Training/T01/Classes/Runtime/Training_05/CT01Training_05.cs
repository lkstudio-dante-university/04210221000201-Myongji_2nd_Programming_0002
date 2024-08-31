using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04010000000001_Myongji.Training.T01.Classes.Runtime.Training_05
{
	/**
	 * Training 5
	 */
	internal class CT01Training_05
	{
		/** 메뉴 */
		private enum EMenu
		{
			NONE = -1,
			ADD_MEMBER,
			REMOVE_MEMBER,
			SEARCH_MEMBER,
			PRINT_ALL_MEMBERS,
			EXIT,
			MAX_VAL
		}

		/** 초기화 */
		public static void Start(string[] args)
		{
			var eMenu = EMenu.NONE;
			var oMemberManager = new CT01MemberManager_05();

			do
			{
				PrintMenu();
				int.TryParse(Console.ReadLine(), out int nMenu);

				eMenu = (EMenu)(nMenu - 1);

				switch(eMenu)
				{
					case EMenu.ADD_MEMBER:
						AddMember(oMemberManager);
						break;

					case EMenu.REMOVE_MEMBER:
						RemoveMember(oMemberManager);
						break;

					case EMenu.SEARCH_MEMBER:
						SearchMember(oMemberManager);
						break;

					case EMenu.PRINT_ALL_MEMBERS:
						PrintAllMembers(oMemberManager);
						break;
				}

				Console.WriteLine();
			} while(eMenu != EMenu.EXIT);
		}

		/** 메뉴를 출력한다 */
		private static void PrintMenu()
		{
			Console.WriteLine("=====> 메뉴 <=====");
			Console.WriteLine("1. 회원 추가");
			Console.WriteLine("2. 회원 제거");
			Console.WriteLine("3. 회원 검색");
			Console.WriteLine("4. 모든 회원 출력");
			Console.WriteLine("5. 종료");

			Console.Write("\n선택 : ");
		}

		/** 회원을 추가한다 */
		private static void AddMember(CT01MemberManager_05 a_oManager)
		{
			Console.Write("\n이름 : ");
			string oName = Console.ReadLine();

			Console.Write("전화번호 : ");
			string oPhoneNumber = Console.ReadLine();

			var stMember = new STT01Member_05(oName, oPhoneNumber);
			a_oManager.AddMember(stMember);
		}

		/** 회원을 제거한다 */
		private static void RemoveMember(CT01MemberManager_05 a_oManager)
		{
			Console.Write("\n이름 : ");
			string oName = Console.ReadLine();

			a_oManager.RemoveMember(oName);
		}

		/** 회원을 검색한다 */
		private static void SearchMember(CT01MemberManager_05 a_oManager)
		{
			Console.Write("\n이름 : ");
			string oName = Console.ReadLine();

			a_oManager.SearchMember(oName);
		}

		/** 모든 회원을 출력한다 */
		private static void PrintAllMembers(CT01MemberManager_05 a_oManager)
		{
			a_oManager.PrintAllMembers();
		}
	}
}
