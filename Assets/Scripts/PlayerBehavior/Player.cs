using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Dictionary<Type, IPlayerBehavior> PlayerBehaviorMap;
    public IPlayerBehavior _behaviorCurent { get; private set; }

    [Header("UpMineralPlayerBehaviorSettings")]
    [SerializeField] private GameObject[] _shop;
    [SerializeField] private GameObject _skipBatton;
    [SerializeField] private MineralUp _mineralUp;
    private void Start()
    {
        InitBehavior();
        SetCurentBehavior();
    }

    private void InitBehavior()
    {
        PlayerBehaviorMap = new Dictionary<Type, IPlayerBehavior>();

        this.PlayerBehaviorMap[typeof(UpMineralPlayerBehavior)] = new UpMineralPlayerBehavior(_skipBatton , _shop , 
            _mineralUp._mineralTextController, _mineralUp);
        this.PlayerBehaviorMap[typeof(UpWorkerPlayerBehavior)] = new UpWorkerPlayerBehavior();
        this.PlayerBehaviorMap[typeof(WorkPlayerBehavior)] = new WorkPlayerBehavior();
    }

    private void SetCurentBehavior()
    {
        var behaviour = GetPlayrbehavior<WorkPlayerBehavior>();
        _behaviorCurent = behaviour;
    }

    private void SetPlayerBehavior(IPlayerBehavior behavior)
    {
        if (_behaviorCurent == null) return;
        _behaviorCurent.Exit();

        _behaviorCurent = behavior;
        _behaviorCurent.Enter();
    }

    private IPlayerBehavior GetPlayrbehavior<T>() where T : IPlayerBehavior
    {
        var type = typeof(T);
        return PlayerBehaviorMap[type];
    }

    public void SetBehviorWork()
    {
        var behaviour = GetPlayrbehavior<WorkPlayerBehavior>();
        SetPlayerBehavior(behaviour);
    }

    public void SetBehviorUpWorker()
    {
        var behaviour = GetPlayrbehavior<UpWorkerPlayerBehavior>();
        SetPlayerBehavior(behaviour);
    }

    public void SetBehviorUpMineral()
    {
        var behaviour = GetPlayrbehavior<UpMineralPlayerBehavior>();
        SetPlayerBehavior(behaviour);
    }
}
