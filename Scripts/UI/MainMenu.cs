using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string gameFood = "GameFood";
    private string shop = "Shop";

    public void PlayGame()
    {
        SceneManager.LoadScene(gameFood);
    }

    public void OpenShop()
    {
        SceneManager.LoadScene(shop);
    }
}
