using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stats : MonoBehaviour
{
    public float life=0;
    public float velocity =0;
    public float damage =0;
    public string nameS="";
    public Action<float> uddateLife;

    public virtual void UpdateLife(float damage)
    {
        life += damage;
    }
    public virtual void UpdateStats(float damage)
    {

    }
    public virtual void Movement( float velocity)
    {
        
    }
}
