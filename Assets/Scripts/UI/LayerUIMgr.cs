/*
    Author:     Evil.T
    CreateDate:	2016-03-24 18:27:59
    Desc:       你眼瞎啊,不写注释
*/
using UnityEngine;
using System.Collections;

public class LayerUIMgr : Singleton<LayerUIMgr> 
{
	const int COSNT_PANEL_DEPTH = 50;
	private int PanelDepth = 50;

	public void Reset()
	{
		PanelDepth = 50;
	}

	/// <summary>
	/// 检查打开窗口数量，如果关闭了所有的窗口，从头计数
	/// </summary>
	public void CheckOpenWindow()
	{
		if (WindowUIMgr.Instance.OpenWindowCount == 0) {
			Reset();
		}
	}

	public void SetLayer(GameObject go)
	{
		PanelDepth += 1;

		UIPanel[] panArr = go.GetComponentsInChildren<UIPanel>();
		for (int i = 0; i < panArr.Length; ++i) {
			panArr[i].depth += PanelDepth;
		}
	}
}
