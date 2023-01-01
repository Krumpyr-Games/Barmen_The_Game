using UnityEngine;

public class ChangeSrowWU : MonoBehaviour
{
    [SerializeField]private GameObject _panelActiveitNow;

    public void ChangePanel(GameObject _panel)
    {
        _panelActiveitNow.SetActive(false);
        _panelActiveitNow = _panel;
        _panelActiveitNow.SetActive(true);
    }
}
