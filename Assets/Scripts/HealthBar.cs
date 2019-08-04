using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    Image healthBar;
    float healthRate;//比例
    public AI ai;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthRate = ai.GetHealthRate();
        healthBar.fillAmount = healthRate;
    }
}
