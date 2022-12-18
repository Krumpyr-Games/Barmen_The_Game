using SavingSystems.Interfaces;
using SavingSystems.Systems;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    private const string _path = "ManeyDataFile.json";

    [SerializeField] private ManeyUi _maneyUi;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Slider _slider;
    [SerializeField] private WarrningButtoAnim _anim;

    private IDataSaver<int> _dataProvider;

    public int Maney { get; private set; } = 0;

    private void Start()
    {
        _dataProvider = new JsonSavingSystem<int>();
        if (!File.Exists(Application.persistentDataPath + _path)) return;

        Maney = _dataProvider.LoadObject(Application.persistentDataPath + _path);
        _maneyUi.SetNewManeyUi(Maney);
    }

    private void Update()
    {
        _audioSource.volume = _slider.value;
    }

    private void OnApplicationQuit()
    {
        _dataProvider.SaveObject(Maney, Application.persistentDataPath + _path);
    }

    public bool EnoughMoney(int MinuseManey)
    {
        if (Maney - MinuseManey >= 0) { _anim.WarningButtonPlayAnim("You haven`t money"); ; return true; }
        return false;
    }

    public void MinuseManey(int MinseManey)
    {
        if (Maney <= 0) { _anim.WarningButtonPlayAnim("You haven`t money"); ; return; }
        Maney -= MinseManey;
        _maneyUi.SetNewManeyUi(Maney);
    }

    public void PluseManey(int PluseManey)
    {
        if (PluseManey <= 0) return;
        Maney += PluseManey;
        _maneyUi.SetNewManeyUi(Maney);
        _audioSource.PlayOneShot(_audioClip);
    }
}
