using UnityEngine;
using UnityEngine.UI;

public class CoinsView : MonoBehaviour
{
    [SerializeField] private Text count;
    [SerializeField] private Text shadow;

    private UI ui;

    private void UpdateUI()
    {
        count.text = ui.Level.Reward.ToString();
        shadow.text = count.text;
    }
    
    private void OnDestroy()
    {
        if (ui != null)
        {
            this.ui.Level.OnUpdateUI -= UpdateUI;
        }
    }
    
    public void Init(UI ui)
    {
        this.ui = ui;
        this.ui.Level.OnUpdateUI += UpdateUI;
    }
}
