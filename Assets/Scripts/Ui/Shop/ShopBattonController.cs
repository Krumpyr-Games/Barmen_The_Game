using System.Collections.Generic;
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
    private int Prayse;
    public void StockUp()
    {
        int StockLvl = _stock.StockLvl + 1;       
        if (StockLvl != 2)
        {
            Prayse = _prayseSecondeLvl;
            for (int i = 0; i < StockLvl - 2; i++)
            {
                Prayse *= 2;          
            }
        }
        else
        {
            Prayse = _prayseSecondeLvl;
        }

        

        bool _enoughMoney  = _wallet.EnoughMoney(Prayse);
        if (_enoughMoney == false) 
        {             
            return; 
        }
#pragma warning disable
         _stock.UpdaiteSock();
        _wallet.MinuseManey(Prayse);

        UpdaiteBattonStockUp();
    }

    private void UpdaiteBattonStockUp()
    {
        for (int i = 0; i < _shopBattons.Length; i++)
        {
            if (_shopBattons[i].BattonKind == UpShopBatton.ShopBattonKind.StockUp)
            {              
                _shopBattons[i].SetPrayse(Prayse);               
            }
        }
    }
}
