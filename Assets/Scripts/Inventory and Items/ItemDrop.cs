using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemDrop : MonoBehaviour
{
    
    [SerializeField] private int amountOfDrop;
    [SerializeField] private ItemData[] possibleDrop;
    private List<ItemData> dropList = new List<ItemData>();
    
    
    [SerializeField] private GameObject dropPrefab;

    public virtual void GenerateDrop()
    {
        for (int i = 0; i < possibleDrop.Length; i++)
        {
            if(Random.Range(0, 100) <= possibleDrop[i].dropChance)
                dropList.Add(possibleDrop[i]);
        }

        for (int i = 0; i < amountOfDrop; i++)
        {
            ItemData randomItem = dropList[Random.Range(0, dropList.Count - 1)];
            
            dropList.Remove(randomItem);
            DropItem(randomItem);
        }
    }
    
    
    protected void DropItem(ItemData itemData)
    {
        GameObject newDrop = Instantiate(dropPrefab, transform.position, Quaternion.identity);
        
        Vector2 randomVelocity = new Vector2(Random.Range(-5, 5), Random.Range(5, 5));
        
        // 爆装备
        newDrop.GetComponent<ItemObject>().SetupItem(itemData, randomVelocity);
    }
}
