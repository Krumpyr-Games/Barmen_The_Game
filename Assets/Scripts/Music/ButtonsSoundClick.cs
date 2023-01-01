using UnityEngine;
using UnityEngine.UI;

public class ButtonsSoundClick : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioClip audioClip;

     private AudioSource _audioSource;
    private float MusicVouluNow;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        MusicVouluNow = PlayerPrefs.GetFloat("MusicEffects");
        _audioSource.volume = MusicVouluNow;
        _slider.value = MusicVouluNow;
    }
    private void OnDisable()
    {
        MusicVouluNow = _audioSource.volume;
        PlayerPrefs.SetFloat("MusicEffects", MusicVouluNow);
    }

    private void Update()
    {
        _audioSource.volume = _slider.value;
    }

    public void PlayClickSound()
    {
        _audioSource.PlayOneShot(audioClip);
    }
}
