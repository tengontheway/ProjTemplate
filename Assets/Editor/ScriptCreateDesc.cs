/*
 	所有新建文件都会自动替换头文件描述

	步骤：
	1.修改UNITY自带的脚本模板文件 Unity.app/Contents/Resources/ScriptTemplates/81-C# Script-NewBehaviourScript.cs.txt
	2.替换内容:

	/*
	 	Desc:		你眼瞎啊
	  	Author:		#AuthorName#
		CreateDate:	#CreateDate#
	* /
	using UnityEngine;
	using System.Collections;

	public class #SCRIPTNAME# : MonoBehaviour {

	    // Use this for initialization
	    void Start () {

	    }

	    // Update is called once per frame
	    void Update () {

	    }

	}
 */
using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class ScriptCreateDesc : UnityEditor.AssetModificationProcessor 
{
	private static void OnWillCreateAsset(string path)
	{
		path = path.Replace(".meta","");
		if (path.EndsWith(".cs"))
		{
			string strContent = File.ReadAllText(path);
			strContent = strContent.Replace("#AuthorName#", "Evil.T").Replace("#CreateDate#", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			File.WriteAllText(path, strContent);
			AssetDatabase.Refresh();
		}
	}
}