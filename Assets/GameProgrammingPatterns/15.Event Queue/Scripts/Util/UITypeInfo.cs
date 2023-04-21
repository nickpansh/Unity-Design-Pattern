using System;

/// <summary>
/// UI类型，包括该UI的prefab路径和所对应的脚本类型。
/// </summary>
public class UITypeInfo
{
    /// <summary>
    /// prefab的资源路径。
    /// </summary>
    public string prefabPath { get; private set; }
    /// <summary>
    /// 对应的脚本类型。
    /// </summary>
    public Type scriptType { get; private set; }

    /// <summary>
    /// 构造函数。
    /// </summary>
    /// <param name="prefabPath">prefab的资源路径。</param>
    /// <param name="scriptType">对应的脚本类型。</param>
    public UITypeInfo(string prefabPath, Type scriptType = null)
    {
        this.prefabPath = prefabPath;
        this.scriptType = scriptType;
    }

    /// <summary>
    /// 重写ToString()方法，返回脚本类型的名称。
    /// </summary>
    /// <returns>脚本类型的名称。</returns>
    public override string ToString()
    {
        return scriptType.Name;
    }
}