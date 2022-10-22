using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour
{
   private Dictionary<int , int> MineralStock = new Dictionary<int , int>();

    public delegate void MineralWasMain(int Price, int Amount, Sprite Icon);
    public static event MineralWasMain MineralMain;

    [SerializeField] private int _timeBeforSell;
    private bool _isSellBattonDown = true;
    public void GotMineral(MineralScripteblObject Mineral)
    {
        try
        {
            MineralStock[Mineral.MineralLvl] += 1;
            MineralMain(Mineral.Price, MineralStock[Mineral.MineralLvl], Mineral.MineralIcon);
        }
        catch (Exception e) 
        { 
            Debug.Log("Error");
            MineralStock.Add(Mineral.MineralLvl,1);
        }
    }

    private IEnumerator Sales—ircle()
    {       
        yield return new WaitForSeconds(_timeBeforSell);
        if (_isSellBattonDown) 
          StartCoroutine(Sales—ircle()); _isSellBattonDown = false;
        Debug.Log("Corutine work!");
    }
}
