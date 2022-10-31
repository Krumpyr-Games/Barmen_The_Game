using UnityEngine;

public class MineralUp : MonoBehaviour
{
    [SerializeField] private MineralScripteblObject[] _minerals;

    private void OnEnable()
    {
        Mineral.MineralUpdaiter += SetNewMineral;      
    }

    private void OnDisable()
    {
        Mineral.MineralUpdaiter -= SetNewMineral;
    }

    public MineralScripteblObject SetNewMineral(MineralScripteblObject mineral)
    {
       for(int i = 0 ; i < _minerals.Length; i++)
       {
            if(mineral.MineralLvl + 1 == _minerals[i].MineralLvl) return _minerals[i];
       }
        throw new System.Exception("Не был найден следующий уровень");
#pragma warning disable CS0162 
        return mineral;
    }

   
}
