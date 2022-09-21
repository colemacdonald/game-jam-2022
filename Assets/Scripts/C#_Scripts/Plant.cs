using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantType {
    Cattail,
    Mushroom,

}

public class Plant : MonoBehaviour
{
    [SerializeField]
    private PlantType m_plantType;

    /*
        Plant will propogate a child every duration 
    */
    [SerializeField]
    private int m_propogationPeriodS = 60;
    
    /**
        Plant health will decrease every period
    */
    [SerializeField]
    private int m_deteriorationPeriodS = 30;

    /*
        Hydration amount and nutrition amount will decrease by this amount per period
    */
    [SerializeField]
    private int m_deteriorationAmount = 10;

    /*
        Plants impact on water level
    */
    [SerializeField]
    private int m_waterLevelImpact = 0;

    public int WaterLevelImpact {
        get => m_waterLevelImpact;
    }

    /*
        Plants impact on plastic waste
    */
    private int m_plasticLevelImpact = 0;

    /*
        Plants ability to absorb water when watered
    */
    [SerializeField]
    private int m_hydrationAmount = 10;

    /*
        Plants ability to absorb nutrients when fertalized
    */
    [SerializeField]
    private int m_nutrientAbsorbtionAmount = 10;

    public int PlantHealth {
        get => (HydrationLevel + NutritionLevel) / 2;
    }

    private int m_hydrationLevel;
    public int HydrationLevel {
        get => m_hydrationLevel;
    }

    private int m_nutritionLevel;
    public int NutritionLevel {
        get => m_nutritionLevel;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Deteriorate() {
        m_hydrationLevel -= m_deteriorationAmount;
        m_nutritionLevel -= m_deteriorationAmount;
    }

    public void Water() {
        m_hydrationLevel += m_hydrationAmount;
    }

    public void Fertalize() {
        m_nutritionLevel += m_nutrientAbsorbtionAmount;
    }

}
