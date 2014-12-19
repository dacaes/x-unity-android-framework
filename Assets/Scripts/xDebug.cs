#region LICENSE
//==============================================================================//
//	Copyright (c) 2014 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

#define LOG
#define WARN
#define ERROR
#define DEBUG

using UnityEngine;
using System.Collections;

public static class xDebug {

	[System.Diagnostics.Conditional( "LOG" )]
	[System.Diagnostics.Conditional( "DEBUG" )]
	[System.Diagnostics.Conditional( "UNITY_EDITOR" )]
	public static void Log(object message)
	{
		Debug.Log(message);
	}

	[System.Diagnostics.Conditional( "LOG" )]
	[System.Diagnostics.Conditional( "DEBUG" )]
	[System.Diagnostics.Conditional( "UNITY_EDITOR" )]
	public static void Log(object message, Object context)
	{
		Debug.Log(message,context);
	}

	[System.Diagnostics.Conditional( "WARN" )]
	[System.Diagnostics.Conditional( "DEBUG" )]
	[System.Diagnostics.Conditional( "UNITY_EDITOR" )]
	public static void LogWarning(object message)
	{
		Debug.LogWarning(message);
	}

	[System.Diagnostics.Conditional( "WARN" )]
	[System.Diagnostics.Conditional( "DEBUG" )]
	[System.Diagnostics.Conditional( "UNITY_EDITOR" )]
	public static void LogWarning(object message, Object context)
	{
		Debug.LogWarning(message,context);
	}

	[System.Diagnostics.Conditional( "ERROR" )]
	[System.Diagnostics.Conditional( "DEBUG" )]
	[System.Diagnostics.Conditional( "UNITY_EDITOR" )]
	public static void LogError(object message)
	{
		Debug.LogError(message);
	}

	[System.Diagnostics.Conditional( "ERROR" )]
	[System.Diagnostics.Conditional( "DEBUG" )]
	[System.Diagnostics.Conditional( "UNITY_EDITOR" )]
	public static void LogError(object message, Object context)
	{
		Debug.LogError(message,context);
	}
}
