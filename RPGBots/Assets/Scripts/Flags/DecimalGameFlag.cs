using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DecimalGameFlag")]
public class DecimalGameFlag : GameFlag<decimal>
{
    public void SetDecimal(decimal dec)
    {
        Value = dec;
        SendChanged();
    }


}
