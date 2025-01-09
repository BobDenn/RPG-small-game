using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Freeze enemies Effect", menuName = "Data/Item Effect/Freeze Effect")]
public class FreezeEnemies_Effect : ItemEffect
{
    [SerializeField] private float duration;

    public override void ExecuteEffect(Transform _transform)
    {
        PlayerStatus playerStatus = PlayerManager.instance.player.GetComponent<PlayerStatus>();
        
        //only turn on if player's HP is below 10%
        if (playerStatus.currentHp > playerStatus.GetMaxHpValue() * 0.5f)
            return;
        
        if(!Inventory.instance.CanUseArmor())
            return;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_transform.position, 2);

        foreach (var hit in colliders)
        {
            hit.GetComponent<Enemy>()?.ItemFreezeTime(duration);
        }
    }
}
