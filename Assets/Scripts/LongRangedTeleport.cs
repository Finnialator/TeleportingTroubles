using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangedTeleport : MonoBehaviour
{
    public Transform playerPos;
    public bool longOnCooldown;
    public float longCooldown = 3f;
    public KeyCode m_long;
    public float longTeleport = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        longOnCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        LongTeleport();
    }

    void LongTeleport()
    {
        if (Input.GetKey(m_long) && longOnCooldown == false)
        {
            
            
            playerPos.transform.position += playerPos.transform.forward * longTeleport;
                        
            
            longOnCooldown = true;
            longCooldown = 3;
        }
        if (longOnCooldown == true)
        {
            longCooldown -= Time.deltaTime;
            if (longCooldown <= 0)
            {
                longOnCooldown = false;
            }
        }
    }
}
