using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour
{
    private Dictionary<int, int> MineralStock = new Dictionary<int, int>();


    [SerializeField] private int _timeBeforSell;
    [SerializeField] private bool _isSellBattonDown = true;

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
        {
            SellAll();
        }
        else if(_isSellBattonDown == false)
        {
         Debug.Log("Corutine work!");
        }
         RepitCorutine();
    }

    private void RepitCorutine()
    {
       StartCoroutine(Sales—ircle());
    }

    private void SellAll()
    {
        Debug.Log("Corutine return!"); 
        _isSellBattonDown = false;
        return;
    }
}
