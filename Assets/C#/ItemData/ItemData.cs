using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem" , menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    public string id { get; private set; } = "";
    public string nameItem;
    public Sprite sriteItem;
    public string textItem;
    public GameObject prefabItem;
    public ItemType itemType; 
    public void SetNewId()
    {
        if(id=="")
        id = Guid.NewGuid().ToString();
    }
}

public enum ItemType
{
    Folder,
    FileTxt,
    Image
}
