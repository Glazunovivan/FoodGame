using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New list foods", menuName = "Create/List")]
public class ListFoods : ScriptableObject
{
    public List<Food> foods;
}
