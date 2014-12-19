#region LICENSE
//==============================================================================//
//	Copyright (c) 2014 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

using UnityEngine;
using System.Collections;

/// <summary>
/// Audio manager class.
/// </summary>
public class xAudio : MonoBehaviour {
	#region Variables
	public GameObject MainCamera;	//Assign on inspector.
	
	AudioSource[] audio_sources;
	[HideInInspector]
	public AudioSource audio_main;
	[HideInInspector]
	public AudioSource audio_effects;

	//Common sound effects and music
	public AudioClip intro;
	public AudioClip menu;
	public AudioClip main_theme;
	public AudioClip fail;
	#endregion

	#region functions
	void Awake()
	{
		//Assign audiosources
		audio_sources = MainCamera.GetComponents<AudioSource>();
		audio_main = audio_sources[0];
		audio_effects = audio_sources[1];

		//Check and assign mute property
		audio_main.mute = xPlayerPrefs.GetBool("audio",false);
		audio_effects.mute = audio_main.mute;
	}

	void Start()
	{
		playAudioClipEffect(intro);
		playAudioClip(menu);
	}

	public void playAudioClip(AudioClip clip)
	{
		if(clip != null)
			PlayAudioClipGeneral(audio_main,clip);
		#if UNITY_EDITOR
		else
			Debug.LogWarning (string.Format("Cannot play clip, maybe the audioclip isn't assigned."));
		#endif
	}

	public void playAudioClipEffect(AudioClip clip)
	{
		if(clip != null)
			PlayAudioClipGeneral(audio_effects,clip);
		#if UNITY_EDITOR
		else
			Debug.LogWarning (string.Format("Cannot play clip, maybe the audioclip isn't assigned."));
		#endif
	}

	void PlayAudioClipGeneral(AudioSource source, AudioClip clip)
	{
		if(source != null)
		{
			source.clip = clip;
			source.Play();
		}
		#if UNITY_EDITOR
		else
			Debug.LogError (string.Format("Cannot play clip, maybe the audiosource isn't assigned."));
		#endif
	}

	public void Stop()
	{
		audio_main.Stop();
		audio_effects.Stop();
	}

	/// <summary>
	/// Set cPlayerPrefs and audiosources.
	/// </summary>
	/// <param name="is_muted">If set to <c>true</c> is_muted.</param>
	public void Mute(bool is_muted = true)
	{
		xPlayerPrefs.SetBool("audio",is_muted);
		audio_main.mute = is_muted;
		audio_effects.mute = is_muted;
	}
	#endregion
}
