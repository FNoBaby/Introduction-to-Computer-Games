using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    TMPro.TextMeshProUGUI healthText;

    Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TMPro.TextMeshProUGUI>();
        playerHealth = FindObjectOfType<Player>().GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth != null)
        {
            healthText.text = playerHealth.GetHealth().ToString();
        } else
        {
            healthText.text = "0";
        }
    }
}
