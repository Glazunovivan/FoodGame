using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    public UnityAction<Food> OnTrueCollectFood, OnFalseCollectFood;
    public UnityAction OnUpdateUI;
    public Config Config { get { return config; } }
    public Food CurrentFood { get { return needCollectFood.Item1; } }
    public int Reward { get { return reward; } }

    [SerializeField] 
    private Config config;

    private (Food, int) needCollectFood;
    private int currentStageCollectFood;
    private int reward;

    private void Awake()
    {
        needCollectFood = (null, 0);
    }

    private void Start()
    {
        reward = 0;
        CreateListCollectedFood(currentStageCollectFood);
    }

    private void CreateListCollectedFood(int indexNumber)
    {
        int randomCount = UnityEngine.Random.Range(config.ColFood[indexNumber].MinFood, (config.ColFood[indexNumber].MaxFood+1));
        needCollectFood = (config.ColFood[indexNumber].TypeFood, randomCount);
        OnUpdateUI?.Invoke();
    }


    private void CheckCollectFood()
    {
        if (needCollectFood.Item2 == 0)
        {
            Debug.Log("Следующая стадия");
            NextFoodCollect();
        }
    }

    private void NextFoodCollect()
    {
        currentStageCollectFood++;
        CreateListCollectedFood(currentStageCollectFood);
    }
    
    public bool IsNeededFood(Food food)
    {
        if (food.ID == CurrentFood.ID)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CollectTrueFood(Food food)
    {
        needCollectFood.Item2--;
        reward += food.Reward;

        OnTrueCollectFood?.Invoke(food);
        OnUpdateUI?.Invoke();
        CheckCollectFood();
    }
    
    public void CollectFalseFood(Food food)
    {
        reward -= food.Reward;
        OnFalseCollectFood?.Invoke(food);
        OnUpdateUI?.Invoke();
    }

    public string GetRemainingCountFood()
    {
        return needCollectFood.Item2.ToString();
    }
}
