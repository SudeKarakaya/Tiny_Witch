using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    [SerializeField] public bool isCauldron;
   

    public void CollectThis()
    {
        Destroy(gameObject);
    }


}
