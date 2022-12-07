using SavingSystems.Interfaces;
using SavingSystems.Systems;
using UnityEngine;

public class MineralActivator : MonoBehaviour
{
    private const string _path = "MineralData.json";

    [SerializeField] private Mineral[] _minerals;
    private MineralScripteblObject[] _mineralsBox;
    private IDataSaver<MineralScripteblObject> _dataSaver;
    private int _mineralNow = 0;
    private bool _firstStart = false;

    private void Awake()
    {
        _dataSaver = new SavingSystem<MineralScripteblObject>();
        Debug.Log(Application.persistentDataPath + _path);

        _mineralsBox = _dataSaver.LoadObjects(Application.persistentDataPath + _path);
        for (int i = 0; i < _minerals.Length; i++)
        {
            _minerals[i].SetSeifMineral(_mineralsBox[i]);
        }
    }

    private void OnApplicationQuit()
    {
        for (int i = 0; i < _minerals.Length; i++)
        {
            _mineralsBox[i] = _minerals[i].MineralTaype;
        }
        _dataSaver.SaveObjects(_mineralsBox, Application.persistentDataPath + _path);
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
