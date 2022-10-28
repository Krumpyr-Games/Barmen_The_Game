using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Mineral" , menuName ="GamePlay/NewMineral")]
public class MineralScripteblObject : ScriptableObject
{
    [SerializeField] private int _price;
    [SerializeField] private int _mineralLvl;
    [SerializeField] private Image _mineralIcon;

    public int Price => _price;
    public Image MineralIcon => _mineralIcon;
    public int MineralLvl => _mineralLvl;

}
