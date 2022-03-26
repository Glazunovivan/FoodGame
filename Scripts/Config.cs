using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New config", menuName = "Config")]
public class Config : ScriptableObject
{
    public int Speed;
    public List<CollectFood> ColFood;
    public ListFoods ListFoods;

    [System.Serializable]
    public class CollectFood
    {
        public int MinFood;
        public int MaxFood;
        public Food TypeFood;
    }
}
