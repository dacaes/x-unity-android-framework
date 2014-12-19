#region LICENSE
//==============================================================================//
//	Copyright (c) 2014 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

#define BONUS
//If you import iTween Package uncomment next line
//#define ITWEEN

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class xLogic : MonoBehaviour {

	#region objects
	public GameObject button_pause;
	public GameObject button_home;
	public GameObject panel;
	public GameObject panel_position1;

	public Text text_score;
	public Text text_scorepanel;
	public Text text_highscore;
	#endregion

	#region game vars
	Vector3 panel_localposition0;

	[HideInInspector]
	public bool playing = false;
	bool in_menu = true;

	[HideInInspector]
	public int score = 0;
	
	public int plus_score = 10;	//everytime you score you add this amount to your score

	//erase #define BONUS if you don't want to use it
	#if BONUS
	public int bonus_score = 0;
	#endif
	#endregion

	#region Scripts
	[HideInInspector]
	public xAudio my_audio;
	
	public xAdmob my_admob;	//AdMobVNTIS controller

	#endregion

	void Awake()
	{
		my_audio = this.gameObject.GetComponent<xAudio>();
		panel_localposition0 = panel.transform.localPosition;
	}

	public void Restart()
	{
		score = 0;
		text_score.text = score.ToString();

		panel.transform.localPosition = panel_localposition0;

		my_audio.playAudioClip(my_audio.main_theme);
		in_menu = false;
		playing = true;
	}

	public void Play()
	{
		my_audio.audio_main.Play();

		in_menu = false;
		playing = true;
	}

	public void Pause()
	{
		my_audio.audio_main.Pause();
		playing = false;
	}

	public void  Score()
	{
		score += plus_score;
		Bonus();
		text_score.text = score.ToString();
		//DificultyIncrease();	//It'sa good idea to icnrease the difficulty by score or time
	}

	[System.Diagnostics.Conditional( "BONUS" )]	//erase #define BONUS if you don't want to use it
	public void Bonus()
	{
		score += bonus_score; 
		bonus_score = 0;	//reset bonus score
	}

	public void GameOver()
	{
		my_admob.PrepareInterstitial();

		playing = false;

		//Stop all sounds before play fail sound
		my_audio.Stop();
		my_audio.playAudioClipEffect(my_audio.fail);

		//Fill scorepanel text
		text_scorepanel.text = score.ToString();//text_score.text;

		button_pause.SetActive(false);
		button_home.SetActive(true);
		text_score.text = "";

		//Update High Score
		if(score > PlayerPrefs.GetInt("high_score") || !PlayerPrefs.HasKey("high_score"))
			PlayerPrefs.SetInt("high_score",score);
		
		text_highscore.text = PlayerPrefs.GetInt("high_score").ToString();

		ShowPanel();

		my_admob.ShowInterstitial(5); //shows it 1/5 (20%) times
	}

	void Back()	//ISSUES HERE!
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if(in_menu)
				Application.LoadLevel(1);
			else
				Application.Quit();
		}
	}

	void ShowPanel()
	{
		#if ITWEEN
		iTween.MoveTo(panel, iTween.Hash("position", panel_position1.transform.position, "easeType", "easeOutExpo", "delay", .3, "time",1.5));
		#else
		panel.transform.position = panel_position1.transform.position;
		#endif
	}
}
