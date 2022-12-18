using UnityEngine;

public class MineralData 
{
   public MineralData(int StockLvl , int MaxCount , float ResetTime , int MineralCool)
    {
        this.StockLvl = StockLvl;
        this.MaxCount = MaxCount;
        this.ResetTime = ResetTime;
        this.MineralCool = MineralCool;
    }


    public int StockLvl;
    public int MaxCount;
    public float ResetTime;
    public int MineralCool;
}
