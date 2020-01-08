using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Animator anim;
    [SerializeField] int damageDealt = 20;
    [SerializeField] LayerMask layerMask;
    AudioSource audioSrc;
    [SerializeField] AudioClip shootclip;
    public ParticleSystem mf;
    public GameObject grenade;
    public float timeToThrow = 10; 
    float timehold;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc=GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        layerMask |= Physics.IgnoreRaycastLayer;
        layerMask = ~layerMask;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    public GameObject losepanel;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if(Input.GetButtonDown("Fire1"))
        {
            if (!losepanel.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
                //anim.SetTrigger("Trigger");
                audioSrc.clip = shootclip;
                audioSrc.Play();
                mf.Play();
                Ray mouseRay = GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hitInfo;
                if (Physics.Raycast (mouseRay, out hitInfo,100,layerMask))
                {
                    Debug.DrawLine(transform.position, hitInfo.point, Color.red, 5.0f);
                    HealthScript enemyHealth = hitInfo.transform.GetComponent<HealthScript>();
                if (enemyHealth != null)
                {
                    enemyHealth.Damage(damageDealt);
                    Debug.Log(damageDealt);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.G)&&Time.time>timehold+timeToThrow)
        {
            GameObject newgrenade = Instantiate(grenade,transform.position+new Vector3(0,1,1),Quaternion.identity);
            newgrenade.GetComponent<Rigidbody>().AddForce(new Vector3 (0,1,1));
            timehold = Time.time;
        }
    }
        public void upgradeGun()
    {
        damageDealt += 5;
    }
}
