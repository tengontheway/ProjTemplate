/*
    Author:     Evil.T
    CreateDate:	2016-03-23 15:49:51
    Desc:       所有的枚举
*/


/// <summary>
/// 场景类型 
/// </summary>
public enum SceneType
{
	LogOn,
	Game
}

/// <summary>
/// 窗口的类型
/// </summary>
public enum WindowUIType
{
	None,
	Reg,			// 注册
	LogOn,			// 登录
}

/// <summary>
/// UI容器类型
/// </summary>
public enum WindowUIContainerType
{
	TopLeft,
	TopRight,
	BottomLeft,
	BottomRight,
	Center
}

/// <summary>
/// 窗口显示方式
/// </summary>
public enum WindowShowStyle
{
	Normal,
	CenterToBig,
	FromTop,
	FromDown,
	FromLeft,
	FromRight,
}