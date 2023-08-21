using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carproperties : MonoBehaviour
{
    public float fuel;
    private const float maxfuel= 100.0f;
    public float initial_fuel_consumption;
    [SerializeField]

    public uiManager ui;
    public GameManager GM;
    
    // Start is called before the first frame update
    void Start()
    {
        fuel = maxfuel;
        StartCoroutine(fuelconsumption(initial_fuel_consumption));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator fuelconsumption(float consumption_rate_per_second)
    {
        while(!GameManager.Gameover)
        {
            yield return new WaitForSeconds(1);
            fuel -= consumption_rate_per_second;
            ui.UpdatefuelBarUI(fuel,maxfuel);
            if (fuel <= 0)
            { GM.setGameover(); }
        }
    }

   

}
