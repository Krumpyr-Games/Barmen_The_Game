using UnityEngine;
using UnityEngine.UI;

public class Transleit : MonoBehaviour
{

    [SerializeField] private Text _text;

    [SerializeField] private string _Rus;
    [SerializeField] private string _Ukr;
    [SerializeField] private string _Eng;

    private int _lengvitchNow = 1;
    private void OnEnable()
    {
        TransleiterMeneger.Transleiter += SetLengvitch;
        _lengvitchNow = PlayerPrefs.GetInt("Lengvitch");
        SetLengvitch(_lengvitchNow);
    }

    private void OnDisable()
    {
        TransleiterMeneger.Transleiter -= SetLengvitch;
        PlayerPrefs.SetInt("Lengvitch" , _lengvitchNow);
    }

    public void SetLengvitch(int namber)
    {
        if (namber > 3) return;
        switch (namber)
        {
            case  1: 
                _text.text = _Rus;
                break;
            case 2:
                _text.text = _Ukr;
                break;
            case 3:
                _text.text = _Eng;
                break;
        }
        _lengvitchNow = namber;
    }
}
