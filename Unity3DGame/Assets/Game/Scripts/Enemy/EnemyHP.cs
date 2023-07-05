using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int thisEnemyHp;

    // Enemy HP is allwas updated
    private void Update()
    {
        thisEnemyHp = EnemyHPManager.Instance.enemyHP;
    }
}
