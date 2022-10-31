using UnityEngine;
using UnityEngine.UI;

public class ManeyUi : MonoBehaviour
{
    [SerializeField] private Text _maneyText;

    public void SetNewManeyUi(int NewManey)
    {
        _maneyText.text = NewManey.ToString();
    }
}
