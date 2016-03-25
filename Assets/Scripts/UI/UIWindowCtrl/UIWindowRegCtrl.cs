/*
    Author:     Evil.T
    CreateDate:	2016-03-22 21:58:05
    Desc:       你眼瞎啊,不写注释
*/
using UnityEngine;
using System.Collections;

public class UIWindowRegCtrl : UIWindowBase
{
	protected  override void OnBtnClick(GameObject go)
	{
		switch(go.name)
		{
		case "btnClose":
			BtnToLogOn();
			break;
		case "btnOK":
			BtnToLogOn();
			break;
		}
	}

	void BtnToLogOn()
	{
//		Close();
//
//		targetWindow = WindowUIType.LogOn;

		UIWindowMgr.Instance.OpenWindow(WindowUIType.LogOn);
	}

}
