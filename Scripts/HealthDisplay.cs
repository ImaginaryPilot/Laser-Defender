using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text HealthText;
    Movement Player;
    // Start is called before the first frame update
    void Start()
    {
        HealthText = GetComponent<Text>();
        Player = FindObjectOfType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = Player.health.ToString();
    }
}
