using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemInfo : ScriptableObject
{
    public int id;
    public Sprite sprite;
    public Description description;
    public bool identified;
    
    public void SetDescription(Description description)
    {
        this.description = description;
    }
}
