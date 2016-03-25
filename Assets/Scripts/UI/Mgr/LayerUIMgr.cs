/*
    Author:     Evil.T
    CreateDate:	2016-03-24 18:27:59
    Desc:       层级管理器
    			自动调整打开窗口的层级，每次打开的新窗口的所有panel都自动提升depth
*/
using UnityEngine;
using System.Collections;

public class UILayerMgr : Singleton<UILayerMgr> 
{
	const int COSNT_PANEL_START_DEPTH = 50;
	private int PanelDepth = COSNT_PANEL_START_DEPTH;

	public void Reset()
	{
		PanelDepth = COSNT_PANEL_START_DEPTH;
	}

	/// <summary>
	/// 检查打开窗口数量，如果关闭了所有的窗口，从头计数
	/// </summary>
	public void CheckOpenWindow()
	{
		if (UIWindowMgr.Instance.OpenWindowCount == 0) {
			Reset();
		}
	}

	/// <summary>
	/// 调整目标对象的层级
	/// </summary>
	/// <param name="go">Go.</param>
	public void AdjustLayer(GameObject go)
	{
		PanelDepth += 1;

		UIPanel[] panArr = go.GetComponentsInChildren<UIPanel>();
		for (int i = 0; i < panArr.Length; ++i) {
			panArr[i].depth += PanelDepth;
		}
	}
}
