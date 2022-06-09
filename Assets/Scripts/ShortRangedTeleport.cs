using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortRangedTeleport : MonoBehaviour
{
    public Transform playerPos;
    public bool shortOnCooldown;
    public float shortCooldown = 3f;
    public KeyCode m_short;
    public float shortTeleport = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        shortOnCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShortTeleport();
    }

    void ShortTeleport()
    {
        if (Input.GetKey(m_short) && shortOnCooldown == false)
        {
            playerPos.transform.position += playerPos.transform.forward * shortTeleport;
            shortOnCooldown = true;
            shortCooldown = 3;
        }
        if (shortOnCooldown == true)
        {
            shortCooldown -= Time.deltaTime;
            if (shortCooldown <= 0)
            {
                shortOnCooldown = false;
            }
        }
    }
}
