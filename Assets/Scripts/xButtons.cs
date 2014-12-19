#region LICENSE
//==============================================================================//
//	Copyright (c) 2014 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

using UnityEngine;
using System.Collections;

public class xButtons : MonoBehaviour {

	#region Variables

	#region Scripts
	public xLogic my_logic;
	public xAudio my_audio;
	#endregion

	#region Twitter
	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en";
	public string APP_NAME = "YOUR_APP_NAME";
	public string URL = "http://bit.ly/SHORT_CODE";	//I recommend to use a short url, bit.ly or whatever
	#endregion
	
	#region Market
	//change by yours, set it on Edit/Project Settings/Player > Other Settings > Bundle Identifier
	public string BUNDLE_ID = "com.Company_name.App_name";
	#endregion

	#region buttons
	public GameObject button_mute;
	public GameObject button_unmute;
	#endregion

	#endregion

	void Awake()
	{
		//Show the correct Audio Button.
		if(xPlayerPrefs.GetBool("audio",true))
		{
			button_unmute.SetActive(true);
			button_mute.SetActive(false);
		}
	}

	public void mute(bool is_muted)
	{
		my_audio.Mute (is_muted);
	}

	public void Rate()
	{
		Application.OpenURL("market://details?id=" + BUNDLE_ID);
	}

	public void Twitter_share()
	{
		string textToDisplay = string.Format("I've got {0} points on #{1}! Get it on the Google Play! {2}",(int)my_logic.score, APP_NAME, URL);
		Application.OpenURL(TWITTER_ADDRESS +
		                    "?text=" + WWW.EscapeURL(textToDisplay) +
		                    "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
	}

	public void Home()
	{
		Application.LoadLevel(1);
	}

	public void Restart()
	{
		my_logic.Restart();
	}

	public void Pause()
	{
		my_logic.Pause();
	}

	public void Play()
	{
		my_logic.Play ();
	}
}
