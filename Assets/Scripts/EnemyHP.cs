using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] EnemyManager enemyManager;
    float enemyHP;
    GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyHP = enemyManager.ToSetHP;
    }


    public void TakeDMG(float Dmg)
    {
        enemyHP -= Dmg;
        if (enemyHP <= 0) 
        { 
            gameManager.SetCoins(10); 

            Destroy(gameObject); 
        }
    }
}
