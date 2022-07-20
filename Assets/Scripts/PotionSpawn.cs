using System.Collections.Generic;
using UnityEngine;

public class PotionSpawn : MonoBehaviour
{
    public static PotionSpawn instance;
    [SerializeField] GameObject[] potions;
    [SerializeField] Transform potionParent;
    
    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }

    public void SetDescriptions(int[] descriptionOrder)
    {
        for(int i = 0; i < potions.Length; i++)
        {
            potions[i].GetComponent<Item>().info.SetDescription(Description.GetPotionDescription(descriptionOrder[i]));
        }
    }

    public void IdentifyPotion(int index, bool identified) => potions[index].GetComponent<Item>().info.identified = identified;

    public void SpawnPotion()
    {
        float spawnPointX = Random.Range(-6.25f, 6.20f);
        int randomPotion = Random.Range(0, 5);
        Vector3 spawnPosition = new Vector3(spawnPointX, 3, 0);
        Instantiate(potions[randomPotion], spawnPosition, Quaternion.identity, potionParent);
    }

    public List<ItemInfo> GetItemInfos()
    {
        List<ItemInfo> items = new List<ItemInfo>();
        for (int i = 0; i < potions.Length; i++)
        {
            items.Add(potions[i].GetComponent<Item>().info);
        }
        return items;
    }
}
