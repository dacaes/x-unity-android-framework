#region LICENSE
//==============================================================================//
//	Copyright (c) 2014 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

//#define BANNER
//#define INTERSTITIAL

using UnityEngine;
using System.Collections;

/// <summary>
/// Class for manage AdmobVNTIS package.
/// </summary>
public class xAdmob : MonoBehaviour{

	#region Variables
	//erase #define BANNER if you don't want to use it
	#if BANNER
	public AdmobVNTIS my_banner;
	#endif
	//erase #define INTERSTITIAL if you don't want to use it
	#if INTERSTITIAL
	public AdmobVNTIS_Interstitial my_interstitial;
	#endif
	#endregion

	#region Functions
	[System.Diagnostics.Conditional( "INTERSTITIAL" )]
	public void PrepareInterstitial()
	{
		#if INTERSTITIAL
		my_interstitial.prepareInterstitial();
		#endif
	}

	[System.Diagnostics.Conditional( "INTERSTITIAL" )]
	public void ShowInterstitial()
	{
		#if INTERSTITIAL
		my_interstitial.showInterstitial();
		#endif
	}

	[System.Diagnostics.Conditional( "INTERSTITIAL" )]
	public void ShowInterstitial(int divider)
	{
		if(Random.Range(1, divider+1) == 1)
		{
			#if INTERSTITIAL
			my_interstitial.showInterstitial();
			#endif
		}
	}

	[System.Diagnostics.Conditional( "BANNER" )]
	public void ShowBanner()
	{
		#if BANNER
		my_banner.showBanner();
		#endif
	}

	[System.Diagnostics.Conditional( "BANNER" )]
	public void HideBanner()
	{
		#if BANNER
		my_banner.hideBanner();
		#endif
	}
	#endregion
}
