using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int _maney { get; private set; }

    public void PluseManey(int maney)
    {
        if (maney <= 0) return;
        _maney += maney;
    }

    public void MinuseManey(int maney)
    {
        if (maney <= 0) return;
        _maney += maney;
    }
}
