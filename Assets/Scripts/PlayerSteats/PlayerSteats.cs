using UnityEngine;

public class PlayerSteats : MonoBehaviour
{
    public bool PlayerWantApdaite { get; private set; } = false;

    public void SetPlayerWantApdaiteSteat(bool value)
    {
        PlayerWantApdaite = value;
    }
}
