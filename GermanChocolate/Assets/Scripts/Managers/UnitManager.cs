using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitManager
{
    static List<UnitSprite> unitList;

    public static void AddUnit(UnitSprite unit)
    {
        unitList.Add(unit);
    }
}
