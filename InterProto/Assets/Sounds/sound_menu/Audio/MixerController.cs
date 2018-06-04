using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{

    public AudioMixer mixerMaster;
    public Slider sliderMaster;
    public Slider sliderMusica;
    public Slider sliderEfeitos;

    float volumeMusica;
    float volumeEfeitos;
    //public AudioMixer mixerMusic;
    //public Slider sliderMusic;

    //public AudioMixer mixerSFX;
    //public Slider sliderSFX;

    //funcao que recebe um float, ela vai controlar o mixer

    public void MasterVolume(float vol)
    {

        mixerMaster.SetFloat("master", vol);
        PlayerPrefs.SetFloat("masterVolume", vol);
        //aqui captura o valor do MusicVolume e ajusta de acordo com o Master de tal modo que o master diminui tudo
        mixerMaster.SetFloat("music", (PlayerPrefs.GetFloat("volumeMusica")+vol));
        mixerMaster.SetFloat("efeitos", (PlayerPrefs.GetFloat("volumeEfeitos") + vol));


        //volumeMusica = PlayerPrefs.SetFloat("music");
        //volumeEfeitos = 

        //sliderMusica.value = (PlayerPrefs.GetFloat("volumeEfeitos") + vol);
        // sliderEfeitos.value = (PlayerPrefs.GetFloat("volumeMusica"));
        sliderMaster.value = PlayerPrefs.GetFloat("masterVolume");
        sliderMusica.value = PlayerPrefs.GetFloat("volumeMusica");
        sliderEfeitos.value = PlayerPrefs.GetFloat("volumeEfeitos");
    }

    public void MusicaVolume(float vol)
    {
        mixerMaster.SetFloat("music", vol);
        PlayerPrefs.SetFloat("volumeMusica", vol);
        
    }

    public void EfeitoscVolume(float vol)
    {
        mixerMaster.SetFloat("efeitos", vol);
        PlayerPrefs.SetFloat("volumeEfeitos", vol);
    }

    // Use this for initialization
    void Start()
    {

        /*
        float outvalue_Master;
        mixerMusic.GetFloat ("MVolume", out outvalue_Master);
        sliderMusic.value = outvalue_Master;

        float outvalue_SFX;
        mixerSFX.GetFloat("SFXVolume", out outvalue_SFX);
        sliderSFX.value = outvalue_SFX;
        */

        sliderMaster.value = PlayerPrefs.GetFloat("masterVolume");
        sliderMusica.value = PlayerPrefs.GetFloat("volumeMusica");
        sliderEfeitos.value = PlayerPrefs.GetFloat("volumeEfeitos");
    }

    public void SomSalvarDadosVolume() {
        //aqui quando entra no menu volume ele salva
        PlayerPrefs.SetFloat("masterVolumeMemoria", PlayerPrefs.GetFloat("masterVolume")) ;
        PlayerPrefs.SetFloat("volumeMusicaMemoria", PlayerPrefs.GetFloat("volumeMusica"));
        PlayerPrefs.SetFloat("volumeEfeitosMemoria", PlayerPrefs.GetFloat("volumeEfeitos"));

    }
    public void CancelarCarregarDadosVolume()
    {
        //usa no cancelar
        PlayerPrefs.SetFloat("masterVolume", PlayerPrefs.GetFloat("masterVolumeMemoria"));
        PlayerPrefs.SetFloat("volumeMusica", PlayerPrefs.GetFloat("volumeMusicaMemoria"));
        PlayerPrefs.SetFloat("volumeEfeitos", PlayerPrefs.GetFloat("volumeEfeitosMemoria"));
        sliderMaster.value = PlayerPrefs.GetFloat("masterVolume");
        sliderMusica.value = PlayerPrefs.GetFloat("volumeMusica");
        sliderEfeitos.value = PlayerPrefs.GetFloat("volumeEfeitos");
    }

}
