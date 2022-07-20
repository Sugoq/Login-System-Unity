using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInspect : MonoBehaviour
{
    public static ItemInspect instance;
    RectTransform rectTransform;
    [SerializeField] TMP_Text title;
    [SerializeField] TMP_Text description;
    [SerializeField] Image image;
    private ItemInfo itemInfo;

    private void Awake()
    {
        instance = this;    
    }

    private void OnDestroy()
    {
        instance = null;
    }
    
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        ClosePopUp();
    }

    public void SetPopUpInfo(ItemInfo info)
    {
        itemInfo = info;
        image.sprite = info.sprite;
        title.text = info.identified ? info.description.title : info.name;
        description.text = info.identified ? info.description.description : "This potion is not identified.";
        rectTransform.localScale = Vector3.one;
    }
    
    public void ClosePopUp() => rectTransform.localScale = Vector3.zero;

    public void DrinkPotion()
    {
        Debug.Log(itemInfo.description.description);
        Inventory.instance.UseItem(itemInfo);
        ClosePopUp();
    }   
}
