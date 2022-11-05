using UnityEngine;

public class ShopBattonController : MonoBehaviour
{
    [Header("Механическая часть")]
    [SerializeField] private Stock _stock;
    [SerializeField] private Wallet _wallet;

    [Header("Настройки")]
    [Header("Настройки скинов")]
    [SerializeField] private UpShopBatton[] _shopBattons;
    [Header("Настройки баланса")]
    [SerializeField] private int _prayseSecondeLvl;

    public void StockUp()
    {
        int StockLvl = _stock.StockLvl + 1;

        int _prayse = ReturnPrayse(StockLvl);

        if (_wallet.EnoughMoney(_prayse) == false) return;

#pragma warning disable
        _stock.UpdaiteSock();
        _wallet.MinuseManey(_prayse);

        UpdaiteBattonStockUp(UpShopBatton.ShopBattonKind.StockUp ,
            ReturnPrayseForUi(StockLvl + 1));
    }

    private void UpdaiteBattonStockUp(UpShopBatton.ShopBattonKind shopBattonKind , int prayse)
    {
        for (int i = 0; i < _shopBattons.Length; i++)
        {
            if (_shopBattons[i].BattonKind == shopBattonKind)
            {              
                _shopBattons[i].SetPrayse(prayse);               
            }
        }
    }

    private int ReturnPrayse(int StockLvl)
    {
        if (StockLvl != 2)
        {
           int _prayse = _prayseSecondeLvl;
            for (int i = 0; i < StockLvl - 2; i++)
            {
                _prayse *= 2;
            }
            return _prayse;
        }
        else
        {
            return _prayseSecondeLvl;
        }
    }

    private int ReturnPrayseForUi(int StockLvl)
    {
        if (StockLvl != 2)
        {
            int _prayse = _prayseSecondeLvl;
            for (int i = 0; i < StockLvl - 2; i++)
            {
                _prayse *= 2;
            }
            return _prayse;
        }
        else
        {
            return _prayseSecondeLvl * 2;
        }
    }
}
