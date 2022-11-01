using System;
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
    [SerializeField] private int maxMinerals;
    [SerializeField] private int _timeBeforSell;
    [SerializeField] private Wallet _maney;

    private int mineralsColl;
    private float TheRestOfTime;

    private void Start()
    {
        TheRestOfTime = _timeBeforSell;
        arrayIterationMineral();
    }

    private void Update()
    {        
        TheRestOfTime -= Time.deltaTime;
        if (TheRestOfTime < 0) 
        {
            SellAll();
            //SellAll();
            TheRestOfTime = _timeBeforSell; 
        }    
    }

    public void GotMineral(MineralScripteblObject Mineral)
    {
        try
        {
            if (mineralsColl + 1 > maxMinerals)
            {
                print("нету места");
                return;
            }
            else
            {
                mineralsColl += 1;
                MineralStock[Mineral.MineralLvl] += 1;
                UpdaitAmount(Mineral, MineralStock[Mineral.MineralLvl]);
            }
        }
        catch (Exception)
        {
            Minerals.Add(Mineral);
            MineralStock.Add(Mineral.MineralLvl,1);
            NewBattonActiveit(Mineral);
        }
    }

    private void arrayIterationMineral()
    {
        for (int i = 0; i < Minerals.Count; i++)
        {
            mineralsColl = MineralStock[Minerals[i].MineralLvl];
        }
    }

    private void SellAll()
    {
        for (int i = 0; i < Minerals.Count; i++)
        {
            int AmountMineral = MineralStock[Minerals[i].MineralLvl];
            _maney.PluseManey(AmountMineral * Minerals[i].Price);
            MineralStock[Minerals[i].MineralLvl] = 0;
            UpdaitAmount(Minerals[i] , AmountMineral);
            UpdaitAmount(Minerals[i], AmountMineral);
        }
    }

    public void SellAllUseStockInfoBatton()
    {
        TheRestOfTime = _timeBeforSell;
        SellAll();
    }
}
