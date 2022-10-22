using UnityEngine;

public class Mineral : MonoBehaviour
{
    [SerializeField] private MineralScripteblObject _mineral;
    [SerializeField] private Stock _stock;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.sprite = _mineral.MineralIcon;
    }
    private void OnMouseDown()
    {
        _stock.GotMineral(_mineral);
    }
}
