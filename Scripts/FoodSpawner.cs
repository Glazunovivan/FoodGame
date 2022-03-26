using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class FoodSpawner : MonoBehaviour
{
    public Surface Surface;
    public List<Food> Foods => foods;
    
    private List<Food> foods;
    private new Transform transform;

    private void Start()
    {
        transform = GetComponent<Transform>();
        foods = FindObjectOfType<Level>().Config.ListFoods.foods;
        StartCoroutine(SpawnFood());
    }

    private IEnumerator SpawnFood()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(1, 4));
            RandomSpawn();
        }
    }
    
    private void RandomSpawn()
    {
        int random = UnityEngine.Random.Range(0, foods.Count);
        var food = Instantiate(foods[random], transform);
    }
}
