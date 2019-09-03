using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastButtonToggle : MonoBehaviour {

    public GameObject ToggleThisObject;
    public bool OnlyToggleOnce;
    public bool ChangeColorOnToggle;
    public Color color1 = Color.white, color2 = Color.red; 

    private MeshRenderer _thisMeshRenderer;
    private int colorindex = 0;
    private bool _once;


    private void Awake()
    {
        _thisMeshRenderer = GetComponent<MeshRenderer>();

        if (_thisMeshRenderer != null)
        {
            _thisMeshRenderer.material.color = color1;
        }
    }

    // Update is called once per frame
    public void ToggleObject()
    {
        if (_once == false)
        {
            if(OnlyToggleOnce)
            {
                _once = true;
            }
            if (ChangeColorOnToggle)
            {
                if (colorindex == 0)
                {
                    colorindex = 1;
                    if (_thisMeshRenderer != null)
                    {
                        _thisMeshRenderer.material.color = color2;
                    }
                }
                else
                {
                    colorindex = 0;
                    if (_thisMeshRenderer != null)
                    {
                        _thisMeshRenderer.material.color = color1;
                    }
                }


            }

            ToggleThisObject.SetActive(!ToggleThisObject.activeSelf);


        }
    }
}
