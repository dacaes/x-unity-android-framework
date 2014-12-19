#region LICENSE
//==============================================================================//
//	Copyright (c) 2014 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

using UnityEngine;
using System.Collections;

public class xLoad : MonoBehaviour {
	
	void Start () {
		StartCoroutine(WaitAndLoad (2));
	}

	IEnumerator WaitAndLoad(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		Application.LoadLevel(1);
	}

	public void Load()
	{
		Application.LoadLevel(1);
	}
}
