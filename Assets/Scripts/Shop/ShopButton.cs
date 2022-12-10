using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private GameObject _shopButton;

    public void ActiveitShopButton()
    {
        _shopButton?.gameObject.SetActive(true);
    }

    public void DisActiveitShopButton()
    {
        _shopButton?.gameObject.SetActive(false);
    }
}
