using System;
using System.Collections;
using UnityEngine;

public class MineralUp : MonoBehaviour
{
    [Header("Required data")]
    [SerializeField] private MineralScripteblObject[] _minerals;

    [Header("Links to resources")]
    [SerializeField] private MineralUp _mineralUp;
    [SerializeField] private Stock _stock;
    [SerializeField] private WarningMaxMineralLvlAnim _warningMaxMineralLvlAnim;

    [Header("MineralUp Settings")]
    
    [SerializeField] private int _timeBeforDisActiveit;
    [Header("Under the account")]
    [SerializeField] private Wallet _wallet;
    [SerializeField] private int _stepen;
    [SerializeField] private float _procentUpPrayse;

    [Header("Required data and links for MineralTextPrayse")]
    [SerializeField] private Mineral[] _mineralTexts;
    [SerializeField] private int _startPrayse;
    public MineralTextPrayseController _mineralTextController;

  

    private void OnEnable()
    {
        _mineralTextController = new MineralTextPrayseController(_mineralTexts, _startPrayse);
        _mineralTextController.InitializeitMineralTextPrayse();

         Mineral.MineralUpdaiter += SetNewMineral;      
    }

    private void OnDisable()
    {
        Mineral.MineralUpdaiter -= SetNewMineral;
    }

    public MineralScripteblObject SetNewMineral(Mineral mineral)
    {
       for(int i = 0 ; i < _minerals.Length; i++)
       {
            if(mineral.MineralTaype.MineralLvl + 1 == _minerals[i].MineralLvl)
            {
                int _prayse = GetMineralUpPrayse(mineral.MineralTaype);

                if (_prayse == 0) return mineral.MineralTaype;            
                _wallet.MinuseManey(_prayse); 
                mineral._text.text = _prayse.ToString();
                return _minerals[i];
            }
       }
        if (!_warningMaxMineralLvlAnim._palayAnimation)
        {
            StartCoroutine(_warningMaxMineralLvlAnim.MaximumLevelWarningPanelLaife(_timeBeforDisActiveit));
            _warningMaxMineralLvlAnim.AnimationChange();
        }
#pragma warning disable CS0162
        return mineral.MineralTaype;
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
