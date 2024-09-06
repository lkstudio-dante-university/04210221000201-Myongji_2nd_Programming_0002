//#define E16_FILE_SYSTEM_01
//#define E16_FILE_SYSTEM_02
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
namespace Example._04010203000201_M_2_Programming_0002.E01.Example.Classes.Runtime.Example_16
{
	/**
	 * Example 16
	 */
	internal class CE01Example_16
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			string oPathDir = "../../../04010000000001-Myongji/Example/E01/Resources/Example_16";

#if E16_FILE_SYSTEM_01
			/*
			 * Directory 클래스는 디렉토리 (폴더) 를 제어하는 역할을 수행한다. (즉, Directory 클래스를 활용하면 
			 * 폴더를 생성하거나 폴더 안에 존재하는 파일의 목록을 가져오는 것이 가능하다.)
			 */
			// 디렉토리가 없을 경우
			if(!Directory.Exists(oPathDir))
			{
				Directory.CreateDirectory(oPathDir);
			}

			/*
			 * File 클래스는 파일을 제어하는 역할을 수행한다. (즉, File 클래스를 활용하면 파일에 데이터를 저장하거나
			 * 읽어들이기 위한 스트림을 생성하는 것이 가능하다.)
			 * 
			 * File.Open 메서드는 스트림을 생성하는 역할을 수행한다. (즉, 해당 메서드에 입력되는 데이터에 따라
			 * 출력용 또는 입력용 스트림을 생성하는 것이 가능하다.)
			 * 
			 * 또한, File.Open 메서드는 스트림을 출력용으로 생성 할 경우 파일을 생성하는 역할도 수행한다. (즉, 
			 * 존재하지 않는 파일을 대상으로 출력용 스트림을 생성 할 경우 파일을 생성 후 스트림을 생성한다는 것을
			 * 알 수 있다.)
			 */
			var oWStream = File.Open(oPathDir + "/E01Example_16_01.txt", FileMode.Create, FileAccess.Write);

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

			var oRStream = File.Open(oPathDir + "/E01Example_16_01.txt", FileMode.Open, FileAccess.Read);

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
			if(!Directory.Exists(oPathDir))
			{
				Directory.CreateDirectory(oPathDir);
			}

			var oWStream = File.Open(oPathDir + "/E01Example_16_02.bin", FileMode.Create, FileAccess.Write);

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

			var oRStream = File.Open(oPathDir + "/E01Example_16_02.bin", FileMode.Open, FileAccess.Read);

			// 스트림이 생성되었을 경우
			if(oRStream != null)
			{
				var oReader = new BinaryReader(oRStream);

				/*
				 * 파일 스트림의 Position 프로퍼티와 Length 프로퍼티를 활용하면 파일에 존재하는 데이터를 모두 
				 * 읽어들이는 것이 가능하다. (즉, Position 프로퍼티는 현재 읽어들일 데이터의 위치 정보를 나타내며 
				 * 파일로부터 데이터를 읽어들 일 때마다 위치가 자동으로 갱신된다는 것을 알 수 있다.)
				 */
				while(oReader.BaseStream.Position < oReader.BaseStream.Length)
				{
					Console.Write("{0}, ", oReader.ReadInt32());
				}

				oReader.Close();
				Console.WriteLine();
			}
#elif E16_FILE_SYSTEM_03
			/*
			 * args 배열에는 프로그램을 실행 할 때 추가적으로 전달 한 데이터가 문자열의 형태로 저장되어있기 때문에 
			 * 해당 변수를 활용하면 프로그램을 시작 시 추가적인 옵션을 전달받는 것이 가능하다. (즉, args 배열을
			 * 활용하면 터미널 명령어처럼 동작하는 프로그램을 제작하는 것이 가능하다.)
			 */
			// 잘못 된 형식 일 경우
			if(args.Length < 2)
			{
				Console.WriteLine("[실행 파일] [원본 파일 경로] [사본 파일 경로] 형식으로 입력해주세요.");
				return;
			}

			var oRStream = File.Open(args[0], FileMode.Open, FileAccess.Read);
			var oWStream = File.Open(args[1], FileMode.Create, FileAccess.Write);

			// 스트림이 생성되었을 경우
			if(oRStream != null && oWStream != null)
			{
				var oBytes = new byte[byte.MaxValue];
				int nNumBytes = 0;

				while((nNumBytes = oRStream.Read(oBytes, 0, oBytes.Length)) > 0)
				{
					oWStream.Write(oBytes, 0, nNumBytes);
				}

				oRStream.Close();
				oWStream.Close();

				Console.WriteLine("파일 복사가 완료되었습니다.");
			}
#endif // #if E16_FILE_SYSTEM_01
		}
	}
}
