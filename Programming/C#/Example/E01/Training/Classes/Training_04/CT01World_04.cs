using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01.Training.Classes.Training_04
{
	/** 월드 */
	internal class CT01World_04
	{
		public int Width { get; private set; } = 0;
		public int Height { get; private set; } = 0;

		public List<CT01Obj_04> ListObjects { get; private set; } = new List<CT01Obj_04>();
		public List<CT01Obj_04> ListObjectsRemove { get; private set; } = new List<CT01Obj_04>();

		/** 생성자 */
		public CT01World_04(int a_nWidth, int a_nHeight)
		{
			this.Width = a_nWidth + 2;
			this.Height = a_nHeight + 2;
		}

		/** 상태를 갱신한다 */
		public void UpdateObjects()
		{
			for(int i = 0; i < this.ListObjects.Count; ++i)
			{
				this.ListObjects[i].Update(this);
			}
		}

		/** 충돌 상태를 갱신한다 */
		public void UpdateObjectsCollision()
		{
			this.ListObjectsRemove.Clear();

			for(int i = 0; i < this.ListObjects.Count; ++i)
			{
				this.UpdateCollisionState(this.ListObjects[i]);

				// 제거 상태가 아닐 경우
				if(!this.ListObjects[i].IsDestroy)
				{
					continue;
				}

				this.ListObjectsRemove.Add(this.ListObjects[i]);
			}

			for(int i = 0; i < this.ListObjectsRemove.Count; ++i)
			{
				this.ListObjects.Remove(this.ListObjectsRemove[i]);
			}
		}

		/** 객체를 추가한다 */
		public void AddObj(CT01Obj_04 a_oObj)
		{
			this.ListObjects.Add(a_oObj);
		}

		/** 물체를 그린다 */
		public void DrawObjects()
		{
			this.DrawOutline();

			for(int i = 0; i < this.ListObjects.Count; ++i)
			{
				// 제거되었을 경우
				if(this.ListObjects[i].IsDestroy)
				{
					continue;
				}

				this.ListObjects[i].Draw(this);
			}
		}

		/** 충돌 상태를 갱신한다 */
		private void UpdateCollisionState(CT01Obj_04 a_oObj)
		{
			int nPosX = a_oObj.PosX;
			int nPosY = a_oObj.PosY;

			for(int i = 0; i < this.ListObjects.Count; ++i)
			{
				int nPosXTarget = this.ListObjects[i].PosX;
				int nPosYTarget = this.ListObjects[i].PosY;

				bool bIsCollision = a_oObj != this.ListObjects[i];
				bIsCollision = bIsCollision && nPosX == nPosXTarget;
				bIsCollision = bIsCollision && nPosY == nPosYTarget;

				// 충돌 상태가 아닐 경우
				if(!bIsCollision)
				{
					continue;
				}

				a_oObj.HandleCollision(this.ListObjects[i]);
				this.ListObjects[i].HandleCollision(a_oObj);
			}
		}

		/** 외곽선을 그린다 */
		private void DrawOutline()
		{
			var oStrBuilder = new StringBuilder();

			for(int i = 0; i < this.Height; ++i)
			{
				for(int j = 0; j < this.Width; ++j)
				{
					bool bIsOutlineA = j <= 0 || j >= this.Width - 1;
					bool bIsOutlineB = i <= 0 || i >= this.Height - 1;

					oStrBuilder.Append((bIsOutlineA || bIsOutlineB) ? '#' : ' ');
				}

				oStrBuilder.AppendLine();
			}

			Console.SetCursorPosition(0, 0);
			Console.WriteLine("{0}", oStrBuilder.ToString());
		}
	}
}
