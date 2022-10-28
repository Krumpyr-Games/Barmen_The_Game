using UnityEngine;
using UnityEngine.UIElements;

public class StockInfoPanellController : MonoBehaviour
{
    [SerializeField] private StockInfoPanel[] _panels;

    private void Start()
    {
        InitializationPanels(_panels);
    }

    private void OnEnable()
    {
        Stock.UpdaitAmount += UpdatePanelAmount;
        Stock.NewBattonActiveit += ActiveitPanel;
        Stock.ResertAmounts += ResetAllAmount;

    }

    private void OnDisable()
    {
        Stock.UpdaitAmount -= UpdatePanelAmount;
        Stock.NewBattonActiveit -= ActiveitPanel;
        Stock.ResertAmounts -= ResetAllAmount;
    }

    private void InitializationPanels(StockInfoPanel[] panels)
    {
       for(int i = 0; i < panels.Length; i++)
        {
            panels[i].Initialization();
        }
    }

    public void UpdatePanelAmount(MineralScripteblObject mineral , int amount)
    {
        for (int i = 0; i < _panels.Length; i++)
        {
            if (_panels[i].Mineral == mineral && _panels[i].gameObject.activeSelf) _panels[i].UpdaiteAmount(amount);
        }
    }

    public void ActiveitPanel(MineralScripteblObject mineral)
    {
         for(int i = 0; i < _panels.Length; i++)
         {
            if (_panels[i].Mineral == mineral) _panels[i].gameObject.SetActive(true);
         }
    }

    public void ResetAllAmount()
    {
        for(int i = 0; i < _panels.Length; i++)
        {
            _panels[i].UpdaiteAmount(0);
        }
    }
}
