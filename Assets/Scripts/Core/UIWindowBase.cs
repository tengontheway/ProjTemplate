/*
    Author:     Evil.T
    CreateDate:	2016-03-22 23:21:52
    Desc:       所有窗口的基类
*/
using UnityEngine;
using System.Collections;

public class UIWindowBase : UIBase 
{
	/// <summary>
	/// 挂点类型
	/// </summary>
	[SerializeField]
	public WindowUIContainerType containerType = WindowUIContainerType.Center;

	/// <summary>
	/// 打开方式 
	/// </summary>
	[SerializeField]
	public WindowShowStyle showStyle = WindowShowStyle.Normal;

	/// <summary>
	/// 打开、关闭窗口的时间
	/// </summary>
	[SerializeField]
	public float duration = 0.2f;

	/// <summary>
	/// 当前窗口类型
	/// </summary>
	[HideInInspector]
	public WindowUIType currentUIType;
}
