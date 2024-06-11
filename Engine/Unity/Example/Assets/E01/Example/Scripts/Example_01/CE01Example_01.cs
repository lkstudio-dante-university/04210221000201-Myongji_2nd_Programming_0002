using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E01
{
	/**
	 * Example 1
	 */
	public class CE01Example_01 : MonoBehaviour
	{
		#region 변수
		[Header("=====> Example - Game Objects <=====")]
		[SerializeField] private GameObject m_oObjRoot = null;
		[SerializeField] private List<GameObject> m_oListPrefabs = new List<GameObject>();
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public void Awake()
		{
			Debug.Log("Hello, World!");
		}

		/** 상태를 갱신한다 */
		public void Update()
		{
			// 스페이스 키를 눌렀을 경우
			if(Input.GetKeyDown(KeyCode.Space))
			{
				int nIdx = Random.Range(0, m_oListPrefabs.Count);
				var oGameObj = Instantiate(m_oListPrefabs[nIdx], Vector3.zero, Quaternion.identity);

				oGameObj.transform.SetParent(m_oObjRoot.transform, false);

				oGameObj.transform.localScale = new Vector3(Random.Range(1.0f, 2.0f),
					Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f));
			}
		}
		#endregion // 함수
	}
}
