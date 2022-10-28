using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour
{
    public delegate void MineralAmountUpdait(MineralScripteblObject mineral, int amount);
    public static event MineralAmountUpdait UpdaitAmount;

    public delegate void ActiveitNewBatton(MineralScripteblObject mineral);
    public static event ActiveitNewBatton NewBattonActiveit;

    public delegate void ResetAmount();
    public static event ResetAmount ResertAmounts;

    public List<MineralScripteblObject> Minerals { get; private set; } = new List<MineralScripteblObject>();
    public Dictionary<int, int> MineralStock { get; private set; } = new Dictionary<int, int>()
    {
    };


    [SerializeField] private int _timeBeforSell;
    [SerializeField] private Wallet _maney;

    private void Start()
    {
        StartCoroutine(SalesСircle());
    }
    public void GotMineral(MineralScripteblObject Mineral)
    {
        try
        {
            MineralStock[Mineral.MineralLvl] += 1;
            UpdaitAmount(Mineral , MineralStock[Mineral.MineralLvl]);
        }
        catch (Exception)
        {
            Debug.Log("Error");
            Minerals.Add(Mineral);
            MineralStock.Add(Mineral.MineralLvl,1);
            NewBattonActiveit(Mineral);
        }
    }

    private IEnumerator SalesСircle()
    {
       // Debug.Log("до");
        yield return new WaitForSeconds(_timeBeforSell);
       // Debug.Log("после");
        SellAll();
        RepitCorutine();
    }

    private void RepitCorutine()
    {
       StartCoroutine(SalesСircle());
    }

    private void SellAll()
    {
        for (int i = 0; i < Minerals.Count; i++)
        {       
            int AmountMineral = MineralStock[Minerals[i].MineralLvl];
            _maney.PluseManey(AmountMineral * Minerals[i].Price);
            MineralStock[Minerals[i].MineralLvl] = 0;
            UpdaitAmount(Minerals[i] , AmountMineral);
        }
    }

    public void SellAllUseStockInfoBatton()
    {
        StopCoroutine(SalesСircle());
        StartCoroutine(SalesСircle());
        SellAll();
    }
}
