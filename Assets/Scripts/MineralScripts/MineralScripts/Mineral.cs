using UnityEngine;
using UnityEngine.UI;

public class Mineral : MonoBehaviour
{
    public delegate MineralScripteblObject UpdaiteMineral(MineralScripteblObject mineral);
    public static event UpdaiteMineral MineralUpdaiter;

    [SerializeField] private MineralScripteblObject _mineral;
    [SerializeField] private Player _playerSteats;
    [SerializeField] private Stock _stock;

    private SpriteRenderer _icon;

    private void Start()
    {
        _icon = GetComponent<SpriteRenderer>();
        SetNewSpraite();
    }

    public void SetNewSpraite()
    {
        _icon.sprite = _mineral.MineralIcon;
    }

    private void OnMouseDown()
    {
        if ( _playerSteats._behaviorCurent.GetType() == typeof(UpMineralPlayerBehavior))
        {
            _mineral = MineralUpdaiter(_mineral);
            SetNewSpraite(); 
            return;
        }      

#pragma warning disable CS0162 
        _stock.GotMineral(_mineral);
    }
}
