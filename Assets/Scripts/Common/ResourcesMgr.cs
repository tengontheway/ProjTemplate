/*
    Author: 	Evil.T
    CreateDate:	2016-03-22 14:15:31
    Desc:		管理所有的资源加载(主要是Resources目录下的资源)

	优化:
	1.附带缓存，已经加载过的界面直接从缓存加载
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ResourcesMgr : Singleton<ResourcesMgr>
{
	private Dictionary<string, GameObject> dicPrefabTable;

	public ResourcesMgr()
	{
		dicPrefabTable = new Dictionary<string, GameObject>();
	}

	#region ResourceType 资源类型
	public enum ResourceType
	{
		UIScene,		// 场景UI
		UIWindow,		// 窗口
		Role,
		Effect
	}
	#endregion

	/// <summary>
	/// 加载资源
	/// </summary>
	/// <param name="type">资源类型</param>
	/// <param name="path">资源短路径</param>
	/// <param name="cache">是否缓存</param>
	public GameObject Load(ResourceType type, string path, bool cache = false)
	{
		GameObject obj = null;
		if (dicPrefabTable.ContainsKey(path)) 
		{
			obj = dicPrefabTable[path].gameObject as GameObject;
		} 
		else 
		{
			StringBuilder sbr = new StringBuilder();

			switch(type)
			{
			case ResourceType.UIScene:
				sbr.Append("UIPrefab/UIScene/");
				break;
			case ResourceType.UIWindow:
				sbr.Append("UIPrefab/UIWindow/");
				break;
			case ResourceType.Role:
				sbr.Append("RolePrefab/");
				break;
			case ResourceType.Effect:
				sbr.Append("EffectPrefab/");
				break;
			default:
				Debug.LogError("Invalid resource type:" + type);
				break;
			}
			sbr.Append(path);

			obj = Resources.Load(sbr.ToString()) as GameObject;
			if (cache)
			{
				dicPrefabTable.Add(path, obj);
			}
		}

		return GameObject.Instantiate(obj);
	}

	public override void Dispose()
	{
		base.Dispose();

		dicPrefabTable.Clear();

		// 未使用的资源释放
		Resources.UnloadUnusedAssets();
	}
}
