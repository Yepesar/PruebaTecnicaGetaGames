using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.AI;
using KartGame.KartSystems;

public enum DifficultyProfile { Beginner, Veteran , Expert }
public class AIDifficulty : MonoBehaviour
{
    [SerializeField] private DifficultyProfile difficulty;
    [SerializeField] private Transform tracks;
    [SerializeField] private KartAgent agent;
    [SerializeField] private ArcadeKart kartController;

    private Transform selectedTrack;
    private float veteranSpeedAdition = 0.5f;
    private float veteranAccelAdition = 0.5f;

    private float expertAccelAdition = 1f;
    private float expertSpeedAdition = 1f;

    // Start is called before the first frame update
    void Start()
    {
        SelectTrack();
        ScaleStats();
    }

    private void ScaleStats()
    {
        if (kartController)
        {
            if (difficulty == DifficultyProfile.Veteran)
            {
                kartController.baseStats.TopSpeed += veteranSpeedAdition;
                kartController.baseStats.Acceleration += veteranAccelAdition;
            }
            else if (difficulty == DifficultyProfile.Expert)
            {
                kartController.baseStats.TopSpeed += expertSpeedAdition;
                kartController.baseStats.Acceleration += expertAccelAdition;
            }
        }
    }

    private void SelectTrack()
    {
        if (difficulty == DifficultyProfile.Beginner)
        {
            selectedTrack = tracks.GetChild(0);
        }
        else if (difficulty == DifficultyProfile.Veteran)
        {
            selectedTrack = tracks.GetChild(1);
        }
        else if (difficulty == DifficultyProfile.Expert)
        {
            selectedTrack = tracks.GetChild(2);
        }

        if (selectedTrack)
        {
            agent.Colliders = new Collider[selectedTrack.childCount];

            for (int i = 0; i < agent.Colliders.Length; i++)
            {
                agent.Colliders[i] = selectedTrack.GetChild(i).gameObject.GetComponent<SphereCollider>();
            }
        }
    }
}
