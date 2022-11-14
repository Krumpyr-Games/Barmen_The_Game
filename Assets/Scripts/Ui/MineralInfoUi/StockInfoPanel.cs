using UnityEngine;
using UnityEngine.UI;

public class StockInfoPanel : MonoBehaviour
{
    [SerializeField] private MineralScripteblObject _mineral;
    public MineralScripteblObject Mineral => _mineral;

    [SerializeField] private Text _amount;
    [SerializeField] private Text _prayse;
    [SerializeField] private Sprite _icon;

    public void Initialization()
    {
        _prayse.text = _mineral.Price.ToString();
        _icon = _mineral.MineralIcon;
    }

    public void UpdaiteAmount(int amount)
    {
        if (amount < 0) return;
        _amount.text = amount.ToString();
    }
}
