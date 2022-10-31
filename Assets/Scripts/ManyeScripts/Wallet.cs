using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private ManeyUi _maneyUi;

    public int Maney { get; private set; } = 0;

    private void Start()
    {
        _maneyUi.SetNewManeyUi(Maney);
    }

    public void MinuseManey(int MinseManey)
    {
        Maney -= MinseManey;
        _maneyUi.SetNewManeyUi(Maney);
    }

    public void PluseManey(int PluseManey)
    {
        Maney += PluseManey;
        _maneyUi.SetNewManeyUi(Maney);
    }
}
