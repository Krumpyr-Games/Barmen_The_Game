using SavingSystems.Interfaces;
using SavingSystems.Systems;
using System.IO;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private ManeyUi _maneyUi;
    private const string _path = "ManeyDataFile.json";
    private IDataSaver<int> _dataProvider;

    public int Maney { get; private set; } = 0;

    private void Start()
    {
        _dataProvider = new SavingSystem<int>();
        if (!File.Exists(Application.persistentDataPath + _path)) return;

        Maney = _dataProvider.LoadObject(Application.persistentDataPath + _path);
        _maneyUi.SetNewManeyUi(Maney);
    }

    private void OnApplicationQuit()
    {
        Debug.Log(Application.persistentDataPath + _path);
        _dataProvider.SaveObject(Maney, Application.persistentDataPath + _path);
    }

    public bool EnoughMoney(int MinuseManey)
    {
        if (Maney - MinuseManey > 0) return true;
        return false;
    }

    public void MinuseManey(int MinseManey)
    {
        if (Maney <= 0) return;
        Maney -= MinseManey;
        _maneyUi.SetNewManeyUi(Maney);
    }

    public void PluseManey(int PluseManey)
    {
        if (PluseManey <= 0) return;
        Maney += PluseManey;
        _maneyUi.SetNewManeyUi(Maney);
    }
}
