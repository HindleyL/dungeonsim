using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Ray mouseRay = GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f,0.5f,0.5f));
            RaycastHit hitInfo;
            if (Physics.Raycast(mouseRay, out hitInfo))
            {
                GunUpgrade Gun2 = hitInfo.transform.GetComponent<GunUpgrade>();
                if (Gun2.enabled)
                {
                    Gun2.enabled = true;
                }
            }
        }
    }
}
