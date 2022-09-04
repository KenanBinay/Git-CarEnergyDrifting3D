using UnityEngine ;
using UnityEngine.Events ;
using UnityEngine.EventSystems ;
using UnityEngine.UI ;

public class ButtonDoubleClickListener : MonoBehaviour
{

    [Tooltip("Max duration between 2 clicks in seconds")]
    [Range(0.01f, 0.5f)] public float doubleClickDuration = 0.4f;

    private byte clicks = 0;
    private float elapsedTime = 0f;
    public static bool doubleClick;

    private void Awake()
    {
        doubleClick = false;
    }

    private void Update()
    {
        if (clicks == 1)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > doubleClickDuration)
            {
                clicks = 0;
                elapsedTime = 0f;
                doubleClick = false;
            }
        }
    }

    public void OnDoubleClick()
    {
        clicks++;

        if (clicks == 1)
            elapsedTime = 0f;
        else if (clicks > 1)
        {
            if (elapsedTime <= doubleClickDuration)
            {
                clicks = 0;
                elapsedTime = 0f;
                doubleClick = true;
            }
        }
    }

}
