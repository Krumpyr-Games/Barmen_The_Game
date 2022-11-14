using UnityEngine;
using UnityEngine.UI;

public class UpShopBatton : MonoBehaviour
{
    [SerializeField] private Text _battonText;
    [SerializeField] private Text _prayse;
    [SerializeField] private RawImage _battonIcon;

    [SerializeField] private string _battonInfo;
    [SerializeField] private ShopBattonKind _battonKind;
    public ShopBattonKind BattonKind => _battonKind;

    public enum ShopBattonKind
    {
        StockUp,
        LakyUp,
        MineralUp
    }

    private void Start()
    {
        _battonText.text = _battonInfo;
    }

    public void SetPrayse(int Prayse)
    {
        if (Prayse <= 0)
        {
            _prayse.text = "";
            return;
        }
        _prayse.text = Prayse.ToString();
    }

}
