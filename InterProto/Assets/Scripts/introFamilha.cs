using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introFamilha : MonoBehaviour {

    int Imagem;

    public GameObject Imagem01, Imagem02, Imagem03, Imagem04,Fade,Botao1,Botao2;

    public void ButtonNext()
    {
        Imagem++;
        Invoke("ChangeImage", 0.7f);
        Instantiate(Fade);
    }

    void ChangeImage()
    {
        if(Imagem == 0)
        {
            Imagem01.SetActive(true);
            Imagem02.SetActive(false);
            Imagem03.SetActive(false);
            Imagem04.SetActive(false);
        }
        else
        if (Imagem == 1)
        {
            Imagem01.SetActive(false);
            Imagem02.SetActive(true);
            Imagem03.SetActive(false);
            Imagem04.SetActive(false);
        }
        else
        if (Imagem == 2)
        {
            Imagem01.SetActive(false);
            Imagem02.SetActive(false);
            Imagem03.SetActive(true);
            Imagem04.SetActive(false);
        }
        else
        if (Imagem == 3)
        {
            Imagem01.SetActive(false);
            Imagem02.SetActive(false);
            Imagem03.SetActive(false);
            Imagem04.SetActive(true);
        }
        else
        if (Imagem == 4)
        {
            SceneManager.LoadScene("CenaInterna");
            Botao1.SetActive(false);
            Botao2.SetActive(false);
        }
    }
}
