using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemInfo info;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Inventory.instance.CatchItem(info);
            Destroy(gameObject);
            PotionSpawn.instance.SpawnPotion();
        }    
    }
}
