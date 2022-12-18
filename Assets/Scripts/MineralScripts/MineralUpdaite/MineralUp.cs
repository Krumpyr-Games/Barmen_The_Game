using UnityEngine;


public class MineralUp : MonoBehaviour
{
    [Header("Required data")]
    [SerializeField] private MineralScripteblObject[] _minerals;

    [Header("Links to resources")]
    [SerializeField] private MineralUp _mineralUp;
    [SerializeField] private Stock _stock;
    [SerializeField] private WarrningButtoAnim _warninButtong;

    [Header("Under the account")]
    [SerializeField] private Wallet _wallet;

    [Header("Required data and links for MineralTextPrayse")]
    [SerializeField] private Mineral[] _mineralTexts;


    private void OnEnable()
    {
         Mineral.MineralUpdaiter += SetNewMineral;
        Initialization();
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
                int _prayse = GetMineralUpPrayse(mineral.MineralTaype.MineralLvl);

                if (_prayse == 0) return mineral.MineralTaype;            
                _wallet.MinuseManey(_prayse); 
                mineral._text.text = GetMineralUpPrayseWithutChekingManey(mineral.MineralTaype.MineralLvl + 1).ToString();
                return _minerals[i];
            }
       }
        if (_warninButtong.EndAnim)
        {
            StartCoroutine(_warninButtong.WarningButtonPlayAnim("Mineral have max lvl"));
        }
            _warninButtong.SetWarningButtonActivity();
#pragma warning disable CS0162
        return mineral.MineralTaype;
    }

   public int GetMineralUpPrayse(int mineral)
   {
        int maney = (10 * (mineral + 1)) * 5;
        if (!_wallet.EnoughMoney(maney)) return 0;
        return maney;
   }

    public int GetMineralUpPrayseWithutChekingManey(int mineral)
    {
        return (10 * (mineral + 1)) * 5;
    }

    private void Initialization()
    {
        for (int i = 0; i < _mineralTexts.Length; i++)
        {
            if (_mineralTexts[i].gameObject.activeSelf)
            {
              _mineralTexts[i]._text.text = GetMineralUpPrayseWithutChekingManey(_mineralTexts[i].MineralTaype.MineralLvl).ToString(); 
            }
        }
    }
        
    public void SetActivitMineralTexts(bool Activiti)
    {
        for (int i = 0; i < _mineralTexts.Length; i++)
        {
            if (_mineralTexts[i].gameObject.activeSelf) _mineralTexts[i]._text.gameObject.SetActive(Activiti);
        }
    }
}
