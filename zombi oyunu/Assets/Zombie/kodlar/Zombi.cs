using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombi : MonoBehaviour
{
    public float zombiHP = 100;
    Animator zombiAnim;
    bool zombiOlu;
    public float kovalamMesafesi;
    public float saldirmaMesafesi;
    float mesafe;
    NavMeshAgent zombiNavMesh;


    GameObject hedefOyuncu;
    void Start()
    {
        zombiAnim=this.GetComponent<Animator>();
        hedefOyuncu = GameObject.Find("Swat");
        zombiNavMesh=this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (zombiHP <= 0)
        {
            zombiOlu= true;
        }
        if (zombiOlu== true)
        {
            zombiAnim.SetBool("oldu",true);
            StartCoroutine(YokOl());
        }
        else
        {
            float mesafe = Vector3.Distance(this.transform.position, hedefOyuncu.transform.position);
            if (mesafe < kovalamMesafesi)
            {
                zombiNavMesh.isStopped = false;
                zombiNavMesh.SetDestination(hedefOyuncu.transform.position);
                zombiAnim.SetBool("yuruyor", true);
                
                this.transform.LookAt(hedefOyuncu.transform.position);
            }
            else
            {
                zombiNavMesh.isStopped= true;
                zombiAnim.SetBool("yuruyor", false);
                zombiAnim.SetBool("saldýrýyor", false);
            }
            if(mesafe<saldirmaMesafesi)
            {
                this.transform.LookAt(hedefOyuncu.transform.position);
                zombiNavMesh.isStopped = true;
                zombiAnim.SetBool("yuruyor", false);
                zombiAnim.SetBool("saldýrýyor", true);
            }
        }

    }
    public void HasarVer()
    {
        hedefOyuncu.GetComponent<KarekterKomtrol>().HasarAl();
    }
    IEnumerator YokOl()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }     
    public void HasarAl()
    {
        zombiHP -= Random.Range(2,5);
    }
}
