using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private ManeyUi _maneyUi;
    
    public int Maney { get; private set; } = 0;

    private void Start()
    {
        PluseManey(10000000);
        
        _maneyUi.SetNewManeyUi(Maney);
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
        if(PluseManey <= 0) return;
        Maney += PluseManey;
        _maneyUi.SetNewManeyUi(Maney);
    }
}
