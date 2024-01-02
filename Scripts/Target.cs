using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Collections;

public class Target : MonoBehaviour
{
    // 生命值
    public float health;
//    public float maxHealth = 100f;
//    public float manhealth;
    
    // 导航代理器
    private NavMeshAgent navMeshAgent;

    
    private Animator animator;

    
    public Transform target;

   
    public float minAttackDistance = 1.3f;

   
    private bool isAttacking = false;

    // 血量Slider
//    public Slider healthSlider;

    public AudioSource Audio; // 添加AudioSource字段
 //   public AudioSource manAudio;

 //   public GameObject gameOverText;

    void Start()
    {
        // 获取组件
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // 设置移动速度为较小的值
        navMeshAgent.speed = 1f;

        // 初始化血量和Slider
       // manhealth = maxHealth;
        //UpdateHealthSlider();
   
        //if (gameOverText != null)
        //{
           // gameOverText.SetActive(false);
        //}
    }

    void Update()
    {
        // 检查是否存在有效的目标
        if (target != null && NavMesh.SamplePosition(target.position, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
        {
            // 更新导航代理器的目标位置
            navMeshAgent.SetDestination(target.position);

            // 检查距离并根据条件播放 Attack01
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= minAttackDistance && !isAttacking)
            {
                // 在这里添加播放 Attack01 的逻辑
                isAttacking = true;
                animator.SetBool("IsAttacking", true);

                // 减少血量
                //InvokeRepeating("manTakeDamage", 0f, 2f);
                manDamaged();

            }
            else if (distanceToTarget > minAttackDistance && isAttacking)
            {
                // 在这里添加停止播放 Attack01 的逻辑
                isAttacking = false;
                animator.SetBool("IsAttacking", false);
            }
        }
//        if(manhealth<=0f){ 
 //           GameObject.FindGameObjectWithTag("MyWeapons").SetActive(false);
    //        GameObject.FindGameObjectWithTag("BG").SetActive(false);
       //     gameOverText.SetActive(true);
       // }
   }

    // 受伤方法
    public void TakeDamage(float amount)
    {
        health -= amount;
       
        if (health <= 0f)
        {
            // 在这里添加死亡动画或其他逻辑
            StartCoroutine(DieWithAnimation());
        }
    }


    // 协程：等待Die01动画播放完毕后销毁物体
    IEnumerator DieWithAnimation()
    {
        if (Audio != null )
        {
             Audio.Play();
        }
        // 播放Die01动画
        animator.SetTrigger("Died01");

        // 等待动画播放完毕
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + 0.8f);
        // 销毁物体
        Destroy(gameObject);
    }

     void OnDieAnimationStart()
    {
        // 禁用导航代理器以防止在 Die01 动画播放期间移动
        navMeshAgent.enabled = false;
    }
  void manDamaged()
    {
       
        PlayerMovement script = FindObjectOfType<PlayerMovement>();

       
        if (script != null)
        {
            script.manTakeDamage();
        }
        else
        {
            Debug.LogError("PlayerMovement script not found!");
        }
     }
}
