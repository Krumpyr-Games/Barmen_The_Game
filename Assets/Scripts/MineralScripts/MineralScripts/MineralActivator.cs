using SavingSystems.Interfaces;
using SavingSystems.Systems;
using System.IO;
using UnityEngine;

public class MineralActivator : MonoBehaviour
{
    private const string _path = "/MineralData.json";

    [SerializeField] private Mineral[] _minerals;
    [SerializeField] private MineralScripteblObject[] _mineralsScriptbObj;
    [SerializeField] private MineralUp MineralUp;

    private IDataSaver<int> SavingSystems;

    private int[] MinerlsLvlLoad;
    private int[] MineralsLvlSave;

    private int _mineralNow = 0;
    private bool _firstStart = false;
    private void Awake()
    {
        SavingSystems = new SavingSystem<int>();
        if (!File.Exists(Application.dataPath + _path)) return;

        MineralsLvlSave = SavingSystems.LoadObjects(Application.dataPath + _path);

        if (MineralsLvlSave.Length != _minerals.Length) { throw new System.IndexOutOfRangeException(
            "System need litel more mineral up"); return; }

        for (int i = 0; i < _minerals.Length; i++)
        {
            _minerals[i].SetSeifMineral(_mineralsScriptbObj[MineralsLvlSave[i]]);
            _minerals[i]._text.text = MineralUp.GetMineralUpPrayseWithutChekingManey(_minerals[i].MineralTaype.MineralLvl).ToString();
        }
    }

    private void OnApplicationQuit()
    {       
        MinerlsLvlLoad = new int[_minerals.Length];
        for (int i = 0; i < _minerals.Length; i++)
        {
            MinerlsLvlLoad[i] = _minerals[i].MineralTaype.MineralLvl;
        }

        SavingSystems.SaveObjects(MinerlsLvlLoad, Application.dataPath + _path);
    }

    public void ActiveitNextMineral()
    {
        if (!_firstStart)
        {
            _firstStart = true;
            _minerals[_mineralNow].gameObject.SetActive(true);
            return;
        }
        _minerals[_mineralNow + 1].gameObject.SetActive(true);
        _mineralNow += 1;
    }
}
