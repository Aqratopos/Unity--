using UnityEngine;
using UnityEngine.UI;

public class GoblinHealth : MonoBehaviour
{
    public Slider healthBarSlider;
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        // 初始化当前生命值为最大生命值
        currentHealth = maxHealth;

        // 更新血条显示
        UpdateHealthBar();
    }

    void Update()
    {
        // 在这里添加其他逻辑，比如受伤判断等

        // 更新血条位置
        UpdateHealthBarPosition();
    }

    // 受伤方法
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        // 更新血条显示
        UpdateHealthBar();

        // 在这里添加其他受伤逻辑，比如死亡判断等
    }

    // 更新血条显示方法
    void UpdateHealthBar()
    {
        // 确保血条 Slider 已经关联
        if (healthBarSlider != null)
        {
            // 设置血条的值为当前生命值与最大生命值的比例
            healthBarSlider.value = currentHealth / maxHealth;
        }
    }

    // 更新血条位置方法
    void UpdateHealthBarPosition()
    {
        // 获取哥布林头部在世界坐标中的位置
        Vector3 goblinHeadPosition = transform.position + Vector3.up * 2.5f;

        // 将头部位置转换为屏幕坐标
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(goblinHeadPosition);

        // 设置血条的位置为屏幕坐标
        if (healthBarSlider != null)
        {
            healthBarSlider.transform.position = screenPosition;
        }
    }
}