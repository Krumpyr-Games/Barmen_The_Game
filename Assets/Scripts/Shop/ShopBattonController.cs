using UnityEngine;

public class ShopBattonController : MonoBehaviour
{
    [Header("Механическая часть")]
    [SerializeField] private Stock _stock;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Player _player;
    [SerializeField] private WarrningButtoAnim _buttoAnim;

    [Header("Настройки")]
    [Header("Настройки скинов")]
    [SerializeField] private UpShopBatton[] _shopBattons;
    [Header("Настройки баланса")]
    [SerializeField] private int _prayseSecondeLvl;
    [SerializeField] private int _maxStockLvl;

    
    public void StockUp()
    {
        if (_stock.StockLvl + 1 > _maxStockLvl) { _buttoAnim.WarningButtonPlayAnim("Stock have max lvl"); return; }
        int StockLvl = _stock.StockLvl + 1;

        int _prayse = ReturnPrayseForUi(StockLvl);

        if (_wallet.EnoughMoney(_prayse) == false) return;

#pragma warning disable
        _stock.UpdaiteSock();
        _wallet.MinuseManey(_prayse);

        UpdaiteBattonUp(UpShopBatton.ShopBattonKind.StockUp ,
            ReturnPrayseForUi(StockLvl + 1));
    }

    public void MineralUp()
    {
        _player.SetBehviorUpMineral();
    }

    private void UpdaiteBattonUp(UpShopBatton.ShopBattonKind shopBattonKind , int prayse)
    {
        for (int i = 0; i < _shopBattons.Length; i++)
        {
            if (_shopBattons[i].BattonKind == shopBattonKind)
            {              
                _shopBattons[i].SetPrayse(prayse);               
            }
        }
    }

    public int ReturnPrayseForUi(int StockLvl)
    {
        if (StockLvl != 2)
        {
            int _prayse = _prayseSecondeLvl;
            for (int i = 0; i < StockLvl - 1; i++)
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

    public void UpdaiteStockUi(int stokLvl)
    {
        UpdaiteBattonUp(UpShopBatton.ShopBattonKind.StockUp,
          ReturnPrayseForUi(stokLvl + 1));
    }
}
