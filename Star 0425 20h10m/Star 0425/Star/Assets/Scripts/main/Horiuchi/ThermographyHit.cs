using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermographyHit : MonoBehaviour
{
    public bool isThermography, thermographyHitNow;

    public GameObject littlePlanetOriginal;
    public GameObject planetHit;
    public GameObject effectObject;
    private PlanetHit hit;
    public int split;

    private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0,2) == 0)
        {
            isThermography = true;
            particle = effectObject.GetComponent<ParticleSystem>();
        }
        else
        {
            isThermography = false;
        }
        thermographyHitNow = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Thermography")
        {
            if (isThermography && !particle.isPlaying)
            {
                thermographyHitNow = true;
                particle.Play();
            }
        }
        if (other.gameObject.tag == "Player" && thermographyHitNow)
        {
            hit = planetHit.GetComponent<PlanetHit>();
            hit.littlePlanetOriginal = littlePlanetOriginal;
            hit.transform.position = gameObject.transform.position;
            hit.littlePlanet = new GameObject[split];
            hit.BurstPlanet();
            Destroy(gameObject);
        }
    }
}
//