using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float maxHP;
    public float currentHP;

    public float maxSP;
    public float currentSP;

    [SerializeField]
    private Transform hpBar;
    private Vector2 hpScale;

    [SerializeField]
    private Transform spBar;
    private Vector2 spScale;

    // Start is called before the first frame update
    void Start()
    {
        hpScale = hpBar.localScale;
        currentHP = maxHP; //50

        spScale = spBar.localScale;
        currentSP = maxSP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveDamage(float damage)
    {
        float estimateHP = currentHP - damage;
        if (estimateHP <= 0)
        {
            currentHP = 0;
        }
        else
        {
            currentHP = estimateHP;
        }
        float newScale = hpScale.x * (currentHP / maxHP); 
        hpBar.localScale = new Vector2(newScale, hpScale.y);
    }

    public void ReceiveHeal(float heal)
    {
        float estimateHP = currentHP + heal;
        if (estimateHP > maxHP)
        {
            currentHP = maxHP;
        } else
        {
            currentHP = estimateHP;
        }
        float newScale = hpScale.x * (currentHP / maxHP); 
        hpBar.localScale = new Vector2(newScale, hpScale.y);
    }

    public void StaminaChange(float change)
    {
        float estimateSP = currentSP + change;
        if (estimateSP > maxSP || estimateSP <= 0)
        {
            return;
        }

        currentSP = estimateSP;

        float newScale = spScale.x * (currentSP / maxSP);
        spBar.localScale = new Vector2(newScale, spScale.y);
    }
}
