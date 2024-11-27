using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarekterKomtrol : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    private float karekterHiz;
    [SerializeField]
    private float saglik = 100;
    bool hayattaMi;
    void Start()
    {
        anim =this.GetComponent<Animator>();
        hayattaMi = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (saglik <=0)
        {
            hayattaMi = false;
            anim.SetBool("yasiyorMu",hayattaMi);
        }
        if(hayattaMi == true)
        {
            Hareket();
        }
        
    }
    public bool YasiyorMu()
    {
        return hayattaMi;

    }
    public void HasarAl()
    {
        saglik -= Random.Range(25, 50);
    }
   void Hareket()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        anim.SetFloat("Horizontal", yatay);
        anim.SetFloat("Vertical", dikey);
        this.gameObject.transform.Translate(yatay * karekterHiz*Time.deltaTime, 0, dikey * karekterHiz * Time.deltaTime);

    }
}
