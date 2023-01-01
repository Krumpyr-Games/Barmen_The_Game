using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Laky : MonoBehaviour
{
    [Header("Laky Settings")]
    [SerializeField] private float _maxLake;
    [SerializeField] private float _lakeProcent;
    [SerializeField] private int _percentMultiplication;
    [SerializeField] private float _perecentLakyUp;
    [Header("Settings")]
    [SerializeField] private Text text;
    [SerializeField] private Wallet wallet;
    [SerializeField] private WarrningButtoAnim warrning;

     private float StartLakyPrayse = 150;

    private void OnEnable()
    {
        StartLakyPrayse = PlayerPrefs.GetFloat("LakyPrayse");
        _lakeProcent = PlayerPrefs.GetFloat("Laky"); 
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("LakyPrayse", StartLakyPrayse);
        PlayerPrefs.SetFloat("Laky", _lakeProcent);
    }

    public int ChoiceOfLuck(int Mineral)
    {
        if (Random.Range(0, _maxLake) < _lakeProcent)
        {
            Mineral += 1;
            return Mineral *= _percentMultiplication;
        }

        return Mineral;
    }

    public void UpLaky()
    {
        int prayse = GetLakyPrayse();
        if (!wallet.EnoughMoney(prayse)) { warrning.WarningButtonPlayAnim("You haven`t money"); return; }
        if (_lakeProcent >= _maxLake) return;
        wallet.MinuseManey(prayse);
        _lakeProcent += _perecentLakyUp;

        text.text = GetLakyPrayse().ToString();
    }

    public int GetLakyPrayse()
    {
        float prays = StartLakyPrayse *= 1.5f;
        return Convert.ToInt32(prays);
    }

    public int GetLakyPrays()
    {
        float prays = StartLakyPrayse * 1.5f;
        return Convert.ToInt32(prays);
    }
}
