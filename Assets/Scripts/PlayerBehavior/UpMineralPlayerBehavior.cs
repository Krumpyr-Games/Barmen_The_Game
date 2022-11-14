
using UnityEngine;
using UnityEngine.UI;

public class UpMineralPlayerBehavior : IPlayerBehavior
{
    public UpMineralPlayerBehavior(GameObject _skipBatton , GameObject[] _shop , Text[] _panelTexts , MineralUp _mineralUp)
    {
        this._skipBatton = _skipBatton;
        this._shop = _shop;
        this._panelTexts = _panelTexts;
        this._mineralUp = _mineralUp;
    }

    private Text[] _panelTexts;
    private GameObject[] _shop;
    private GameObject _skipBatton;
    private MineralUp _mineralUp;

    public void Enter()
    {
        ActiveitAllPanelTests(_panelTexts);
        ChangeActiviteGameObj(_shop, false);
        _skipBatton.SetActive(true);
    }

    public void Exit()
    {
        DisActiveitAllPanelTests(_panelTexts);
        ChangeActiviteGameObj(_shop, true);
        _skipBatton.SetActive(false);
    }

    private void ActiveitAllPanelTests(Text[] _texts)
    {
        for (int i = 0; i < _texts.Length; i++)
        {
            _texts[i].gameObject.SetActive(true);
        }
    }

    private void DisActiveitAllPanelTests(Text[] _texts)
    {
        for (int i = 0; i < _texts.Length; i++)
        {
            _texts[i].gameObject.SetActive(false);
        }
    }
      
    private void ChangeActiviteGameObj(GameObject[] _objects , bool _activity)
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].gameObject.SetActive(_activity);
        }
    }
    
}
