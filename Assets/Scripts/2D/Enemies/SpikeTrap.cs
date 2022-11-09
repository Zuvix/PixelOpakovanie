using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour, ITrap
{

    bool isActive=true;
    

    public bool IsActive()
    {
        return isActive;
    }
}
