using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera MainCamera;
    public float scopedFov = 15f;
    private float normalFov;
    private bool isScoped = false;


    void Update()
    {
         
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);

            if (isScoped)
            {
                StartCoroutine(OnScoped());
            }
            else
            {
                OnUnScoped();
            }
        }
    }

   public void OnUnScoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        MainCamera.fieldOfView = normalFov;
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.15f);
        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
        normalFov = MainCamera.fieldOfView;
        MainCamera.fieldOfView = scopedFov;
    }
}
