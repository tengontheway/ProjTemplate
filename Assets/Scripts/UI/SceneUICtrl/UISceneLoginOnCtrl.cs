/*
    Author:     Evil.T
    CreateDate:	2016-03-22 21:21:17
    Desc:       登录场景管理
*/
using UnityEngine;
using System.Collections;

public class UISceneLoginOnCtrl : UISceneBase
{
	protected override void OnStart()
	{
		base.OnStart();

		WindowUIMgr.Instance.OpenWindow(WindowUIType.LogOn);
	}

	void Update()
	{
		if (Input.GetKeyUp(KeyCode.O))
		{
			WindowUIMgr.Instance.OpenWindow(WindowUIType.LogOn);	
		}

		if (Input.GetKeyUp(KeyCode.P)) 
		{
			WindowUIMgr.Instance.CloseWindow(WindowUIType.LogOn);
		}
	}
}
