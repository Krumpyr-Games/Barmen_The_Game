using UnityEngine;

public class MineralUpMusic : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _source;

    public void PlayMineralUpSon()
    {
        _source.PlayOneShot(_clip); 
    }
}
