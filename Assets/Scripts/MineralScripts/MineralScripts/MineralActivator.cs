using UnityEngine;

public class MineralActivator : MonoBehaviour
{
    [SerializeField] private Mineral[] _minerals;
    private int _mineralNow = 0;
    private bool _firstStart = false;
     public void ActiveitNextMineral()
     {
        if (!_firstStart)
        {
            _firstStart = true;
            _minerals[_mineralNow].gameObject.SetActive(true);
            return;
        }
        _minerals[_mineralNow + 1].gameObject.SetActive(true);
        _mineralNow += 1;
     }
}
