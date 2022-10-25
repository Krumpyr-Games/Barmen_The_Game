using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour
{
    public List<MineralScripteblObject> Minerals { get; private set; } = new List<MineralScripteblObject>();
    private Dictionary<int, int> MineralStock = new Dictionary<int, int>();


    [SerializeField] private int _timeBeforSell;
    [SerializeField] private Wallet _maney;
    
    private void Start()
    {
        StartCoroutine(Sales—ircle());
    }
    public void GotMineral(MineralScripteblObject Mineral)
    {
        try
        {
            MineralStock[Mineral.MineralLvl] += 1;           
        }
        catch (Exception) 
        { 
            Debug.Log("Error");
            Minerals.Add(Mineral);
            MineralStock.Add(Mineral.MineralLvl,1);
        }
    }

    private IEnumerator Sales—ircle()
    {       
        yield return new WaitForSeconds(_timeBeforSell);
        SellAll();
        RepitCorutine();
    }

    private void RepitCorutine()
    {
       StartCoroutine(Sales—ircle());
    }

    private void SellAll()
    {      
        for(int i = 0; i < Minerals.Count; i++)
        {
            int AmountMineral = MineralStock[Minerals[i].MineralLvl];
            _maney.PluseManey(AmountMineral * Minerals[i].Price);
            MineralStock[Minerals[i].MineralLvl] = 0;
        }       
    }

    public void SellAllUseStockInfoBatton()
    {
        StopCoroutine(Sales—ircle());
        StartCoroutine(Sales—ircle());
        SellAll();
    }
}
