using KartGame.KartSystems;
using UnityEngine;
using UnityEngine.Events;

public enum PowerUpType {Boost,Jumpad, OilPool }
public class ArcadeKartPowerup : MonoBehaviour {

    [SerializeField] private PowerUpType powerUpType;

    public ArcadeKart.StatPowerup boostStats = new ArcadeKart.StatPowerup
    {
        MaxTime = 5,
        TopSpeed = 0,
        JumpForce = 0,
        SteerModifier = 0
    };

    public bool isCoolingDown { get; private set; }
    public float lastActivatedTimestamp { get; private set; }

    public float cooldown = 5f;

    public bool disableGameObjectWhenActivated;
    public UnityEvent onPowerupActivated;
    public UnityEvent onPowerupFinishCooldown;

    private void Awake()
    {
        lastActivatedTimestamp = -9999f;
    }


    private void Update()
    {
        if (isCoolingDown) { 

            if (Time.time - lastActivatedTimestamp > cooldown) {
                //finished cooldown!
                isCoolingDown = false;
                onPowerupFinishCooldown.Invoke();
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isCoolingDown) return;

        var rb = other.attachedRigidbody;
        if (rb) {

            var kart = rb.GetComponent<ArcadeKart>();

            if (kart)
            { 
                lastActivatedTimestamp = Time.time;
                kart.AddPowerup(this.boostStats);
                onPowerupActivated.Invoke();
                isCoolingDown = true;

                //Boost
                if (powerUpType == PowerUpType.Boost)
                {
                    StartCoroutine(kart.Boost(boostStats.MaxTime, boostStats.TopSpeed));
                }
                //Jumpad
                else if (powerUpType == PowerUpType.Jumpad)
                {
                    rb.AddForce(Vector3.up * boostStats.JumpForce, ForceMode.Impulse);
                }
                //OilPool
                else if (powerUpType == PowerUpType.OilPool)
                {
                    StartCoroutine(kart.SteerChaos(boostStats.MaxTime, boostStats.SteerModifier));
                }

                if (disableGameObjectWhenActivated) this.gameObject.SetActive(false);
            }
        }
    }

}
