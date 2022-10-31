using UnityEngine;

public class econ_const : MonoBehaviour
{

    #region CONSTANTS
    public static int money_now; // Сумма денег у игрока
    public static int levels_mine_now; // Номер локации

    public static int clicks_now; // Количество нажатий за 1 клик
    public static int clicks_level; // Уровень клика

    public static int stock_level; // Уровень склада
    public static int stock_now; // Количество руды на складе (максимальное)

    public static int rab_level; // Уровень раба

    public static int cost_rudes_cuprum; // Стоимость за единицу руды меди
    public static int cost_rudes_ferum; // Стоимость за единицу руды железа
    public static int cost_rudes_aurum; // Стоимость за единицу руды золота

    public static int lvl_rudes_cuprum; // Уровень руды меди
    public static int lvl_rudes_ferum; // Уровень руды железа
    public static int lvl_rudes_aurum; // Уровень руды золота

    #endregion

    void Start()
    {
        money_now = 100000;
        levels_mine_now = 1;
        clicks_now = 1;
        clicks_level = 1;
        stock_level = 1;
        stock_now = 20;
        rab_level = 1;


    }

}
