using UnityEngine;

[CreateAssetMenu(fileName = "NewItem" , menuName = "Data/Item")]
public class ItemData : ScriptableObject
{ 
    public string nameItem;
    public Sprite sriteItem;
    public string textItem;
    public GameObject prefabItem;
    public ItemType itemType; 
}

public enum ItemType
{
    Folder,
    FileTxt,
    Image
}
