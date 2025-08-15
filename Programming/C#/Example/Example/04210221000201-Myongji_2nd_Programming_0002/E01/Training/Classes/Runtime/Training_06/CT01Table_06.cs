using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._04210221000201_Myongji_2nd_Programming_0002.E01.Training.Classes.Runtime.Training_06
{
	/** 데이터 */
	public struct STT01Data_06
	{
		public int m_nID;
		public int m_nHP;
		public int m_nATK;
		public int m_nDEF;

		public string m_oName;

		/** 생성자 */
		public STT01Data_06(string[] a_oTokens)
		{
			int.TryParse(a_oTokens[0], out m_nID);
			int.TryParse(a_oTokens[2], out m_nHP);
			int.TryParse(a_oTokens[3], out m_nATK);
			int.TryParse(a_oTokens[4], out m_nDEF);

			m_oName = a_oTokens[1];
		}
	}

	/**
	 * 테이블
	 */
	internal class CT01Table_06
	{
		public List<STT01Data_06> ListDatas = new List<STT01Data_06>();
		private static CT01Table_06 m_oInst = null;

		public static CT01Table_06 Inst
		{
			get
			{
				// 인스턴스가 없을 경우
				if(m_oInst == null)
				{
					m_oInst = new CT01Table_06();
				}

				return m_oInst;
			}
		}

		/** 생성자 */
		private CT01Table_06()
		{
			// Do Something
		}

		/** 데이터를 반환한다 */
		public STT01Data_06 GetData(int a_nID)
		{
			for(int i = 0; i < this.ListDatas.Count; ++i)
			{
				// 데이터가 존재 할 경우
				if(a_nID == this.ListDatas[i].m_nID)
				{
					return this.ListDatas[i];
				}
			}

			return default;
		}

		/** 데이터를 로드한다 */
		public void LoadDatas(string a_oPathTable)
		{
			var oRStream = File.Open(a_oPathTable, FileMode.Open, FileAccess.Read);

			// 스트림 생성에 실패했을 경우
			if(oRStream == null)
			{
				return;
			}

			var oReader = new StreamReader(oRStream);

			try
			{
				int nLineNumber = 0;

				while(!oReader.EndOfStream)
				{
					string oLine = oReader.ReadLine();
					nLineNumber += 1;

					// 헤더 라인일 경우
					if(nLineNumber <= 1)
					{
						continue;
					}

					var oTokens = oLine.Split(",");

					// 데이터가 유효하지 않을 경우
					if(oTokens.Length < 5)
					{
						continue;
					}

					var stTableData = new STT01Data_06(oTokens);
					this.ListDatas.Add(stTableData);
				}
			}
			finally
			{
				oReader.Close();
			}
		}
	}
}
