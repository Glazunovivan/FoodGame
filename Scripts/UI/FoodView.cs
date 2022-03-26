using UnityEngine;
using UnityEngine.UI;

public class FoodView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text countRemainedMain;
    [SerializeField] private Text countRemainedShadow;

    private UI ui;


    private void OnDestroy()
    {
        if (ui != null)
        {
            this.ui.Level.OnUpdateUI -= UpdateUI;
        }
    }

    private void UpdateUI()
    {
        icon.sprite = ui.Level.CurrentFood.Icon;
        countRemainedMain.text = $"{ui.Level.GetRemainingCountFood()}";
        countRemainedShadow.text = countRemainedMain.text;
    }

    public void Init(UI ui)
    {
        this.ui = ui;
        this.ui.Level.OnUpdateUI += UpdateUI;
    }
}
