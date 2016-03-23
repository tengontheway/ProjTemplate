/*
    Author:     Evil.T
    CreateDate:	2016-03-22 21:27:19
    Desc:       窗口管理器
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 场景管理器
/// </summary>
public class WindowUIMgr : Singleton<WindowUIMgr>
{
	private Dictionary<WindowUIType, UIWindowBase> dicWindows = new Dictionary<WindowUIType, UIWindowBase>();
	
	#region Window 打开窗口/关闭窗口
	/// <summary>
	/// 打开窗口
	/// </summary>
	/// <returns>The window.</returns>
	/// <param name="type">窗口类型</param>
	public GameObject OpenWindow(WindowUIType type)
	{
		if (dicWindows.ContainsKey(type)) return null;
		
		GameObject obj = null;

		// 窗口名字必须与窗口类型保持一致
		obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIWindow, string.Format("pan{0}", type.ToString()), cache:true);;

		obj.transform.parent = SceneUIMgr.Instance.CurrentUIScene.ContainerCenter;
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localScale = Vector3.one;
		NGUITools.SetActive(obj, false);

		UIWindowBase windowBase = obj.GetComponent<UIWindowBase>();
		windowBase.currentUIType = type;
		dicWindows.Add(type, windowBase);

		StartShowWindow(windowBase, true);
		return obj;
	}

	/// <summary>
	/// 关闭窗口
	/// </summary>
	/// <returns>The window.</returns>
	/// <param name="type">Type.</param>
	public void CloseWindow(WindowUIType type)
	{
		if (dicWindows.ContainsKey(type)) {
			StartShowWindow(dicWindows[type], false);
		}
	}
	#endregion

	/// <summary>
	/// 显示窗口
	/// </summary>
	/// <param name="go">窗口对象</param>">
	/// <param name="style">显示窗口的风格</param>
	/// <param name="isOpen">true打开窗口 false关闭窗口 </param>
	void StartShowWindow(UIWindowBase window, bool isOpen)
	{
		switch(window.showStyle)
		{
		case WindowShowStyle.Normal:
			ShowNormalWindow(window, isOpen);
			break;
		case WindowShowStyle.CenterToBig:
			ShowCenterToBig(window, isOpen);
			break;
		case WindowShowStyle.FromTop:
			ShowFromDir(window, 1, isOpen);
			break;
		case WindowShowStyle.FromDown:
			ShowFromDir(window, 2, isOpen);
			break;
		case WindowShowStyle.FromLeft:
			ShowFromDir(window, 3, isOpen);
			break;
		case WindowShowStyle.FromRight:
			ShowFromDir(window, 4, isOpen);
			break;
		}
	}

	/// <summary>
	/// 销毁窗口
	/// </summary>
	/// <param name="go">Go.</param>
	private void DestroyWindow(UIWindowBase window)
	{
		GameObject.Destroy(window.gameObject);
		dicWindows.Remove(window.currentUIType);
	}

	#region 打开窗口的效果
	/// <summary>
	/// 以普通方式显示/隐藏窗口
	/// </summary>
	/// <param name="go">Go.</param>
	/// <param name="isOpen">If set to <c>true</c> is open.</param>
	private void ShowNormalWindow(UIWindowBase window, bool isOpen)
	{
		if (isOpen)
		{
			NGUITools.SetActive(window.gameObject, true);
		} 
		else 
		{
			DestroyWindow(window);
		}
	}

	/// <summary>
	/// 由小变大
	/// </summary>
	/// <param name="go">Go.</param>
	/// <param name="isOpen">If set to <c>true</c> is open.</param>
	private void ShowCenterToBig(UIWindowBase window, bool isOpen)
	{
		TweenScale ts = NGUITools.AddMissingComponent<TweenScale>(window.gameObject);
		ts.animationCurve = GlobalInit.Instance.UIAnimationCurve;
		ts.from = Vector3.zero;
		ts.to = Vector3.one;
		ts.duration = window.duration;
		ts.SetOnFinished(()=>
			{
				if (!isOpen)
					DestroyWindow(window);
			});
		NGUITools.SetActive(window.gameObject, true);

		// 关闭窗口,播放缩小动画
		if (!isOpen) ts.Play(isOpen);
	}

	/// <summary>
	/// 从各个方向播放动画
	/// </summary>
	/// <param name="window">Window.</param>
	/// <param name="dirType">1从上 2从下 3从左 4从右</param>
	/// <param name="isOpen">If set to <c>true</c> is open.</param>
	private void ShowFromDir(UIWindowBase window, int dirType,  bool isOpen)
	{
		TweenPosition ts = NGUITools.AddMissingComponent<TweenPosition>(window.gameObject);
		ts.animationCurve = GlobalInit.Instance.UIAnimationCurve;

		Vector3 from = Vector3.zero;
		switch(dirType)
		{
		case 1:
			from = new Vector3(0, 1000, 0);
			break;
		case 2:
			from = new Vector3(0, -1000, 0);
			break;
		case 3:
			from = new Vector3(-1400, 0, 0);
			break;
		case 4:
			from = new Vector3(1400, 0, 0);
			break;
		}
		ts.from = from;

		ts.to = Vector3.one;
		ts.duration = window.duration;
		ts.SetOnFinished(()=>
			{
				if (!isOpen)
					DestroyWindow(window);
			});
		NGUITools.SetActive(window.gameObject, true);

		// 关闭窗口,播放缩小动画
		if (!isOpen) ts.Play(isOpen);
	}
	#endregion
}
