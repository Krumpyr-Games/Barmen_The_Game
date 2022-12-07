using UnityEngine;
using UnityEngine.UI;

public class MusicInStartLocation : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private Slider _musicSlider;

    private float MusicVouluNow;

    private void OnEnable()
    {
        MusicVouluNow = PlayerPrefs.GetFloat("Music");
        _musicSource.volume = MusicVouluNow;
        _musicSlider.value = MusicVouluNow;
    }

    private void OnDisable()
    {
         MusicVouluNow = _musicSource.volume;
        PlayerPrefs.SetFloat("Music" , MusicVouluNow);
    }

    private void Update()
    {
        _musicSource.volume = _musicSlider.value;
    }

    public void SetMusicActicity(bool MusicActivity)
    {
        _musicSource.mute = MusicActivity;
    }
    
}
