using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Homework
{
    public class CLS9Main: MonoBehaviour
    {

        public Button _btnMusic1;
        public Button _btnMusic2;
        public Button _btnSFX1;
        public Button _btnPlay;
        public Button _btnStop;
        public Button _btnPinch;


        public AudioSource _music1;
        public AudioSource _music2;
        public AudioSource _sfx1;
        public AudioMixer _mixer;

        private AudioSource _currentAudio;

        private void Awake()
        {
            
            _btnMusic1.onClick.AddListener(OnPlayMusic1);
            _btnMusic2.onClick.AddListener(OnPlayMusic2);
            _btnSFX1.onClick.AddListener(OnPlaySFX1);
            
            _btnPlay.onClick.AddListener(OnPlaySound);
            _btnStop.onClick.AddListener(OnStopSound);
            _btnPinch.onClick.AddListener(OnPitchSound);
            
            
            
            
        }



        void OnPlayMusic1()
        {
            _currentAudio = _music1;
            OnPlaySound();
        }
        
        void OnPlayMusic2()
        {
            _currentAudio = _music2;
            OnPlaySound();
        }

        void OnPlaySFX1()
        {
            _currentAudio = _sfx1;
            OnPlaySound();
        }

        void OnPlaySound()
        {
            OnStopSound();
            _currentAudio.Play();
            _currentAudio.pitch = 1f;
        }
        
        void OnStopSound()
        {
            if (_currentAudio != null) _currentAudio.Stop();
        }
        
        void OnPitchSound()
        {
            OnStopSound();
            _currentAudio.Play();
            _currentAudio.pitch = 1.5f;
        }

    }
}