using UnityEngine;

public class PlayerSteats : MonoBehaviour
{
    public bool PlayerWantApdaite { get; private set; } = true;

    public void SetPlayerWantApdaiteSteat(bool value)
    {
        PlayerWantApdaite = value;
    }
}
