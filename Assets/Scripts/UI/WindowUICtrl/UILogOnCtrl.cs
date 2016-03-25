/*
    Author:     Evil.T
    CreateDate:	2016-03-22 21:57:52
    Desc:       管理登录窗口
*/
using UnityEngine;
using System.Collections;

public class UILogOnCtrl : UIWindowBase
{
	protected override void OnBtnClick(GameObject go)
	{
		switch(go.name)
		{
		case "btnReg":
			BtnToReg();
			break;
		case "btnLogOn":
			BtnToLogOn();
			break;
		}
	}
		
	void BtnToReg()
	{
//		targetWindow = WindowUIType.Reg;
//
//		Close();
		WindowUIMgr.Instance.OpenWindow(WindowUIType.Reg);
	}

	void BtnToLogOn()
	{
		SceneMgr.Instance.LoadGame()	;
	}
}
