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
/// Extension class for PlayerPrefs.
/// </summary>
public static class xPlayerPrefs {

	public static void SetBool (string name, bool value) {
		
		PlayerPrefs.SetInt(name, value?1:0);
	}
	
	public static bool GetBool (string name) {
		return PlayerPrefs.GetInt(name)==1?true:false;
	}
	
	public static bool GetBool (string name, bool defaultValue) {
		if (PlayerPrefs.HasKey(name)) {
			return GetBool(name);
		}
		return defaultValue;
	}
}
