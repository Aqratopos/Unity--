using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class SpawnGoblin : MonoBehaviour
{
    // deb_Goblin01 预制体
    public GameObject goblinPrefab;

    // 产生间隔
    public float spawnInterval = 5f;

    // 目标位置（可以是 BG 物体的平面上的任何点）
    public Transform target;

    private Coroutine spawnCoroutine;

    void Start()
    {
        // 检查 Demo 是否激活，如果激活则启动协程
        if (gameObject.activeSelf)
        {
            spawnCoroutine = StartCoroutine(SpawnGoblinRoutine());
        }
    }

    void OnEnable()
    {
        // 启动协程，定期生成 deb_Goblin01
        spawnCoroutine = StartCoroutine(SpawnGoblinRoutine());
    }

    void OnDisable()
    {
        // 在 Demo 不激活时停止协程
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }

    IEnumerator SpawnGoblinRoutine()
    {
        // 等待一帧，确保 Demo 状态已经更新
        yield return null;

        while (true)
        {
            // 生成 deb_Goblin01
            SpawnGoblinAtRandomPosition();

            // 等待一定时间后再生成下一个 deb_Goblin01
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnGoblinAtRandomPosition()
    {
        if (goblinPrefab != null && target != null)
        {
            // 在 BG 物体的平面上的随机位置生成 deb_Goblin01
            Vector3 randomPosition = GetRandomPointOnPlane();
            GameObject goblin = Instantiate(goblinPrefab, randomPosition, Quaternion.identity);

            // 设置 deb_Goblin01 的目标位置
            goblin.GetComponent<Target>().target = target;
        }
    }

    Vector3 GetRandomPointOnPlane()
    {
        // 获取 BG 物体的平面上的随机点
        Vector3 randomPoint = new Vector3(
            Random.Range(-9f, 9f),
            transform.position.y + 2f,
            Random.Range(-13f, 13f)
        );

        return randomPoint;
    }
}