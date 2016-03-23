//
//  Desc:		所有单例的基类
//  Author: 	Unknown
//  CreateDate:	2016-03-22 14:08:20
//
using UnityEngine;
using System.Collections;
using System;

public class Singleton<T> :IDisposable where T : class, new()
{
	private static T _instance;
	private static readonly object syslock = new object();

	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				lock (syslock)
				{
					if (_instance == null)
					{
						_instance = new T();
					}
				}
			}
			return _instance;
		}
	}

	public virtual void Dispose()
	{
	}
}
