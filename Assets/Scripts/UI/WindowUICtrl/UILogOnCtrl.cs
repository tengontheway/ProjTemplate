/*
    Author:     Evil.T
    CreateDate:	2016-03-22 21:57:52
    Desc:       管理登录窗口
*/
using UnityEngine;
using System.Collections;

public class UILogOnCtrl : UIWindowBase
{

	private void OnBtnClick(GameObject go)
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
		
		WindowUIMgr.Instance.CloseWindow(WindowUIType.LogOn);

		WindowUIMgr.Instance.OpenWindow(WindowUIType.Reg);
	}

	void BtnToLogOn()
	{
		
	}



}
