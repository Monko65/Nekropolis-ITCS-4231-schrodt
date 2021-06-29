using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Contains("|Rogue|"))
        {
            if (Rogue.Instance.QueryTreasure() == false)
            {
                Rogue.Instance.CollectTreasure(); 
                Destroy(this.gameObject);
            }
        }
    }
}
