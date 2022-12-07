using SavingSystems.Data;
using UnityEngine;
using UnityEngine.UI;

public class Mineral : MonoBehaviour
{
    public delegate MineralScripteblObject UpdaiteMineral(Mineral mineral);
    public static event UpdaiteMineral MineralUpdaiter;

    [SerializeField] private MineralScripteblObject _mineral;
    [SerializeField] private Player _playerSteats;
    [SerializeField] private Stock _stock;

    [Header("Music")]
    [SerializeField] private AudioSource _audioSource;

    public MineralScripteblObject MineralTaype => _mineral;
    public Text _text;

    [SerializeField] private SpriteRenderer _icon;

    private void Start()
    {
        SetNewSpraite();
    }

    public void SetNewSpraite()
    {
        _icon.sprite = _mineral.MineralIcon;
    }

    private void OnMouseDown()
    {
        if (_playerSteats._behaviorCurent.GetType() == typeof(UpMineralPlayerBehavior))
        {
            _mineral = MineralUpdaiter(this);
            SetNewSpraite();
            return;
        }

        _audioSource.Play();
#pragma warning disable CS0162 
        _stock.GotMineral(_mineral);
    }

    public void UpdaiteMineralPrayseText(int _newPrayse)
    {
        _text.text = _newPrayse.ToString();
    }

    public void SetSeifMineral(MineralScripteblObject mineralScriptebl)
    {
        if (mineralScriptebl == null) return;
        _mineral = mineralScriptebl;
        _icon.sprite = mineralScriptebl.MineralIcon;

    }
}
