using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public string planetName = "Earth";
    public string description;

    [SerializeField] private float inclineDegrees = 23.4f;
    [SerializeField] private float rotationPeriodHours = 24f;
    [SerializeField] private Transform incline;
    [SerializeField] private Transform planet;
    public float animationHoursPerSecond = 1.0f;

    void Start()
    {
        incline.Rotate(0f, 0f, inclineDegrees);
    }

    void Update()
    {
        float speed = rotationPeriodHours * animationHoursPerSecond;
        planet.Rotate(0f, speed * Time.deltaTime, 0f);
    }
}
