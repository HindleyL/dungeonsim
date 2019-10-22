using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    int upgradeScore = 500;
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
                if (hitInfo.transform.gameObject.tag == "Upgrade"&& UIScript.score>upgradeScore)
                {
                    GetComponent<Shooting>().upgradeGun();
                    upgradeScore += 500;
                }
            }
        }
    }
}
