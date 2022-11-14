using UnityEngine;

public class Laky : MonoBehaviour
{
    [Header("Laky Settings")]
    [SerializeField] private float _maxLake;
    [SerializeField] private float _lakeProcent;
    [SerializeField] private int _percentMultiplication;
    [SerializeField] private float _perecentLakyUp;
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
        if (_lakeProcent >= _maxLake) return;
        _lakeProcent += _perecentLakyUp;
    }
}
