using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E02Example
{
	/**
	 * 장애물
	 */
	public partial class CE02Obstacle_17 : CComponent
	{
		#region 변수
		[Header("=====> Obstacle - Etc <=====")]
		[SerializeField] private List<Texture2D> m_oList_Textures = new List<Texture2D>();
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
			int nIdx = Random.Range(0, m_oList_Textures.Count);

			var oRenderer_Mesh = this.GetComponentInChildren<MeshRenderer>();
			oRenderer_Mesh.material.mainTexture = m_oList_Textures[nIdx];
		}
		#endregion // 함수
	}
}
