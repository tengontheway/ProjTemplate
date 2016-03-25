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
public class SceneUIMgr : Singleton<SceneUIMgr>
{

	public enum SceneUIType
	{
		LogOn,			// 登录
		Loading,		// 过场
		Game			// 游戏内的
	}

	/// <summary>
	/// 当前场景UI
	/// </summary>
	public UISceneBase CurrentUIScene;


	#region LoadSceneUI 加载场景UI
	/// <summary>
	/// 加载场景UI
	/// </summary>
	/// <returns>The scene U.</returns>
	/// <param name="type">Type.</param>
	public GameObject LoadSceneUI(SceneUIType type)
	{
		GameObject obj = null;

		switch(type)
		{
		case SceneUIType.LogOn:
			obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIScene, "UI Root_LogOnScene");
			CurrentUIScene = obj.GetComponent<UISceneLoginOnCtrl>();
			break;
		case SceneUIType.Loading:
			obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIScene, "UI Root_Loading");
			CurrentUIScene = obj.GetComponent<UISceneLoadingCtrl>();
			break;
		case SceneUIType.Game:
			break;
		default:
			break;
		}

		return obj;
	}
	#endregion
}

