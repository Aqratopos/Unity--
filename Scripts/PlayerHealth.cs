using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // 玩家的最大生命值
    public float maxHealth = 100f;

    // 当前生命值
    private float currentHealth;

    // Slider组件用于显示血量
    public Slider healthSlider;

    
    public float damageAmount = 10f;

    // 目标对象（玩家）
    public Transform target;

    // 靠近目标的距离
    public float proximityDistance = 1f;
    void Start()
    {
        // 初始化生命值
        currentHealth = maxHealth;

        // 更新血量Slider的显示
        UpdateHealthSlider();
    }
    void Update()
    {
        // 检测哥布林武器是否靠近目标
        if (target != null && Vector3.Distance(transform.position, target.position) < proximityDistance)
        {
            Debug.Log("111");
            // 靠近目标时，减少目标的血量
            
            
            
            
                TakeDamage(damageAmount);
                Debug.Log("2222");
            
        }
    }

    void UpdateHealthSlider()
    {
        // 确保Slider已经关联
        if (healthSlider != null)
        {
            // 设置Slider的值为当前生命值与最大生命值的比例
            healthSlider.value = currentHealth / maxHealth;
        }
        // 更新血量Slider的显示
        UpdateHealthSlider();
    }

    // 当哥布林的武器接触到玩家时调用
    public void TakeDamage(float damageAmount)
    {
        // 减少生命值
        currentHealth -= damageAmount;
        Debug.Log("3333333");



        // 判断是否死亡
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // 在这里添加玩家死亡的逻辑，例如播放死亡动画、重置位置等
        // 这里只是简单地禁用玩家对象
        gameObject.SetActive(false);
    }

}