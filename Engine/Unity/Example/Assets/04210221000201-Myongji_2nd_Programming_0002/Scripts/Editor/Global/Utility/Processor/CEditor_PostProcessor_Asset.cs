using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

/**
 * 에셋 후 처리자
 */
public partial class CEditor_PostProcessor_Asset : AssetPostprocessor
{
	#region 함수
	/** 에셋이 추가되었을 경우 */
	public virtual void OnPreprocessAsset()
	{
		this.SetupImporter_Texture(this.assetImporter);
	}
	#endregion // 함수
}
#endif // #if UNITY_EDITOR
