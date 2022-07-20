using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    int count;
    ItemInfo info;
    [SerializeField] Image image;
    [SerializeField] TMP_Text countText;

    public void Clear()
    {
        image.color = Color.clear;
        countText.text = "";
        count = 0;
        info = null;
    }
    
    public void AddItem(ItemInfo info)
    {
        if (this.info != null)
        {
            countText.text = $"{++count}";
        }
        else
        {
            this.info = info;
            count = 1;
            image.sprite = info.sprite;
            countText.text = $"{count}";
            image.color = Color.white;
        }
    }
    
    public void PopUpItem()
    {
        if (info == null) return;
        Inventory.instance.ItemPopUp(info);
    }
}
