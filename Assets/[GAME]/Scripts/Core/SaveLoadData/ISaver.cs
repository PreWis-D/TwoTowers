using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaver
{
    void Save(int stateValue);
    int Load();
}
