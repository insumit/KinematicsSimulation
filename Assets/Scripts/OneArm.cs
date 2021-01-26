using UnityEngine;
using UnityEngine.UI;

public class OneArm : MonoBehaviour
{
    public Slider thetaOne;

    public GameObject Arm;

    void Start()
    {

    }

    void Update()
    { 
        Arm.transform.localRotation = Quaternion.Euler(new Vector3(0f, thetaOne.value , 0f ));
    }

}
