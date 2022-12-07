using SavingSystems.Interfaces;
using SavingSystems.Systems;
using UnityEngine;

public class Test : MonoBehaviour
{
    private IDataSaver<SMaterial> _dataProvider;

    private void Start()
    {
        _dataProvider = new SavingSystem<SMaterial>();
        Example();
    }
    private void Example()
    {
        //Create material
        SMaterial materialExample = new SMaterial("HellOre", 75);
        //Save to Json       
        _dataProvider.SaveObject(materialExample, Application.persistentDataPath + "materialExample.json");

        Debug.Log($">>> {materialExample.name}");
        Debug.Log($">>> {materialExample.cost}");

        materialExample = new SMaterial("NONE", 0);

        Debug.Log($">>> {materialExample.name}");
        Debug.Log($">>> {materialExample.cost}");

        //Load from JSON

        materialExample = _dataProvider.LoadObject(Application.persistentDataPath + "materialExample.json");

        Debug.Log($">>> {materialExample.name}");
        Debug.Log($">>> {materialExample.cost}");
    }
}
public class SMaterial
{
    public string name;
    public int cost;
    public SMaterial(string name, int cost)
    {
        this.name = name;
        this.cost = cost;
    }
}
