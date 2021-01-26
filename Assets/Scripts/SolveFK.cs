using UnityEngine;
using UnityEngine.UI;

public class SolveFK : MonoBehaviour
{
    public Slider thetaOne, thetaTwo;
    public GameObject[] arms = new GameObject[2];
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Forward Kinematics


        arms[0].transform.localRotation = Quaternion.Euler(new Vector3(0f, thetaOne.value, 0f));
        arms[1].transform.localRotation = Quaternion.Euler(new Vector3(0f, thetaTwo.value, 0f));
    }
}
