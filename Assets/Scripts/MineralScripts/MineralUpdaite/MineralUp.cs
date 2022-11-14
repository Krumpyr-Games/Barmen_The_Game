using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MineralUp : MonoBehaviour
{
    [SerializeField] private MineralScripteblObject[] _minerals;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private int _stepen;
    [SerializeField] private float _procentUpPrayse;
    [SerializeField] private MineralUp _mineralUp;

    private void OnEnable()
    {
        Mineral.MineralUpdaiter += SetNewMineral;      
    }

    private void OnDisable()
    {
        Mineral.MineralUpdaiter -= SetNewMineral;
    }

    public MineralScripteblObject SetNewMineral(MineralScripteblObject mineral)
    {
       for(int i = 0 ; i < _minerals.Length; i++)
       {
            if(mineral.MineralLvl + 1 == _minerals[i].MineralLvl)
            {
                int _prayse = GetMineralUpPrayse(mineral);

                if (_prayse == 0) return mineral;
               
                _wallet.MinuseManey(_prayse);
                return _minerals[i];
            }
       }
        throw new System.Exception("Не был найден следующий уровень");
#pragma warning disable CS0162 
        return mineral;
    }

   public int GetMineralUpPrayse(MineralScripteblObject mineral)
    {
        double _prayse = 10;
        for (int i = 0; i < mineral.MineralLvl + 1; i++)
        {
            _prayse *= Math.Pow(_procentUpPrayse, _stepen);           
        }
        _prayse = Math.Round(_prayse);
        int _endPrayse = Convert.ToInt32(_prayse);
        bool _haveManey = _wallet.EnoughMoney(_endPrayse);
        if (_haveManey == false) return 0;

        return _endPrayse;
    }
}
