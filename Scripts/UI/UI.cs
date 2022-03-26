using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Level level;
    public Level Level
    {
        get
        {
            return level;
        }
    }

    [SerializeField] private FoodView foodView;
    [SerializeField] private CoinsView coinsView;

    private void Awake()
    {
        level = FindObjectOfType<Level>();
        foodView.Init(this);
        coinsView.Init(this);
    }
}
