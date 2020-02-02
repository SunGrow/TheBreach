using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixableObject : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100;
    public float maxVitaluty = 1;
    public Animator animator;
    public float vitDectement = 1.3f;
    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private LevelManager levelManager;


    private float m_CurrHealth;
    private float m_CurrVitality;

    void Start()
    {
        m_CurrHealth = maxHealth;
        m_CurrVitality = maxVitaluty;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_CurrHealth -= 1f * Time.fixedDeltaTime / m_CurrVitality;
        if (m_CurrHealth < 0.00001)
        {
            Break();
        }
        healthBar.SetSize(m_CurrHealth/maxHealth);
    }

    void Break()
    {
        Debug.Log("Barrel Broke");
        animator.SetBool("Broke", true);
        healthBar.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        levelManager.ReloadScene();
        this.enabled = false;
    }

    public void Repair()
    {
        m_CurrHealth = maxHealth;
        if(m_CurrVitality > 0.001)
            m_CurrVitality /= vitDectement;
        animator.SetTrigger("IsFixed");
    }
}
