using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewKartStatistic", menuName = "Create new kart statistic")]
public class SO_KartStatistics : ScriptableObject
{
    [Header("Movement Settings")]
    [Tooltip("The maximum speed forwards")]
    public float TopSpeed = 10f;

    [Tooltip("How quickly the Kart reaches top speed.")]
    public float Acceleration = 5f;

    [Tooltip("The maximum speed backward.")]
    public float ReverseSpeed = 5f;

    [Tooltip("The rate at which the kart increases its backward speed.")]
    public float ReverseAcceleration = 5f;

    [Tooltip("How quickly the Kart starts accelerating from 0. A higher number means it accelerates faster sooner.")]
    [Range(0.2f, 10)]
    public float AccelerationCurve = 4f;

    [Tooltip("How quickly the Kart slows down when going in the opposite direction.")]
    public float Braking = 10f;

    [Tooltip("How quickly to slow down when neither acceleration or reverse is held.")]
    public float CoastingDrag = 4f;

    [Range(0, 1)]
    [Tooltip("The amount of side-to-side friction.")]
    public float Grip = 0.95f;

    [Tooltip("How quickly the Kart can turn left and right.")]
    public float Steer = 5f;

    [Tooltip("Additional gravity for when the Kart is in the air.")]
    public float AddedGravity = 1f;

    [Tooltip("How much the Kart tries to keep going forward when on bumpy terrain.")]
    [Range(0, 1)]
    public float Suspension = 0.2f;
}
