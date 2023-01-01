using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WarrningButtoAnim : MonoBehaviour
{
    [SerializeField] private Animator _warningButton;
    [SerializeField] private Text _text;
    [SerializeField] private int _timeBeforEnd;

    public bool EndAnim { get; private set; } = true;

    public IEnumerator WarningButtonPlayAnim(string Text)
    {
        EndAnim = false;
        _text.text = Text;
        _warningButton.SetTrigger("WarningButtonOn");
        yield return new WaitForSeconds(_timeBeforEnd);
        _warningButton.SetTrigger("WarningButtonOff");
    }

    public void SetWarningButtonActivity()
    {
        EndAnim = !EndAnim; 
    }
}
