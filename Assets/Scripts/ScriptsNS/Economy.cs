using UnityEngine;
using UnityEngine.UI;

public class Economy : MonoBehaviour
{
    public GameObject Notif_1;
    public Text money_text;
    public Text money_button_text;
    public Text description_text;
    public GameObject button_own;

    #region Change

    public int get_money = 20;
    public int lose_money = 100;
    public int get_clicks = 1;
    public int get_level = 1;
    #endregion

    #region Metods
    public void money_add() // Самый простой метод для добавления денег
    {
        econ_const.money_now += get_money;
        money_text.text = "" + econ_const.money_now.ToString();
    }

    public void money_lose() // Самый простой метод для вычитания денег
    {
        econ_const.money_now -= lose_money;
        lose_money = lose_money * 2;
        money_button_text.text = "" + lose_money.ToString();
        money_text.text = "" + econ_const.money_now.ToString();
    }

    public void clicks_add() // Функция улучшения клика
    {
        if(econ_const.clicks_level < 9)
        {
            if (econ_const.money_now >= lose_money)
            {
                econ_const.clicks_now = econ_const.clicks_now + 1;
                econ_const.clicks_level = econ_const.clicks_now;
                if (econ_const.clicks_level < 10)
                {
                    description_text.text = "" + "Улучшение клика (" + econ_const.clicks_now.ToString() + " lvl)";
                }
                else
                {
                    description_text.text = "" + "Улучшение клика (max lvl)";
                }
                money_lose();
            }
            else
            {
                notification_active();
                Invoke("notification_deactive", 2f);
            }
        } else
        {
            econ_const.clicks_now = econ_const.clicks_now + 1;
            econ_const.clicks_level = econ_const.clicks_now;
            description_text.text = "" + "Улучшение клика (max lvl)";
            button_own.SetActive(false);
            money_lose();

        }
    }

    public void notification_active() // Активация уведоомления о нехватке денег
    {
        Notif_1.SetActive(true);
    }

    public void notification_deactive() // Деактивация уведоомления о нехватке денег
    {
        Notif_1.SetActive(false);
    }

    public void stock_add() // Функция улучшения склада
    {
        if (econ_const.stock_level < 9)
        {

            if (econ_const.money_now >= lose_money)
            {
                econ_const.stock_now = econ_const.stock_now * 2;
                Debug.Log(econ_const.stock_now);
                econ_const.stock_level = econ_const.stock_level + 1;
                if (econ_const.stock_level < 10)
                {
                    description_text.text = "" + "Улучшение склада (" + econ_const.stock_level.ToString() + " lvl)";
                }
                else
                {
                    description_text.text = "" + "Улучшение склада (max lvl)";
                }
                money_lose();
            }

            else
            {
                notification_active();
                Invoke("notification_deactive", 4f);
            }
        }
        else
        {
            econ_const.stock_now = econ_const.stock_now * 2;
            econ_const.stock_level = econ_const.stock_now;
            Debug.Log(econ_const.stock_now);
            description_text.text = "" + "Улучшение склада (max lvl)";
            button_own.SetActive(false);
            money_lose();

        }
    }









    public void levels_add()
    {
        econ_const.levels_mine_now += 1;
        Debug.Log(econ_const.levels_mine_now);
    }

    public void level_stock_add()
    {
        econ_const.stock_level += 1;
        Debug.Log(econ_const.stock_level);
    }

    #endregion

    void Start()
    {
        money_text.text = econ_const.money_now.ToString();
    }
}
