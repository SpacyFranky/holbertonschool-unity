using UnityEngine;

public class OpenUrl : MonoBehaviour
{
    public string a;

    public void Open()
    {
        Application.OpenURL(a);
    }
}
