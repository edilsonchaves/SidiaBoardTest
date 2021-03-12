using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]GameObject menuCanvas;
    [SerializeField]GameObject optionsCanvas;


    public void StartButton()
    {
        SceneManager.LoadScene("ChooseCharacterScene");
    }
    public void OptionsButton()
    {
        menuCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }
    public void VoltarMenuButton()
    {
        ManagerGame.Instance.HeigthValue= optionsCanvas.GetComponent<OptionCanvas>().GetValueHeight();
        ManagerGame.Instance.WidthValue = optionsCanvas.GetComponent<OptionCanvas>().GetValueWidth();
        menuCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
