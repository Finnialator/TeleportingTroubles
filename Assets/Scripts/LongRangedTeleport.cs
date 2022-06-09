using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangedTeleport : MonoBehaviour
{
    public Transform playerPos;
    public bool longOnCooldown;
    public float longCooldown = 10f;
    public KeyCode m_long;
    

    // Start is called before the first frame update
    void Start()
    {
        longOnCooldown = false;
    }

    void LongTeleport()
    {
        if (Input.GetKey(m_long) && longOnCooldown == false)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                playerPos.transform.position = hit.point;
                longOnCooldown = true;
                longCooldown = 10;
            }
        }
        else if (longOnCooldown == true)
        {
            longCooldown -= Time.deltaTime;
            if (longCooldown <= 0)
            {
                longOnCooldown = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        LongTeleport();   
    }
}
