/*
    Author:     Evil.T
    CreateDate:	2016-03-22 21:27:19
    Desc:       窗口管理器
*/
using UnityEngine;
using System.Collections;

/// <summary>
/// 场景管理器
/// </summary>
public class WindowUIMgr : Singleton<WindowUIMgr>
{
	public enum WindowUIType
	{
		Reg,			// 注册
		LogOn,			// 登录
	}

	public enum WindowUIContainerType
	{
		TL,
		TR,
		BL,
		BR,
		Center
	}

	/// <summary>
	/// 加载窗口
	/// </summary>
	/// <returns>The window.</returns>
	/// <param name="type">Type.</param>
	public GameObject LoadWindow(WindowUIType type, WindowUIContainerType containerType = WindowUIContainerType.Center)
	{
		GameObject obj = null;

		switch(type)
		{
		case WindowUIType.Reg:
			obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIWindow, "panReg", cache:true);
			break;
		case WindowUIType.LogOn:
			obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIWindow, "panLogOn", cache:true);
			break;
		default:
			break;
		}

		obj.transform.parent = SceneUIMgr.Instance.CurrentUIScene.ContainerCenter;
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localScale = Vector3.one;

		return obj;
	}
}
