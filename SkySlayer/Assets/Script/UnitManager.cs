using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager
{
    public static UnitManager
    public static UnitManager Instance()
    {
        return 
    }
    AutoIDTable<Unit> units;
    public AutoIDTable<Unit> Units { get { return units; } }
    Dictionary<int, Transform> transforms;
    public Dictionary<int, Transform> Transforms{ get { return transforms; } }

    int AddUnit(Unit unit)
    {
        var id = units.Add(unit);
        transforms.Add(id, unit.GetComponent<Transform>());
        return id;
    }

    Unit GetUnit(int id)
    {
        return units[id];
    }
    Dictionary<int, Transform> GetAllTransforms()
    {
        return transforms;
    }

}
