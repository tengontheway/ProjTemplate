/*
    Author:     Evil.T
    CreateDate:	2016-03-22 17:46:20
    Desc:       管理所有场景
*/
using UnityEngine;
using System.Collections;

public class SceneMgr : Singleton<SceneMgr> 
{
	/// <summary>
	/// 仓前场景类型
	/// </summary>
	/// <value>The type of the current scene.</value>
	public SceneType CurrentSceneType
	{
		get;
		private set;
	}

	/// <summary>
	/// 记载登录场景
	/// </summary>
	public void LoadLogOn()
	{
		CurrentSceneType = SceneType.LogOn;

		Application.LoadLevel("Scene_Loading");
	}

	public void LoadGame()
	{
		CurrentSceneType = SceneType.Game;

		Application.LoadLevel("Scene_Loading");
	}
}
