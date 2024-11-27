using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AteşSistemi : MonoBehaviour
{
    Camera kamera;
    public LayerMask zombiKatman;
    KarekterKomtrol hpKontrol;
    public ParticleSystem muzzleFlash;
    Animator anim; 


    void Start()
    {
       kamera = Camera.main;
        hpKontrol = this.gameObject.GetComponent<KarekterKomtrol>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpKontrol.YasiyorMu() == true)
        {
            if (Input.GetMouseButton(0))
            {
                AtesEtme();
                anim.SetBool("atesEt", true);
            }
            else if (Input.GetMouseButton(0))
            {
                anim.SetBool("atesEt", false);
            }
        }
       
        
    }
    public void AtesEtme()
    {
        muzzleFlash.Play();
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,Mathf.Infinity,zombiKatman))
        {
            hit.collider.gameObject.GetComponent<Zombi>().HasarAl();
        }
         
    }
}
