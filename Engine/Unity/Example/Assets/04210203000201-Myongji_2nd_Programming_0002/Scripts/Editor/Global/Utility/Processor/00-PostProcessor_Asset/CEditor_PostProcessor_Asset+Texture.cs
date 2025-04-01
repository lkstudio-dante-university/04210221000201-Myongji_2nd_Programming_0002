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
	/** 텍스처 임포터를 설정한다 */
	protected virtual void SetupImporter_Texture(AssetImporter a_oImporter)
	{
		var oImporter_Texture = a_oImporter as TextureImporter;

		// 임포터 설정이 불가능 할 경우
		if(oImporter_Texture == null)
		{
			return;
		}

		oImporter_Texture.alphaIsTransparency = true;

		// 텍스처를 설정한다 {
		var oSettings_Texture = new TextureImporterSettings();
		oImporter_Texture.ReadTextureSettings(oSettings_Texture);

		oSettings_Texture.spriteGenerateFallbackPhysicsShape = true;
		oSettings_Texture.spriteMeshType = SpriteMeshType.FullRect;

		oImporter_Texture.SetTextureSettings(oSettings_Texture);
		// 텍스처를 설정한다 }

		// 스프라이트 타입 일 경우
		if(oImporter_Texture.textureType == TextureImporterType.Sprite)
		{
			oImporter_Texture.sRGBTexture = true;
			oImporter_Texture.mipmapEnabled = false;
			oImporter_Texture.spritePixelsPerUnit = KDefine.G_UNIT_PIXELS_PER_UNIT;
		}
	}
	#endregion // 함수
}
#endif // #if UNITY_EDITOR
