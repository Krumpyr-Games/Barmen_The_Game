using UnityEngine;
using UnityEngine.UI;

public class MineralInfoUiTest : MonoBehaviour
{
    public Text _price;
    public Text _amount;
    public SpriteRenderer _icon;

    private void OnEnable()
    {
        Stock.MineralMain += SetMineralButtonInfo;
    }

    private void OnDisable()
    {
        Stock.MineralMain -= SetMineralButtonInfo;
    }

    public void SetMineralButtonInfo(int Price , int Amount , Sprite Icon )
    {
        _price.text = Price.ToString();
        _amount.text = Amount.ToString();
        _icon.sprite = Icon;
    }
}

