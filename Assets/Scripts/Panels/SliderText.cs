using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    public Text slidertext;
    public ExpeditionDialog expDialog;
    public GameMaster gamemaster;
    public Slider slider;
        
         
    void Start()
    {
        slidertext.text = "Ants amount: " + expDialog.antAmount.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
