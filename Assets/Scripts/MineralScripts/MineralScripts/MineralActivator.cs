using SavingSystems.Interfaces;
using SavingSystems.Systems;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MineralActivator : MonoBehaviour
{
    private const string _pathToMineral = "/MineralData.json";
    private const string _pathToMineralActivity = "/MineralActivityData.json";

    [SerializeField] private Mineral[] _minerals;
    [SerializeField] private MineralScripteblObject[] _mineralsScriptbObj;
    [SerializeField] private MineralUp MineralUp;
    [SerializeField] private WarrningButtoAnim _warningAnim;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Text text;

    private IDataSaver<int> SavingSystems;
    private IDataSaver<bool> SavingSystemsScriptb;

    private int[] MinerlsLvlLoad;
    private int[] MineralsLvlSave;
    private bool[] MineralActivity;

    private int _mineralNow = 0;
    private bool _firstStart = false;
    private int _index = 1 ;
    private void Awake()
    {
        LoadSeiv();
        int prayse = (50 * _index) * 2;
        text.text = prayse.ToString();
    }

    private void OnApplicationQuit()
    {
        SaveObj();
    }

    public void ActiveitNextMineral()
    {
        if (!_firstStart)
        {
            _firstStart = true;
            _minerals[_mineralNow].gameObject.SetActive(true);
            return;
        }
        int prayse = GetPrayse();

        if (!_wallet.EnoughMoney(prayse)){ _warningAnim.WarningButtonPlayAnim("You havn`t money");return;}

        if (_mineralNow + 1 >= _minerals.Length) { _warningAnim.WarningButtonPlayAnim("You buy all minerals"); return; }
        _wallet.MinuseManey(prayse);
        _mineralNow += 1;
        _minerals[_mineralNow].gameObject.SetActive(true);
        text.text = GetPrayseForUi().ToString();
    }

    private int GetPrayse()
    {
        int prayse = (50 * _index) * 2;
        _index++;
        return prayse;
    }

    private int GetPrayseForUi()
    {
        int prayse = (50 * _index + 1) * 2;
        return prayse;
    }

    public void LoadSeiv()
    {
        SavingSystems = new JsonSavingSystem<int>();
        SavingSystemsScriptb = new JsonSavingSystem<bool>();

        if (!File.Exists(Application.dataPath + _pathToMineral)) return;
        if (!File.Exists(Application.dataPath + _pathToMineralActivity)) return;

        MineralsLvlSave = SavingSystems.LoadObjects(Application.dataPath + _pathToMineral);

        if (MineralsLvlSave.Length != _minerals.Length)
        {
            throw new System.IndexOutOfRangeException(
            "System need litel more mineral up"); return;
        }

        for (int i = 0; i < _minerals.Length; i++)
        {
            _minerals[i].SetSeifMineral(_mineralsScriptbObj[MineralsLvlSave[i]]);
            _minerals[i]._text.text = MineralUp.GetMineralUpPrayseWithutChekingManey(_minerals[i].MineralTaype.MineralLvl).ToString();
        }

        MineralActivity = SavingSystemsScriptb.LoadObjects(Application.dataPath + _pathToMineralActivity);

        for (int i = 0; i < _minerals.Length; i++)
        {
            _minerals[i].gameObject.SetActive(MineralActivity[i]);
        }
    }

    public void SaveObj()
    {
        MinerlsLvlLoad = new int[_minerals.Length];
        for (int i = 0; i < _minerals.Length; i++)
        {
            MinerlsLvlLoad[i] = _minerals[i].MineralTaype.MineralLvl;
        }

        MineralActivity = new bool[_minerals.Length];
        for (int i = 0; i < _minerals.Length; i++)
        {
            MineralActivity[i] = _minerals[i].gameObject.activeSelf;
        }

        SavingSystems.SaveObjects(MinerlsLvlLoad, Application.dataPath + _pathToMineral);

        SavingSystemsScriptb.SaveObjects(MineralActivity , Application.dataPath + _pathToMineralActivity);
    }
}
