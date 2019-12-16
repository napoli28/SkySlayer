using UnityEngine;

public class Engine : MonoBehaviour
{
    public float maxPower = 2;
    public float acceleration = 0.02f;
    public bool on;
    public float currentPower = 0;
    float powerControl;
    public float PowerControl
    {
        get { return powerControl; }
        set { powerControl = Mathf.Clamp01(powerControl += value); }
    }

    float deltaTime;

    private void Update()
    {
        deltaTime = Time.deltaTime;
        if (on)
        {
            Boot();
        }
        else
        {
            if (currentPower > 0.01)
            {
                currentPower = Mathf.Lerp(currentPower, 0f, 10f * deltaTime);
            }
            else
            {
                currentPower = 0;
            }
        }
    }
    public void Boot()
    {
        currentPower = Mathf.Lerp(currentPower, maxPower * powerControl, 5f * deltaTime);
    }

    public void TurnOn()
    {
        on = true;
    }

    public void TurnOff()
    {
        on = false;
    }
}