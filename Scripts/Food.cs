using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int Reward { get { return reward; } }
    public int ID { get { return id; } }
    public Sprite Icon;

    [SerializeField] private int reward;
    [SerializeField] private int id;

    private Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();

        level.OnTrueCollectFood += Collect;
        level.OnFalseCollectFood += Collect;
    }

    private void OnDestroy()
    {
        level.OnTrueCollectFood -= Collect;
        level.OnFalseCollectFood -= Collect;
    }

    public void Collect(Food food)
    {
        Destroy(food.gameObject);
    }

}
