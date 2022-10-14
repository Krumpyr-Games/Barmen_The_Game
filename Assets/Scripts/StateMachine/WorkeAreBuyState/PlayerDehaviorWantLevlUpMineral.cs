using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDehaviorWantLevlUpMineral : MonoBehaviour, IPlayerBehavior
{

     private StateCase _stats = new StateCase();

    public void Enter()
    {
        if (_stats.GetPlayerWantBuyUpForMineralState() == true )
        {
            Debug.Log("��������� ��� ������������");
            return;
        }
        _stats.EnterPlayerWantBuyUpForMineralState();
    }

    public void Exit()
    {
      if(_stats.GetPlayerWantBuyUpForMineralState() == false)
        {
            Debug.Log("��������� �� ����������� , �� ���� �� �������� �����?");
            return;
        }
        _stats.ExitPlayerWantBuyUpForMineralState();
    }
}
