using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    public Transform hedef;
    public Vector3 hedefMesafe;
    [SerializeField]
    private float fareHassasiyeti;
    float fareX, fareY;

    Vector3 objRot;
    public Transform karekterVucut;

    KarekterKomtrol karekterHp;
    void Start()
    {
        karekterHp = GameObject.Find("Swat").GetComponent<KarekterKomtrol>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {

        if (karekterHp.YasiyorMu() == true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, hedef.position + hedefMesafe, Time.deltaTime * 10);
            if (fareY > 25)
            {
                fareY = 25;
            }
            if (fareY <= -40)
            {
                fareY = -40;
            }
            fareX += Input.GetAxis("Mouse X") * fareHassasiyeti;
            fareY += Input.GetAxis("Mouse Y") * fareHassasiyeti;
            this.transform.eulerAngles = new Vector3(fareY, fareX, 0);
            hedef.transform.eulerAngles = new Vector3(0, fareX, 0);
            Vector3 gecici = this.transform.localEulerAngles;
            gecici.z = 0;
            gecici.y = this.transform.localEulerAngles.y;
            gecici.x = this.transform.localEulerAngles.x + 10;
            objRot = gecici;
            karekterVucut.transform.localEulerAngles = objRot;
        }

    }
}
