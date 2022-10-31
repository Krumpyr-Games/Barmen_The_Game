using UnityEngine;

public class Mineral : MonoBehaviour
{
    public delegate MineralScripteblObject UpdaiteMineral(MineralScripteblObject mineral);
    public static event UpdaiteMineral MineralUpdaiter;

    [SerializeField] private MineralScripteblObject _mineral;
    [SerializeField] private PlayerSteats _playerSteats;
    [SerializeField] private Stock _stock;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        SetNewSpraite();
    }

    public void SetNewSpraite()
    {
        _renderer.sprite = _mineral.MineralIcon;
    }

    private void OnMouseDown()
    {
        if (_playerSteats.PlayerWantApdaite)
            _mineral = MineralUpdaiter(_mineral); SetNewSpraite(); return;

#pragma warning disable CS0162 
        _stock.GotMineral(_mineral);
    }
}
