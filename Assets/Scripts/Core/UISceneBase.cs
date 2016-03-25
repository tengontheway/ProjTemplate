/*
    Author:     Evil.T
    CreateDate:	2016-03-22 22:48:06
    Desc:       所有UIScene的基类，
*/
using UnityEngine;
using System.Collections;

public class UIRootBase: UIBase
{
	/// <summary>
	/// 挂载点
	/// </summary>
	[SerializeField]
	public Transform ContainerCenter;
}
