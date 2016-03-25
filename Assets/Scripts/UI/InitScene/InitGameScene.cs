/*
    Author:     Evil.T
    CreateDate:	2016-03-25 16:04:43
    Desc:       你眼瞎啊,不写注释
*/
using UnityEngine;
using System.Collections;

public class InitGameScene : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		UIRootMgr.Instance.LoadUIRoot(UIRootType.Game);
	}

}
