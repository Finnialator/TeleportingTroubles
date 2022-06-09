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
    void Start()
    {
        longOnCooldown = false;
    }
    void LongTeleport()
    {
        if (Input.GetKey(m_long) && longOnCooldown == false) // Activates Long-Range Teleportation
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
        else if (longOnCooldown == true) // Cooldown calculations
        {
            longCooldown -= Time.deltaTime;
            if (longCooldown <= 0)
            {
                longOnCooldown = false;
            }
        }
    }
    void Update()
    {
        LongTeleport();   
    }
}
