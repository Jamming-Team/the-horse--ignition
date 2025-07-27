using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/ItemData")]
public class ItemData : ScriptableObject
{
    /// <summary>
    /// Size in width and height of the item.
    /// </summary>
    [Header("Main")]
    public SizeInt size = new();

    /// <summary>
    /// Item icon.
    /// </summary>
    [Header("Visual")]
    public Sprite icon;

    /// <summary>
    /// Background color of the item icon.
    /// </summary>
    public Color backgroundColor;
}

[System.Serializable]
public class SizeInt {
    public int width;
    public int height;

    public SizeInt(int width = 0, int height = 0) {
        this.width = width;
        this.height = height;
    }
}