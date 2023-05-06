using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public int score = 0;
    public GameObject winMsg; 
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 4f))
        {
            if (hit.transform.GetComponent<Coin>().isCoin == true && Input.GetKey("e"))
            {
                score++;
                Destroy(hit.transform.gameObject);
            }
        }
        if(score ==  5)
        {
            GetComponent<Playermove>().enabled = false;
            winMsg.SetActive(true);
        }
        Debug.Log(score);     
    }
}
