using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._04210221000201_Myongji_2nd_Programming_0002.E01.Training.Classes.Runtime.Training_04
{
	/** 최상단 객체 */
	internal class CT01Obj_04
	{
		public int PosX { get; private set; } = 0;
		public int PosY { get; private set; } = 0;

		public bool IsDestroy { get; private set; } = false;
		public ConsoleColor Color { get; private set; } = ConsoleColor.White;

		/** 상태를 갱신한다 */
		public virtual void Update(CT01World_04 a_oWorld)
		{
			// Do Something
		}

		/** 충돌을 처리한다 */
		public virtual void HandleCollision(CT01Obj_04 a_oTarget)
		{
			// Do Something
		}

		/** 객체를 그린다 */
		public void Draw(CT01World_04 a_oWorld)
		{
			Console.ForegroundColor = this.Color;
			Console.SetCursorPosition(this.PosX, this.PosY);

			this.DoDraw(a_oWorld);
			Console.ResetColor();
		}

		/** X 위치를 변경한다 */
		public void SetPosX(int a_nPosX)
		{
			this.PosX = a_nPosX;
		}

		/** Y 위치를 변경한다 */
		public void SetPosY(int a_nPosY)
		{
			this.PosY = a_nPosY;
		}

		/** 제거 여부를 변경한다 */
		public void SetIsDestroy(bool a_bIsDestroy)
		{
			this.IsDestroy = a_bIsDestroy;
		}

		/** 색상을 변경한다 */
		public void SetColor(ConsoleColor a_eColor)
		{
			this.Color = a_eColor;
		}

		/** 객체를 그린다 */
		protected virtual void DoDraw(CT01World_04 a_oWorld)
		{
			// Do Something
		}
	}

	/** 이동 가능 객체 */
	internal class CT01ObjMovable_04 : CT01Obj_04
	{
		public int DirectionX { get; private set; } = 0;
		public int DirectionY { get; private set; } = 0;

		/** 상태를 갱신한다 */
		public override void Update(CT01World_04 a_oWorld)
		{
			base.Update(a_oWorld);

			int nPosXNext = this.PosX + this.DirectionX;
			int nPosYNext = this.PosY + this.DirectionY;

			// 좌/우 범위를 벗어났을 경우
			if(nPosXNext <= 0 || nPosXNext >= a_oWorld.Width - 1)
			{
				this.DirectionX = -this.DirectionX;
			}

			// 상/하 범위를 벗어났을 경우
			if(nPosYNext <= 0 || nPosYNext >= a_oWorld.Height - 1)
			{
				this.DirectionY = -this.DirectionY;
			}

			this.SetPosX(this.PosX + this.DirectionX);
			this.SetPosY(this.PosY + this.DirectionY);
		}

		/** X 방향을 변경한다 */
		public void SetDirectionX(int a_nDirection)
		{
			this.DirectionX = a_nDirection;
		}

		/** Y 방향을 변경한다 */
		public void SetDirectionY(int a_nDirection)
		{
			this.DirectionY = a_nDirection;
		}
	}

	/** 볼 */
	internal class CT01Ball_04 : CT01ObjMovable_04
	{
		/** 물체를 그린다 */
		protected override void DoDraw(CT01World_04 a_oWorld)
		{
			base.DoDraw(a_oWorld);
			Console.Write("*");
		}
	}

	/** 녹색 볼 */
	internal class CT01BallGreen_04 : CT01Ball_04
	{
		private int m_nTimesReflection = 0;

		/** 생성자 */
		public CT01BallGreen_04()
		{
			this.SetColor(ConsoleColor.Green);
		}

		/** 상태를 갱신한다 */
		public override void Update(CT01World_04 a_oWorld)
		{
			int nDirectionXPrev = this.DirectionX;
			int nDirectionYPrev = this.DirectionY;

			base.Update(a_oWorld);

			bool bIsReflectionA = this.DirectionX != nDirectionXPrev;
			bool bIsReflectionB = this.DirectionY != nDirectionYPrev;

			m_nTimesReflection += (bIsReflectionA || bIsReflectionB) ? 1 : 0;
			this.SetIsDestroy(m_nTimesReflection >= 5);
		}
	}

	/** 노란 볼 */
	internal class CT01BallYellow_04 : CT01Ball_04
	{
		/** 생성자 */
		public CT01BallYellow_04()
		{
			this.SetColor(ConsoleColor.Yellow);
		}

		/** 충돌을 처리한다 */
		public override void HandleCollision(CT01Obj_04 a_oTarget)
		{
			// 충돌 처리가 불가능 할 경우
			if(this.IsDestroy || a_oTarget.IsDestroy)
			{
				return;
			}

			var oBall = a_oTarget as CT01Ball_04;
			oBall?.SetIsDestroy(true);
		}
	}

	/** 장애물 */
	internal class CT01Obstacle_04 : CT01Obj_04
	{
		/** 생성자 */
		public CT01Obstacle_04()
		{
			this.SetColor(ConsoleColor.Red);
		}

		/** 충돌을 처리한다 */
		public override void HandleCollision(CT01Obj_04 a_oTarget)
		{
			// 충돌 처리가 불가능 할 경우
			if(this.IsDestroy || a_oTarget.IsDestroy)
			{
				return;
			}

			a_oTarget.SetIsDestroy(true);
		}

		/** 물체를 그린다 */
		protected override void DoDraw(CT01World_04 a_oWorld)
		{
			base.DoDraw(a_oWorld);
			Console.Write("#");
		}
	}
}
