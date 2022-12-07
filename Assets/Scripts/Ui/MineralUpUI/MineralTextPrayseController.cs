
public class MineralTextPrayseController 
{
     public MineralTextPrayseController(Mineral[] _mineralTexts , int _minPrayse)
     {
        this._mineralTexts = _mineralTexts;
        this._minPrayse = _minPrayse;
     }

    private Mineral[] _mineralTexts;
    private int _minPrayse;

    public void ActiveitPrayseText(bool Activity)
    {
        for(int i = 0; i < _mineralTexts.Length; i ++)
        {
            if (_mineralTexts[i].gameObject.activeSelf)
            {
                _mineralTexts[i]._text.gameObject.SetActive(Activity);
            } 
        }
    }  

    public void InitializeitMineralTextPrayse()
    {
        for (int i = 0; i < _mineralTexts.Length; i++)
        {
            _mineralTexts[i]._text.text = _minPrayse.ToString();
        }
    }
   
}
