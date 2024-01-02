using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    CharacterController playerController;

    Vector3 direction;

    public float speed = 1;
    public float jumpPower = 5;
    public float gravity = 7f;

    public float mousespeed = 2f;


    public float minmouseY = -45f;
    public float maxmouseY = 45f;

    float RotationY = 0f;
    float RotationX = 0f;

    public Transform agretctCamera;
    
    public float maxHealth = 100f;
    public float manhealth;
// 血量Slider
    public Slider healthSlider;
    public GameObject gameOverText;
    public AudioSource manAudio;
    public GameObject MyWeapons;
    public GameObject BG;
    void Start()
    {
        playerController = this.GetComponent<CharacterController>();
        SetCursorToCentre();
        
        // 初始化血量和Slider
        manhealth = maxHealth;
        UpdateHealthSlider();
    }
    void SetCursorToCentre()
    {
        //锁定鼠标后再解锁，鼠标将自动回到屏幕中心
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        //隐藏鼠标
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        if (playerController.isGrounded)
        {
            direction = new Vector3(_horizontal, 0, _vertical);
            if (Input.GetKeyDown(KeyCode.Space))
                direction.y = jumpPower;
        }

        direction.y -= gravity * Time.deltaTime;
        playerController.Move(playerController.transform.TransformDirection(direction * Time.deltaTime * speed));

        RotationX += Input.GetAxis("Mouse X") * mousespeed;
        RotationY += Input.GetAxis("Mouse Y") * mousespeed;
        RotationY = Mathf.Clamp(RotationY, minmouseY, maxmouseY);

        this.transform.eulerAngles = new Vector3(0, RotationX, 0);
        agretctCamera.transform.localEulerAngles = new Vector3(RotationY, RotationX, 0);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 解锁鼠标
            Cursor.lockState = CursorLockMode.None;
            // 显示鼠标
            Cursor.visible = true;
        }

        if (manhealth <= 0f)
        {
            //GameObject.FindGameObjectWithTag("MyWeapons").SetActive(false);
            MyWeapons.SetActive(false);
            BG.SetActive(false);
            //GameObject.FindGameObjectWithTag("BG").SetActive(false);
            gameOverText.SetActive(true);
        }
    }

    public void manTakeDamage()
    {
        manhealth -= 8f;
        UpdateHealthSlider();
        if (manAudio != null )
        {
            manAudio.Play();
        }

    }
    // 更新血量Slider
    private void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = manhealth / maxHealth;
        }
    }
}