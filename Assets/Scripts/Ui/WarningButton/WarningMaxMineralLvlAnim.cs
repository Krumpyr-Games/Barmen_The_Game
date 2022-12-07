using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningMaxMineralLvlAnim : MonoBehaviour
{
    [SerializeField] private Animator _maximumLevelWarningAnimator;
    public bool _palayAnimation { get; private set; } = false;
    public IEnumerator MaximumLevelWarningPanelLaife( int _timeDeforDestroy)
    {
        _maximumLevelWarningAnimator.SetTrigger("WarningBattonOn");
        yield return new WaitForSeconds(_timeDeforDestroy);
        _maximumLevelWarningAnimator.SetTrigger("WarningButtonOff");
    }

    public void AnimationChange()
    {
        _palayAnimation = !_palayAnimation;
    }
}
