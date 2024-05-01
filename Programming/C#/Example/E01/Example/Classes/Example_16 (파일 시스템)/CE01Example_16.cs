#define E16_FILE_SYSTEM_01
#define E16_FILE_SYSTEM_02
#define E16_FILE_SYSTEM_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 파일 시스템이란?
 * - 파일을 생성 및 제어 할 수 있는 기능을 의미한다. (즉, 파일 시스템을 활용하면 반영구적으로 데이터를 보관하는 것이
 * 가능하다.)
 * 
 * 프로그램이 실행 중에 선언되는 변수는 주 기억 장치에 위치하기 때문에 프로그램이 종료되면 변수에 저장 된 데이터도 모두 
 * 사라진다는 단점이 존재한다.
 * 
 * 따라서, 프로그램의 데이터를 반영구적으로 저장하기 위해서는 주 기억 장치가 아닌 보조 기억 장치에 데이터를 저장 할
 * 필요가 있으며 이때 주로 활용되는 것이 파일이다. (즉, 파일은 보조 기억 장치에 위치하기 떄문에 영구적으로 데이터가
 * 보관된다는 것을 알 수 있다.)
 * 
 * C# 에서 파일에 데이터를 저장하거나 읽어들이기 위해서는 스트림을 생성해야한다. (즉, 스트림을 통해서 파일에 데이터를
 * 기록하거나 읽어들이는 것이 가능하다.)
 * 
 * 스트림이란?
 * - 데이터를 출력하거나 읽어들일 수 있는 통로를 의미한다. (즉, 스트림을 활용하면 파일을 비롯한 특정 장치에 데이터를
 * 출력하거나 읽어들이는 것이 가능하다.)
 * 
 * 스트림은 일반적으로 단방향이기 때문에 입/출력이 모두 필요 할 경우 스트림을 2 개 생성 할 필요가 있다. (즉, 입력용
 * 스트림 1 개와 출력용 스트림 1 개가 필요하다는 것을 알 수 있다.)
 */
namespace E01.Example.Classes.Example_16
{
	/**
	 * Example 16
	 */
	internal class CE01Example_16
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E16_FILE_SYSTEM_01
			/*
			 * Directory 클래스는 디렉토리 (폴더) 를 제어하는 역할을 수행한다. (즉, Directory 클래스를 활용하면 
			 * 폴더를 생성하거나 폴더 안에 존재하는 파일의 목록을 가져오는 것이 가능하다.)
			 */
			// 디렉토리가 없을 경우
			if(!Directory.Exists("Example/Example_16"))
			{
				Directory.CreateDirectory("Example/Example_16");
			}

			/*
			 * File 클래스는 파일을 제어하는 역할을 수행한다. (즉, File 클래스를 활용하면 파일에 데이터를 저장하거나
			 * 읽어들이기 위한 스트림을 생성하는 것이 가능하다.)
			 * 
			 * File.Open 메서드는 스트림을 생성하는 역할을 수행한다. (즉, 해당 메서드에 입력되는 데이터에 따라
			 * 출력용 또는 입력용 스트림을 생성하는 것이 가능하다.)
			 */
			var oWStream = File.Open("Example/Example_16/E16_FileSystem_01.txt", 
				FileMode.Create, FileAccess.Write);

			// 스트림이 생성되었을 경우
			if(oWStream != null)
			{
				/*
				 * StreamWriter 또는 StreamReader 클래스를 활용하면 파일에 데이터를 기록하거나 파일로부터 데이터를
				 * 읽어오기 위한 명령문을 좀 더 쉽게 작성하는 것이 가능하다. (즉, 해당 클래스는 파일 스트림을 좀 더
				 * 쉽게 사용하기 위한 여러 편리 기능을 제공한다는 것을 알 수 있다.)
				 */
				var oWriter = new StreamWriter(oWStream);

				for(int i = 0; i < 10; ++i)
				{
					oWriter.WriteLine("Hello, World!");
				}

				/*
				 * 스트림은 컴퓨터 자원이기 때문에 사용이 완료되었을 경우 반드시 Close 메서드를 사용해서 스트림을
				 * 해제 할 필요가 있다. (즉, Close 메서드를 사용하지 않으면 불필요한 스트림이 계속 남아있게 되며
				 * 이는 곧 컴퓨터 자원의 고갈로 인해 더이상 스트림을 생성하는 것이 불가능하다.)
				 */
				oWriter.Close();
			}

			var oRStream = File.Open("Example/Example_16/E16_FileSystem_01.txt",
				FileMode.Open, FileAccess.Read);

			// 스트림이 생성되었을 경우
			if(oRStream != null)
			{
				var oReader = new StreamReader(oRStream);

				/*
				 * EndOfStream 프로퍼티를 활용하면 파일에 존재하는 데이터를 모두 읽어들이는 것이 가능하다. (즉,
				 * 해당 프로퍼티는 파일의 끝을 의미한다는 것을 알 수 있다.)
				 */
				while(!oReader.EndOfStream)
				{
					string oStr = oReader.ReadLine();
					Console.WriteLine("{0}", oStr);
				}

				oReader.Close();
			}
#elif E16_FILE_SYSTEM_02
			// 디렉토리가 없을 경우
			if(!Directory.Exists("Example/Example_16"))
			{
				Directory.CreateDirectory("Example/Example_16");
			}

			var oWStream = File.Open("Example/Example_16/E16_FileSystem_02.bin", 
				FileMode.Create, FileAccess.Write);

			// 스트림이 생성되었을 경우
			if(oWStream != null)
			{
				/*
				 * BinaryWriter 또는 BinaryReader 클래스를 활용하면 이진 데이터를 파일에 기록하거나 읽어들이는
				 * 것이 가능하다. (즉, StreamWriter 또는 StreamReader 클래스는 문자열 데이터를 제어한다는 것을
				 * 알 수 있다.)
				 */
				var oWriter = new BinaryWriter(oWStream);

				for(int i = 0; i < 10; ++i)
				{
					oWriter.Write(i + 1);
				}

				/*
				 * 스트림은 컴퓨터 자원이기 때문에 사용이 완료되었을 경우 반드시 Close 메서드를 사용해서 스트림을
				 * 해제 할 필요가 있다. (즉, Close 메서드를 사용하지 않으면 불필요한 스트림이 계속 남아있게 되며
				 * 이는 곧 컴퓨터 자원의 고갈로 인해 더이상 스트림을 생성하는 것이 불가능하다.)
				 */
				oWriter.Close();
			}

			var oRStream = File.Open("Example/Example_16/E16_FileSystem_02.bin",
				FileMode.Open, FileAccess.Read);

			// 스트림이 생성되었을 경우
			if(oRStream != null)
			{
				var oReader = new BinaryReader(oRStream);

				while(oReader.PeekChar() > 0)
				{
					Console.Write("{0}, ", oReader.ReadInt32());
				}

				Console.WriteLine();
				oReader.Close();
			}
#elif E16_FILE_SYSTEM_03

#endif // #if E16_FILE_SYSTEM_01
		}
	}
}
