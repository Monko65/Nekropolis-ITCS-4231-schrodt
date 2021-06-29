using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthHandler : MonoBehaviour
{
    public Image HUDImage;
    private float HealthValue;
    // Start is called before the first frame update
    void Start()
    {
        HealthValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        HealthValue = GetComponent<HealthSystem>().getHealth() / GetComponent<HealthSystem>().getMaxHealth();
        HUDImage.fillAmount = HealthValue;
    }
}
