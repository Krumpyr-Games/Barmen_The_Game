using UnityEngine;

public class TransleiterMeneger : MonoBehaviour
{
    public delegate void Transleit(int namber);
    public static event Transleit Transleiter;

    public void Ukrein()
    {
        Transleiter(1);
    }

    public void Rushen()
    {
        Transleiter(2);
    }

    public void English()
    {
        Transleiter(3);
    }
}
