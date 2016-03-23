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
		WindowUIMgr.Instance.LoadWindow(WindowUIMgr.WindowUIType.LogOn);
	}
}
