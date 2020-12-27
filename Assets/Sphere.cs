using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    // Start is called before the first frame update
    protected Joystick joystick;
    protected FixedJoybutton fixedJoybutton;


    protected bool jump;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        fixedJoybutton = FindObjectOfType<FixedJoybutton>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * 100F,
                                rigidbody.velocity.y,
                                joystick.Vertical * 100F);

        if(!jump && fixedJoybutton.IsPressed() ){
            jump = true;
            rigidbody.velocity += Vector3.up * 10F;
        }

        if (jump && !fixedJoybutton.IsPressed()) {
            jump = false;
        }
    }
}
