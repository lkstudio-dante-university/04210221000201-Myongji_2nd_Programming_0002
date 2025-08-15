using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 사운드 관리자
 */
public partial class CManager_Snd : CSingleton<CManager_Snd>
{
	#region 변수
	private CSnd m_oSnd_BGM = null;
	private List<CSnd> m_oListSounds_SFX = new List<CSnd>();
	#endregion // 변수

	#region 프로퍼티
	public bool IsMute_BGM { get; private set; } = false;
	public bool IsMute_SFXs { get; private set; } = false;

	public float Volume_BGM { get; private set; } = 1.0f;
	public float Volume_SFXs { get; private set; } = 1.0f;
	#endregion // 프로퍼티

	#region 함수
	/** 초기화 */
	public override void Awake()
	{
		base.Awake();

		m_oSnd_BGM = Factory.CreateGameObj_Clone<CSnd>("Snd_BGM",
			"Prefabs/Global/G_Prefab_Snd_BGM", this.gameObject);
	}

	/** 배경음을 재생한다 */
	public void PlayBGM(string a_oPath_Snd)
	{
		this.PlayBGM(Resources.Load<AudioClip>(a_oPath_Snd));
	}

	/** 배경음을 재생한다 */
	public void PlayBGM(AudioClip a_oAudioClip)
	{
		this.SetIsMute_BGM(this.IsMute_BGM);
		this.SetVolume_BGM(this.Volume_BGM);

		m_oSnd_BGM.PlaySnd(a_oAudioClip, false, true);
	}

	/** 효과음을 재생한다 */
	public void PlaySFX(string a_oPath_Snd)
	{
		this.PlaySFX(Resources.Load<AudioClip>(a_oPath_Snd));
	}

	/** 효과음을 재생한다 */
	public void PlaySFX(AudioClip a_oAudioClip)
	{
		var oSnd_SFX = Factory.CreateGameObj_Clone<CSnd>("Snd_SFX",
			"Prefabs/Global/G_Prefab_Snd_SFX", this.gameObject);

		this.SetIsMute_SFXs(this.IsMute_SFXs);
		this.SetVolume_SFXs(this.Volume_SFXs);

		oSnd_SFX.PlaySnd(a_oAudioClip, false, false);
		m_oListSounds_SFX.ExAddVal(oSnd_SFX);
	}

	/** 배경음을 중지한다 */
	public void StopBGM()
	{
		m_oSnd_BGM.StopSnd();
	}

	/** 효과음을 중지한다 */
	public void StopSFXs()
	{
		this.EnumerateSFXs((a_oSnd) => a_oSnd.StopSnd());
	}

	/** 효과음을 순회한다 */
	private void EnumerateSFXs(System.Action<CSnd> a_oCallback)
	{
		for(int i = 0; i < m_oListSounds_SFX.Count; ++i)
		{
			a_oCallback?.Invoke(m_oListSounds_SFX[i]);
		}
	}
	#endregion // 함수

	#region 접근 함수
	/** 배경음 음소거 여부를 변경한다 */
	public void SetIsMute_BGM(bool a_bIsMute)
	{
		this.IsMute_BGM = a_bIsMute;
		m_oSnd_BGM.SetIsMute(this.IsMute_BGM);
	}

	/** 효과음 음소거 여부를 변경한다 */
	public void SetIsMute_SFXs(bool a_bIsMute)
	{
		this.IsMute_SFXs = a_bIsMute;
		this.EnumerateSFXs((a_oSnd) => a_oSnd.SetIsMute(this.IsMute_SFXs));
	}

	/** 배경음 볼륨을 변경한다 */
	public void SetVolume_BGM(float a_fVolume)
	{
		this.Volume_BGM = Mathf.Clamp01(a_fVolume);
		m_oSnd_BGM.SetVolume(this.Volume_BGM);
	}

	/** 효과음 볼륨을 변경한다 */
	public void SetVolume_SFXs(float a_fVolume)
	{
		this.Volume_SFXs = Mathf.Clamp01(a_fVolume);
		this.EnumerateSFXs((a_oSnd) => a_oSnd.SetVolume(this.Volume_SFXs));
	}
	#endregion // 접근 함수
}
