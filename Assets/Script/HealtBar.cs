using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    [SerializeField] public Image healthBar;
    [SerializeField] public float HealthAmount;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.type = Image.Type.Filled;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        HealthAmount -= damage;
        healthBar.fillAmount = HealthAmount / 100f;
    }

    public void Healing(float Heal)
    {
        HealthAmount += Heal;
        HealthAmount = Mathf.Clamp(HealthAmount, 0, 100);
        healthBar.fillAmount = HealthAmount / 100f;
    }

}
