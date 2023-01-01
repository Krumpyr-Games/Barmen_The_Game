using UnityEngine;

public class SellAllBatton : MonoBehaviour
{
    [SerializeField] private Stock _stock;

    public void SellAllUseBatton()
    {
        _stock.SellAllUseStockInfoBatton();
    }
}
