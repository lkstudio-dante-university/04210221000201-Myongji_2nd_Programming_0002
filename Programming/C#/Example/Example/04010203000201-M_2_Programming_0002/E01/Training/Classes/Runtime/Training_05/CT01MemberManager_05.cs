using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._04010203000201_M_2_Programming_0002.E01.Training.Classes.Runtime.Training_05
{
	/**
	 * 회원
	 */
	public struct STT01Member_05
	{
		public string m_oName;
		public string m_oPhoneNumber;

		/** 생성자 */
		public STT01Member_05(string a_oName, string a_oPhoneNumber)
		{
			m_oName = a_oName;
			m_oPhoneNumber = a_oPhoneNumber;
		}
	}

	/**
	 * 회원 관리자
	 */
	internal class CT01MemberManager_05
	{
		private List<STT01Member_05> m_oListMembers = new List<STT01Member_05>();

		/** 회원을 추가한다 */
		public void AddMember(STT01Member_05 a_stMember)
		{
			int nResult = this.FindMember(a_stMember.m_oName);

			// 회원이 존재 할 경우
			if(nResult >= 0)
			{
				return;
			}

			m_oListMembers.Add(a_stMember);
			Console.WriteLine("{0} 회원을 추가했습니다.", a_stMember.m_oName);
		}

		/** 회원을 제거한다 */
		public void RemoveMember(string a_oName)
		{
			int nResult = this.FindMember(a_oName);

			// 회원이 없을 경우
			if(nResult < 0)
			{
				return;
			}

			m_oListMembers.RemoveAt(nResult);
			Console.WriteLine("{0} 회원을 제거했습니다.", a_oName);
		}

		/** 회원을 검색한다 */
		public void SearchMember(string a_oName)
		{
			int nResult = this.FindMember(a_oName);

			// 회원이 없을 경우
			if(nResult < 0)
			{
				return;
			}

			Console.WriteLine("=====> 회원 정보 <=====");
			Console.WriteLine("이름 : {0}", m_oListMembers[nResult].m_oName);
			Console.WriteLine("이름 : {0}", m_oListMembers[nResult].m_oPhoneNumber);
		}

		/** 모든 회원을 출력한다 */
		public void PrintAllMembers()
		{
			Console.WriteLine("=====> 모든 회원 정보 <=====");

			for(int i = 0; i < m_oListMembers.Count; ++i)
			{
				Console.WriteLine("이름 : {0}", m_oListMembers[i].m_oName);
				Console.WriteLine("전화번호 : {0}\n", m_oListMembers[i].m_oPhoneNumber);
			}
		}

		/** 회원을 탐색한다 */
		private int FindMember(string a_oName)
		{
			for(int i = 0; i < m_oListMembers.Count; ++i)
			{
				// 이름이 동일 할 경우
				if(a_oName == m_oListMembers[i].m_oName)
				{
					return i;
				}
			}

			return -1;
		}
	}
}
