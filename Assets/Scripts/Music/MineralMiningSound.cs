using UnityEngine;
using UnityEngine.UI;

public class MineralMiningSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Slider _slider;

    private void Update()
    {
        _audioSource.volume = _slider.value;   
    }
}
