/*
    Author:     Evil.T
    CreateDate:	2016-03-22 21:57:52
    Desc:       管理登录窗口
*/
using UnityEngine;
using System.Collections;

public class UILogOnCtrl : MonoBehaviour {

	void Awake()
	{
		UIButton[] arrBtns = GetComponentsInChildren<UIButton>(true);
		for (int i = 0; i < arrBtns.Length; ++i) {
			UIEventListener.Get(arrBtns[i].gameObject).onClick = BtnClick;
		}
	}

	private void BtnClick(GameObject go)
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
		Destroy(gameObject);

		WindowUIMgr.Instance.LoadWindow(WindowUIMgr.WindowUIType.Reg);
	}

	void BtnToLogOn()
	{
		
	}



}
