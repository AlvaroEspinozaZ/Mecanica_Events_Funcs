using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : Stats
{
    [SerializeField] Rigidbody myrgb;
    public bool puedoStonear;
    public int  countCanStun = 0;
    public float alturaDeStun=0;
    public Action<Rigidbody> Stun;
    public Action<PlayerController> Attackenemy;
    public Func<PlayerController, float> LifeLow;
    float x, y;
    private void Awake()
    {
        uddateLife = UpdateLife;
        Attackenemy = AumentarStats;
        Stun = MetodoDeStonear;
    }
    private void OnEnable()
    {
        
        UI_Controller.setPersonalUI?.Invoke(this);
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        Movement(velocity);
    }
    void AumentarStats(PlayerController pc)
    {
        Debug.Log("Aumetar DAÑO");
        pc.damage += 1;
    }
    public override void Movement(float velocity)
    {
        Vector3 direction = new Vector3(x,0,y);
        myrgb.velocity = direction * velocity;
    }
    public override void UpdateLife(float damage)
    {
        base.UpdateLife(damage);
    }
    public override void UpdateStats(float damage)
    {
        base.Movement(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            countCanStun = (countCanStun+1)%3;
            Debug.Log(countCanStun);
            Attackenemy?.Invoke(this);
            uddateLife?.Invoke(other.gameObject.GetComponent<Stats>().damage);
            if (countCanStun == 0)
            {
                Stun?.Invoke(other.gameObject.GetComponent<Rigidbody>());
            }
        }
        
    }
    void MetodoDeStonear(Rigidbody rgbVictima)
    {
        Debug.Log("Vuela cochino" + rgbVictima.gameObject.name);
        rgbVictima.AddForce(Vector3.up * alturaDeStun, ForceMode.Impulse);
       
    }
}
