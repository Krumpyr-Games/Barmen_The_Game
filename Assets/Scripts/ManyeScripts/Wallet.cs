using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Maney { get; private set; } = 0;

    public void MinuseManey(int MinseManey)
    {
        Maney -= MinseManey;
    }

    public void PluseManey(int PluseManey)
    {
        Maney += PluseManey;
    }
}
