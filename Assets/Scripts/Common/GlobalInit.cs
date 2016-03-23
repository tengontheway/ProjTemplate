/*
    Author:     Evil.T
    CreateDate:	2016-03-23 17:35:31
    Desc:      	全局初始化
*/
using UnityEngine;
using System.Collections;

public class GlobalInit : MonoBehaviour 
{
	public static GlobalInit Instance;

	/// <summary>
	/// UI动画曲线
	/// </summary>
	[SerializeField]
	public AnimationCurve UIAnimationCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));
	
	void Awake()
	{
		Instance = this;
		DontDestroyOnLoad(this);
	}

}
