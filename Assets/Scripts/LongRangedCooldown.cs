using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongRangedCooldown : MonoBehaviour
{
    public bool longOnCooldown;
    public float longCooldown = 10f;
    public float cooldownTotal = 10f;
    public KeyCode m_long;
    public Slider meterSlider;
    

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
                longOnCooldown = true;
                longCooldown = 10;
            }
        }
        else if (longOnCooldown == true)
        {
            float percentageResult = longCooldown / cooldownTotal;
            meterSlider.value = percentageResult;
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
