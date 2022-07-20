using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    
    public string name;
    public string password;
    public int seed;
    public int[] descriptionOrder;
    public int[] potionCount;
    public bool[] identified;
    
    public SaveData(string name, string password)
    {
        this.name = name;
        this.password = password;
        seed = UnityEngine.Random.Range(0, 200000000);
        descriptionOrder = GetRandomArray(seed);
        potionCount = new int[5];
        identified = new bool[5];
    }

    public string ToJson() => JsonUtility.ToJson(this);

    public static string ConvertToJson(SaveData saveInfo) => JsonUtility.ToJson(saveInfo);
   
    public static SaveData ConvertFromJson(string json) => JsonUtility.FromJson<SaveData>(json); 
   
    public static int[] GetRandomArray(int seed)
    {
        System.Random random = new System.Random(seed);
        List<int> list = new List<int>()
        {
            0, 1, 2, 3, 4
        };
        int[] ans = new int[5];
        for (int i = 0; i < 5; i++)
        {
            int index = random.Next(0, list.Count);
            ans[i] = list[index];
            list.RemoveAt(index);
        }
        return ans;
    }   
}
