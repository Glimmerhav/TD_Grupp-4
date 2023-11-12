using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDmgForPlayer : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    bool canTakeDmg;
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("help");
        if (collision.gameObject.tag == "Enemy") {StartCoroutine(playerManager.DmgCyckel()); }
    }


}
