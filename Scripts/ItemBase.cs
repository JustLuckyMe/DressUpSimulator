using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemBase : ScriptableObject
{
    public string ItemName;
    public ItemType itemType;
}
