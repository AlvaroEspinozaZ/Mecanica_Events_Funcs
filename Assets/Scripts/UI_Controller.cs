
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class UI_Controller : MonoBehaviour
{
    [SerializeField] List<Stats> chararactersInMap;
    public static Action<Stats> setPersonalUI;
    [SerializeField] GameObject cas;
    [SerializeField] Slider barraVidaPrefab;
    [SerializeField] Text vidaPrefab;
    private void Awake()
    {
        setPersonalUI = DibujarVida;
    }   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void DibujarVida(Stats charactes)
    {
        chararactersInMap.Add(charactes);
        foreach(Stats characters in chararactersInMap)
        {
            GameObject canvas= Instantiate(cas, characters.transform.position, Quaternion.identity, characters.transform);
            Slider de=  Instantiate(barraVidaPrefab, characters.transform.position, Quaternion.identity, canvas.transform);
            de.value = characters.life / 100;
            Text txt= Instantiate(vidaPrefab, characters.transform.position, Quaternion.identity, canvas.transform);
            txt.text = " " + characters.life;
        }
    }
}
