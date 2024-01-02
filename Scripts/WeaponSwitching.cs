using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectWeapon = 0;

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
         // 检查当前物体的标签是否为"Gun2"
/*        if (!gameObject.CompareTag("Gun2"))
        {
             OnUnScoped();
        }
*/ 

        int perviousSelectedWeapon = selectWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectWeapon >= transform.childCount - 1)
                selectWeapon = 0;
            else
                selectWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectWeapon <= 0)
                selectWeapon = transform.childCount - 1;
            else
                selectWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectWeapon = 2;
        }

        if (perviousSelectedWeapon != selectWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
/*    void OnUnScoped()
    {
        // 使用FindObjectOfType获取Scope脚本的引用
        Scope script = FindObjectOfType<Scope>();

        // 检查是否找到了Scope脚本
        if (script != null)
        {
            script.OnUnScoped();
        }
        else
        {
            Debug.LogError("Scope script not found!");
        }
     }
*/
}