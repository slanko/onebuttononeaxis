using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class vehicleScript : MonoBehaviour
{
    ParticleSystem bonnetParticles, bloodSplatter;
    Rigidbody rb, rb2;
    Animator anim;
    AudioSource aud, engAud;
    GameObject steeringWheel, orbitalCamera, gameOverText;
    public GameObject splatters;
    public GameObject[] damageObjects;
    Slider healthSlider, speedSlider;
    public KeyCode accelerator, brake, turnleft, turnright;
    public float accelAmount, turnForce, carHealthStart, carHealthCurrent, damageThreshold, medCrashSoundThreshold, bigCrashSoundThreshold, emissionDiv;
    float damageInterval = 600, engineNoiseMin = 1, engineNoiseMax = 3;
    //Text healthText;
    public AudioClip[] smallCrashes, medCrashes, bigCrashes, glassBreakSounds;
    int damageIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        bloodSplatter = GameObject.Find(transform.name + "/Splatter").GetComponent<ParticleSystem>();
        engAud = GameObject.Find(transform.name + "/SteeringCube").GetComponent<AudioSource>();
        bonnetParticles = GameObject.Find(transform.name + "/BonnetSmoke").GetComponent<ParticleSystem>();
        gameOverText = GameObject.Find("Canvas/GameOver");
        orbitalCamera = GameObject.Find("OrbitalCamera/Camera");
        aud = GetComponent<AudioSource>();
        //healthText = GameObject.Find("Canvas/healthText").GetComponent<Text>();
        carHealthCurrent = carHealthStart;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb2 = GameObject.Find(transform.name + "/SteeringCube").GetComponent<Rigidbody>();
        steeringWheel = GameObject.Find(transform.name + "/SteeringWheel");
        healthSlider = GameObject.Find(transform.name + "/Canvas2/Slider").GetComponent<Slider>();
        speedSlider = GameObject.Find(transform.name + "/Canvas2/speedSlider").GetComponent<Slider>(); orbitalCamera.SetActive(false);
        gameOverText.SetActive(false);
        var emission = bonnetParticles.emission;
        emission.rateOverTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //healthText.text = "car health: " + carHealthCurrent.ToString();
        speedSlider.value = transform.InverseTransformDirection(rb.velocity).z * 2f;
        healthSlider.value = Mathf.Lerp(healthSlider.value, carHealthCurrent, 0.05f);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
        if (carHealthCurrent > 0)
        {
            if (Input.GetKey(accelerator))
            {
                engAud.pitch = Mathf.Lerp(engAud.pitch, 3, 0.01f);
                anim.SetBool("accelPressed", true);
                rb.AddForce(transform.forward * accelAmount, ForceMode.Acceleration);
            }
            else
            {
                anim.SetBool("accelPressed", false);
            }
            if (Input.GetKey(brake))
            {
                engAud.pitch = Mathf.Lerp(engAud.pitch, 2, 0.01f);
                anim.SetBool("brakePressed", true);
                rb.AddForce(transform.forward * (accelAmount * -1), ForceMode.Acceleration);
            }
            else
            {
                anim.SetBool("brakePressed", false);
            }
            if(Input.GetKey(accelerator) == false && Input.GetKey(brake) == false)
            {
                engAud.pitch = Mathf.Lerp(engAud.pitch, 1, 0.005f);
            }
            if (Input.GetKey(turnleft))
            {
                rb2.AddForce((transform.right * -1) * turnForce, ForceMode.Acceleration);
                steeringWheel.transform.Rotate(0, -2, 0);
            }
            if (Input.GetKey(turnright))
            {
                steeringWheel.transform.Rotate(0, 2, 0);
                rb2.AddForce(transform.right * turnForce, ForceMode.Acceleration);
            }
        }
        else
        {
            carDie();
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.relativeVelocity.magnitude > damageThreshold)
        {

            if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Deer")
            {
                carHealthCurrent = carHealthCurrent - other.relativeVelocity.magnitude;
                print("crash magnitude: " + other.relativeVelocity.magnitude);
                var emission = bonnetParticles.emission;
                emission.rateOverTime = (carHealthStart - carHealthCurrent) / emissionDiv;
                if(carHealthCurrent < damageInterval)
                {
                    nextDamageObject();
                }
                //sound stuff
                if (other.relativeVelocity.magnitude < medCrashSoundThreshold)
                {
                    aud.PlayOneShot(smallCrashes[Random.Range(0, smallCrashes.Length)]);
                }
                else
                {
                    if (other.relativeVelocity.magnitude < bigCrashSoundThreshold)
                    {
                        aud.PlayOneShot(smallCrashes[Random.Range(0, medCrashes.Length)]);
                    }
                    else
                    {
                        aud.PlayOneShot(bigCrashes[Random.Range(0, bigCrashes.Length)]);
                    }
                }
            }
        }
        if(other.relativeVelocity.magnitude >= 20 && other.gameObject.tag == "Deer")
        {
            splatters.SetActive(true);
            bloodSplatter.Play();
        }
    }

    void carDie()
    {
        orbitalCamera.SetActive(true);
        gameOverText.SetActive(true);
        engAud.Pause();
    }

    void nextDamageObject()
    {
        damageObjects[damageIndex].SetActive(true);
        damageInterval = damageInterval - 100;
    }
}

