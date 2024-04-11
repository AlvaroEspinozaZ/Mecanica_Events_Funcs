using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyController : Stats
{
    [SerializeField] Rigidbody myrgb;
    public Action<PlayerController> verPlayer;
    public Action<PlayerController> AtacarPlayer;
    private void Awake()
    {
        verPlayer = verPlayerEnJuego;
        AtacarPlayer = Atacando;
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
        
    }
    public override void Movement(float velocity)
    {
        Patrullaje();
    }
    public override void UpdateLife(float damage)
    {
        base.UpdateLife(damage);
    }
    public override void UpdateStats(float damage)
    {
        base.Movement(damage);
    }
    void Patrullaje()
    {
        Debug.Log("Estoy patrullando");
    }
    void verPlayerEnJuego(PlayerController player)
    {
        Debug.Log("Te vi mano");
        myrgb.velocity = (transform.position - player.transform.position).normalized * velocity;
    }
    void Atacando(PlayerController player)
    {
        Debug.Log("Animcaion de ataque ");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            verPlayer?.Invoke(other.gameObject.GetComponent<PlayerController>());
            uddateLife?.Invoke(other.gameObject.GetComponent<Stats>().damage);
            AtacarPlayer?.Invoke(other.gameObject.GetComponent<PlayerController>());
        }

    }
}
