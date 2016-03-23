/*
    Desc:       登录场景控制器
    Author:     Evil.T
    CreateDate:	2016-03-22 17:47:44
*/
using UnityEngine;
using System.Collections;

public class LogOnSceneInit : MonoBehaviour 
{
	// Use this for initialization
	void Awake () 
	{
		SceneUIMgr.Instance.LoadSceneUI(SceneUIMgr.SceneUIType.LogOn);
	}

}
