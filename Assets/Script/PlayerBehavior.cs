using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float currentHP;
    [SerializeField]
    private float maxSP;
    [SerializeField]
    private float currentSP;

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
        currentHP = maxHP;
        spScale = spBar.localScale;
        currentSP = maxSP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReceivedHP(float damage)
    {
        currentHP = currentHP - damage;
        if (currentHP <= 0)
        {
            hpBar.localScale = new Vector2(0, hpScale.y);
            SceneManager.LoadScene("Buoi3");
        }
        else
        {
            hpBar.localScale = new Vector2(hpScale.x * (currentHP / maxHP), hpScale.y);
        }
    }

    public void ReceivedSP( float damage)
    {
        PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement>();
        currentSP = currentSP - damage;
        if(currentSP <= 0)
        {
            spBar.localScale = new Vector2(0, spScale.y);
           
            playerMovement.speed = 0f;
        }
        else if (currentSP > 0 && currentSP < 50)
        {
            spBar.localScale = new Vector2(spScale.x * (currentSP / maxSP), spScale.y);
            playerMovement.speed = 5f;
        }
        else if(currentSP >= 50)
        {
            spBar.localScale = new Vector2(spScale.x, spScale.y);
            playerMovement.speed = 5f;
        }
    }
}
