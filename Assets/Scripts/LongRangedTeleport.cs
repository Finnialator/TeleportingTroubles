using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangedTeleport : MonoBehaviour
{
    public Transform playerPos;
    public bool longOnCooldown;
    private float baseCooldown;
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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Finding point to teleport to
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                playerPos.transform.position = hit.point; // Teleport
                longOnCooldown = true;
                baseCooldown = longCooldown; // Cooldown reset
            }
        }
        else if (longOnCooldown == true) // Cooldown calculations
        {
            baseCooldown -= Time.deltaTime;
            if (baseCooldown <= 0)
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
