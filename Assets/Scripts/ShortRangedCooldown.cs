using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortRangedCooldown : MonoBehaviour
{
    public bool shortOnCooldown;
    public float shortCooldown = 3f;
    public float cooldownTotal = 3f;
    public KeyCode m_short;
    public Slider meterSlider;

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
            shortOnCooldown = true;
            shortCooldown = 3;
        }
        if (shortOnCooldown == true)
        {
            float percentageResult =  shortCooldown / cooldownTotal;
            meterSlider.value = percentageResult;
            shortCooldown -= Time.deltaTime;
            if (shortCooldown <= 0)
            {
                shortOnCooldown = false;
            }
        }
    }
}
