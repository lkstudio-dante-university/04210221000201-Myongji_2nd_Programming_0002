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
						case ConsoleKey.A:
							AddObstacle(oWorld);
							break;

						case ConsoleKey.S:
							SplitAllObjects(oWorld);
							break;

						case ConsoleKey.R:
							Reset(oWorld);
							break;

						case ConsoleKey.UpArrow:
							m_nDelay = Math.Max(10, m_nDelay - 10);
							break;

						case ConsoleKey.DownArrow:
							m_nDelay = Math.Min(100, m_nDelay + 10);
							break;

						case ConsoleKey.Spacebar:
							ResetDirectionsMove(oWorld);
							break;
					}
				}

				Thread.Sleep(m_nDelay);
			} while(true);
		}

		/** 볼을 탐색한다 */
		private static CT01Ball_04 FindBall(CT01World_04 a_oWorld)
		{
			for(int i = 0; i < a_oWorld.ListObjects.Count; ++i)
			{
				var oBall = a_oWorld.ListObjects[i] as CT01Ball_04;

				// 볼 일 경우
				if(oBall != null && !oBall.IsDestroy)
				{
					return oBall;
				}
			}

			return null;
		}

		/** 상태를 리셋한다 */
		private static void Reset(CT01World_04 a_oWorld)
		{
			var oBall = FindBall(a_oWorld);

			// 볼이 없을 경우
			if(oBall == null)
			{
				oBall = CreateBall(a_oWorld) as CT01Ball_04;
				a_oWorld.AddObj(oBall);
			}

			for(int i = 0; i < a_oWorld.ListObjects.Count; ++i)
			{
				// 제거가 불가능 할 경우
				if(a_oWorld.ListObjects[i] == oBall)
				{
					continue;
				}

				a_oWorld.ListObjects[i].SetIsDestroy(true);
			}
		}

		/** 장애물을 추가한다 */
		private static void AddObstacle(CT01World_04 a_oWorld)
		{
			a_oWorld.AddObj(CreateObstacle(a_oWorld));
		}

		/** 객체를 쪼갠다 */
		private static void SplitAllObjects(CT01World_04 a_oWorld)
		{
			var oListObjects = new List<CT01Obj_04>();

			for(int i = 0; i < a_oWorld.ListObjects.Count; ++i)
			{
				var oBall = a_oWorld.ListObjects[i] as CT01Ball_04;

				// 분할이 불가능 할 경우
				if(oBall == null || oBall.IsDestroy)
				{
					continue;
				}

				oListObjects.Add(CreateBall(a_oWorld, oBall));
			}

			for(int i = 0; i < oListObjects.Count; ++i)
			{
				a_oWorld.AddObj(oListObjects[i]);
			}
		}

		/** 방향을 리셋한다 */
		private static void ResetDirectionsMove(CT01World_04 a_oWorld)
		{
			for(int i = 0; i < a_oWorld.ListObjects.Count; ++i)
			{
				var oBall = a_oWorld.ListObjects[i] as CT01Ball_04;

				// 볼이 아닐 경우
				if(oBall == null)
				{
					continue;
				}

				oBall.SetDirectionX((m_oRandom.Next(0, 2) <= 0) ? -1 : 1);
				oBall.SetDirectionY((m_oRandom.Next(0, 2) <= 0) ? -1 : 1);
			}
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
		private static CT01Obj_04 CreateBall(CT01World_04 a_oWorld, CT01Ball_04 a_oBall)
		{
			var oBall = CreateBallRandom(a_oWorld);
			oBall.SetPosX(a_oBall.PosX);
			oBall.SetPosY(a_oBall.PosY);

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
