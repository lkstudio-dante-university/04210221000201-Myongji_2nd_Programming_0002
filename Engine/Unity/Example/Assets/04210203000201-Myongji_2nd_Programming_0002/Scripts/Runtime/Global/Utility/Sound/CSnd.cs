using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 사운드
 */
[RequireComponent(typeof(AudioSource))]
public partial class CSnd : CComponent
{
	#region 변수
	private AudioSource m_oAudioSource = null;
	#endregion // 변수

	#region 프로퍼티
	public bool IsMute => m_oAudioSource.mute;
	public bool IsPlaying => m_oAudioSource.isPlaying;

	public float Volume => m_oAudioSource.volume;
	#endregion // 프로퍼티

	#region 함수
	/** 초기화 */
	public override void Awake()
	{
		base.Awake();

		m_oAudioSource = this.GetComponent<AudioSource>();
		m_oAudioSource.Stop();
		m_oAudioSource.playOnAwake = false;
	}

	/** 사운드를 재생한다 */
	public void PlaySnd(AudioClip a_oAudioClip, bool a_bIs3D, bool a_bIsLoop)
	{
		m_oAudioSource.clip = a_oAudioClip;
		m_oAudioSource.spatialBlend = a_bIs3D ? 1.0f : 0.0f;
		m_oAudioSource.loop = a_bIsLoop;

		m_oAudioSource.Play();
	}

	/** 사운드를 중지한다 */
	public void StopSnd()
	{
		m_oAudioSource.Stop();
	}
	#endregion // 함수

	#region 접근 함수
	/** 음소거 여부를 변경한다 */
	public void SetIsMute(bool a_bIsMute)
	{
		m_oAudioSource.mute = a_bIsMute;
	}

	/** 볼륨을 변경한다 */
	public void SetVolume(float a_fVolume)
	{
		m_oAudioSource.volume = Mathf.Clamp01(a_fVolume);
	}
	#endregion // 접근 함수
}
