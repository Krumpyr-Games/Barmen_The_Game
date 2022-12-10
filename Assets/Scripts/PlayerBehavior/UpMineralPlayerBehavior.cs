using UnityEngine;

public class UpMineralPlayerBehavior : IPlayerBehavior
{
    public UpMineralPlayerBehavior(GameObject _skipBatton , GameObject[] _shop ,  MineralUp _mineralUp)
    {
        this._skipBatton = _skipBatton;
        this._shop = _shop;
        this._mineralUp = _mineralUp;
    }

    private GameObject[] _shop;
    private GameObject _skipBatton;
    private MineralUp _mineralUp;

    public void Enter()
    {
        _mineralUp.SetActivitMineralTexts(true);
        ChangeActiviteGameObj(_shop, false);
        _skipBatton.SetActive(true);
    }

    public void Exit()
    {
        _mineralUp.SetActivitMineralTexts(false);
        ChangeActiviteGameObj(_shop, true);
        _skipBatton.SetActive(false);
    }
      
    private void ChangeActiviteGameObj(GameObject[] _objects , bool _activity)
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].gameObject.SetActive(_activity);
        }
    }
}
