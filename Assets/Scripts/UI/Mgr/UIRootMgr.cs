/*
    Author:     Evil.T
    CreateDate:	2016-03-22 18:07:41
    Desc:       场景UIRoot管理器
*/
using UnityEngine;
using System.Collections;

/// <summary>
///  场景UI管理器
/// </summary>
public class UIRootMgr : Singleton<UIRootMgr>
{
	/// <summary>
	/// 当前场景UI
	/// </summary>
	public UIRootBase CurrentUIScene;


	#region LoadUIRoot 加载场景UI
	/// <summary>
	/// 加载场景UI
	/// </summary>
	/// <returns>The scene U.</returns>
	/// <param name="type">Type.</param>
	public GameObject LoadUIRoot(UIRootType type)
	{
		GameObject obj = null;

		switch(type)
		{
		case UIRootType.LogOn:
			obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIScene, "UI Root_LogOnScene");
			CurrentUIScene = obj.GetComponent<UIRootLoginOnCtrl>();
			break;
		case UIRootType.Loading:
			obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIScene, "UI Root_Loading");
			CurrentUIScene = obj.GetComponent<UIRootLoadingCtrl>();
			break;
		case UIRootType.Game:
			obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIScene, "UI Root_Game");
			CurrentUIScene = obj.GetComponent<UIRootGameCtrl>();
			break;
		default:
			break;
		}

		return obj;
	}
	#endregion
}

