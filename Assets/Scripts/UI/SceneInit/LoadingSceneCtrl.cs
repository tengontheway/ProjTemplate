/*
    Author:     Evil.T
    CreateDate:	2016-03-24 20:39:56
    Desc:       你眼瞎啊,不写注释
*/
using UnityEngine;
using System.Collections;

public class LoadingSceneCtrl : MonoBehaviour {

	private AsyncOperation asyncOP;
	private bool isDelayed = false;

	// Use this for initialization
	void Awake () {
		
	}

	void Start()
	{
		LayerUIMgr.Instance.Reset();

		Invoke("DelayInvoke", 2.0f);

		StartCoroutine(LoadingScene());
	}

	IEnumerator LoadingScene()
	{
		string scene_name = "";

		switch(SceneMgr.Instance.CurrentSceneType)
		{
		case SceneType.LogOn:
			scene_name = "Scene_LogOn";
			break;
		case SceneType.Game:
			scene_name = "Scene_Game";
			break;
		}

		asyncOP = Application.LoadLevelAsync(scene_name);
		asyncOP.allowSceneActivation = false;

		yield return asyncOP;
	}

	void Update()
	{
		if (asyncOP.progress >= 0.9f && isDelayed) {
			asyncOP.allowSceneActivation = true;
		}
	}


	void DelayInvoke()
	{
		isDelayed = true;
	}
}
