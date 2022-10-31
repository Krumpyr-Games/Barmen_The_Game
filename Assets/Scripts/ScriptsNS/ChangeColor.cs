using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public GameObject go;
    public void ChangeC()
    {
        go.GetComponent<Graphic>().color = Color.white;
    }
    public void ChangeC2()
    {
        go.GetComponent<Graphic>().color = Color.grey;
    }
}
