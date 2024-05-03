using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01.Training.Classes.Training_04
{
	/**
	 * Training 4
	 */
	internal class CT01Training_04
	{
		private static int m_nDelay = 100;
		private static Random m_oRandom = new Random();

		/** 초기화 */
		public static void Start(string[] args)
		{
			var oWorld = new CT01World_04(45, 15);
			oWorld.AddObj(CreateBall(oWorld));

			do
			{
				oWorld.UpdateObjects();
				oWorld.UpdateObjectsCollision();

				oWorld.DrawObjects();

				// 키를 눌렀을 경우
				if(Console.KeyAvailable)
				{
					var stKeyInfo = Console.ReadKey(true);

					switch(stKeyInfo.Key)
					{
						case ConsoleKey.S: SplitAllObjects(oWorld); break;
						case ConsoleKey.Spacebar: ResetDirectionsMove(oWorld); break;
					}
				}

				Thread.Sleep(m_nDelay);
			} while(true);
		}

		/** 객체를 쪼갠다 */
		private static void SplitAllObjects(CT01World_04 a_oWorld)
		{
			// Do Something
		}

		/** 방향을 리셋한다 */
		private static void ResetDirectionsMove(CT01World_04 a_oWorld)
		{
			// Do Something
		}

		/** 볼을 생성한다 */
		private static CT01Obj_04 CreateBall(CT01World_04 a_oWorld)
		{
			var oBall = CreateBallRandom(a_oWorld);
			oBall.SetPosX(m_oRandom.Next(1, a_oWorld.Width - 1));
			oBall.SetPosY(m_oRandom.Next(1, a_oWorld.Height - 1));

			oBall.SetDirectionX((m_oRandom.Next(0, 2) <= 0) ? -1 : 1);
			oBall.SetDirectionY((m_oRandom.Next(0, 2) <= 0) ? -1 : 1);

			return oBall;
		}

		/** 볼을 생성한다 */
		private static CT01Ball_04 CreateBallRandom(CT01World_04 a_oWorld)
		{
			int nRandom = m_oRandom.Next(0, 100);

			// 일반 볼 일 경우
			if(nRandom <= 30)
			{
				return new CT01Ball_04();
			}

			return (nRandom <= 90) ? new CT01BallGreen_04() : new CT01BallYellow_04();
		}

		/** 장애물을 생성한다 */
		private static CT01Obstacle_04 CreateObstacle(CT01World_04 a_oWorld)
		{
			var oObstacle = new CT01Obstacle_04();
			oObstacle.SetPosX(m_oRandom.Next(1, a_oWorld.Width - 1));
			oObstacle.SetPosY(m_oRandom.Next(1, a_oWorld.Height - 1));

			return oObstacle;
		}
	}
}
