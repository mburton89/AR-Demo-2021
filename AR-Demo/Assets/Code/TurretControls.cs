using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretControls : MonoBehaviour
{
    public Turret p1Turret;
    public Turret p2Turret;
    public Turret activeTurret;

    public Slider spin;
    public Slider upDown;
    public Button shoot;

    void Start()
    {
        spin.onValueChanged.AddListener(HandleSpinSlider);
        upDown.onValueChanged.AddListener(HandleUpDownSlider);
        shoot.onClick.AddListener(HandleShootPressed);
    }

    private void Update()
    {
        if (activeTurret == null && FindObjectOfType<Turret>() != null)
        {
            activeTurret = FindObjectOfType<Turret>();
        }
    }

    void HandleSpinSlider(float f)
    {
        activeTurret.SetYRotation(f);
    }

    void HandleUpDownSlider(float f)
    {
        activeTurret.SetZRotation(f);
    }

    void HandleShootPressed()
    {
        activeTurret.Shoot();
    }
}
