/*
    Author:     Evil.T
    CreateDate:	2016-03-22 23:21:57
    Desc:       所有UI的基类
*/
using UnityEngine;
using System.Collections;

/// <summary>
/// 所有UI的基类
/// </summary>
public class UIBase : MonoBehaviour 
{
	void Awake()
	{
		OnAwake();
	}

	void Start()
	{
		UIButton[] btnArr = GetComponentsInChildren<UIButton>(true);
		for (int i = 0; i < btnArr.Length; i++)
		{
			UIEventListener.Get(btnArr[i].gameObject).onClick = BtnClick;
		}
		OnStart();
	}

	private void BtnClick(GameObject go)
	{
		OnBtnClick(go);
	}

	protected virtual void OnAwake() { }
	protected virtual void OnStart() { }
	protected virtual void BeforeOnDestroy() { }
	protected virtual void OnBtnClick(GameObject go) { }
}