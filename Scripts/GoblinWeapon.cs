using UnityEngine;

public class GoblinWeapon : MonoBehaviour
{
    // 伤害值
    public float damageAmount = 10f;

    // 目标对象（玩家）
    public Transform target;

    // 靠近目标的距离
    public float proximityDistance = 2f;

    void Update()
    {
        // 检测哥布林武器是否靠近目标
        if (target != null && Vector3.Distance(transform.position, target.position) < proximityDistance)
        {
            Debug.Log("111");
            // 靠近目标时，减少目标的血量
            PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
            
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log("2222");
            }
        }
    }
}