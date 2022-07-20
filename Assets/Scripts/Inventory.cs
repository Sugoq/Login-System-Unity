using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public SaveData saveData;
    public static Inventory instance;
    RectTransform inventoryRectTransform;
    [SerializeField] RectTransform popUpRectTransform;
    [SerializeField] Image popUpImage;
    bool isOpen;
    public List<Slot> slots = new List<Slot>();
    [Tooltip("Dictionary where the Key is the ID of an Item and the value is the Items quantity")]
    Dictionary<int, int> items = new Dictionary<int, int>();

    // Start is called before the first frame update
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
        inventoryRectTransform = GetComponent<RectTransform>();
        LoadInventory();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory(!isOpen);  
        }           
    }
    
    public void RestartGame()
    {
        SaveData newSaveData = new SaveData(saveData.name, saveData.password);
        Server.instance.Save(newSaveData);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private void LoadInventory()
    {
        saveData = Server.instance.CurrentSaveData;
#if UNITY_EDITOR
        if (saveData == null)
        {
            saveData = new SaveData("satori", "1234");
        }
#endif
        for(int i = 0; i < saveData.potionCount.Length; i++)
        {
            items[i] = saveData.potionCount[i];
            PotionSpawn.instance.IdentifyPotion(i, saveData.identified[i]);
        }
        PotionSpawn.instance.SetDescriptions(saveData.descriptionOrder);
        UpdateInventory();
    }

    private void UpdateInventory()
    {
        foreach (Slot slot in slots) slot.Clear();
        List<ItemInfo> itemInfos = PotionSpawn.instance.GetItemInfos();
        for (int i = 0; i < saveData.potionCount.Length; i++)
        {
            for (int j = 0; j < saveData.potionCount[i]; j++)
            {
                AddItem(itemInfos[i]);
            }
        }
    }

    public void CatchItem(ItemInfo info)
    {
        saveData.potionCount[info.id]++;
        Server.instance.Save(saveData);
        AddItem(info);
    }
    
    private void AddItem(ItemInfo info)
    {
        if (items.ContainsKey(info.id))
        {
            slots[info.id].AddItem(info);
            items[info.id]++;
        }
        else
        {
            items[info.id] = 1;
            slots[info.id].AddItem(info);
        }
    }

    public void UseItem(ItemInfo info)
    {
        saveData.potionCount[info.id]--;
        saveData.identified[info.id] = true;
        PotionSpawn.instance.IdentifyPotion(info.id, true);
        Server.instance.Save(saveData);
        UpdateInventory();
    }
    
    public void ShowInventory(bool show)
    {
        isOpen = show;
        inventoryRectTransform.localScale = isOpen ? Vector3.one : Vector3.zero;
        if (!isOpen)
        {
            popUpRectTransform.localScale = Vector3.zero;
        }       
    }

    public void ItemPopUp(ItemInfo info)
    {
        ItemInspect.instance.SetPopUpInfo(info);            
    }

    public void ClosePopUp() => popUpRectTransform.localScale = Vector3.zero;

    public void QuitGame() => SceneManager.LoadScene("LoginScene");
}
