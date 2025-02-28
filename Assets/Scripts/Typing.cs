using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
[AddComponentMenu("LHS/Typing")]
public class Typing : MonoBehaviour
{
    public TextMeshProUGUI intro;
    //public GameObject startbutton;
    [SerializeField][TextArea] private string context;
    [SerializeField] private float delay = 0.2f;
    public GameObject mouse;
    private bool mouseLeftright = true;
    float rotatingangle = 1.0f;

    void Start()
    {
        StartCoroutine(Type());
        //StartCoroutine(MiceMoving());
    }
    private void Update()
    {
        //mouse.transform.eulerAngles = new Vector3(0, 0, rotatingangle);
    }

    IEnumerator Type()
    {
        intro.text = "";
        int intro_count = 0;
        while (intro_count != context.Length)
        {
            if (intro_count < context.Length)
            {
                intro.text += context[intro_count].ToString();
                intro_count++;
            }
            yield return new WaitForSeconds(delay);
        }
        SceneManager.LoadScene("SampleScene");

        //startbutton.SetActive(true);
    }

}
