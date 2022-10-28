using UnityEngine;
using UnityEngine.UI;

public class Mineral : MonoBehaviour
{
    public delegate MineralScripteblObject UpdaiteMineral(MineralScripteblObject mineral);
    public static event UpdaiteMineral MineralUpdaiter;

    [SerializeField] private MineralScripteblObject _mineral;
    [SerializeField] private PlayerSteats _playerSteats;
    [SerializeField] private Stock _stock;
    private Image _icon;

    private void Start()
    {
        _icon = GetComponent<Image>();
        SetNewSpraite();
    }

    public void SetNewSpraite()
    {
        _icon = _mineral.MineralIcon;
    }

    private void OnMouseDown()
    {
        if (_playerSteats.PlayerWantApdaite)
        {
            _mineral = MineralUpdaiter(_mineral); 
            SetNewSpraite(); 
            return;
        }      

#pragma warning disable CS0162 
        _stock.GotMineral(_mineral);
    }
}
