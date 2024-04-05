using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.CLS6
{


    public class UIPlayerIcon : MonoBehaviour
    {
        public GameObject _ic01;
        public GameObject _ic02;
        public GameObject _ic03;


        private void Awake()
        {
            HideAll();
        }

        private void HideAll()
        {
            _ic01.SetActive(false);
            _ic02.SetActive(false);
            _ic03.SetActive(false);
        }



        public void SetIcon(IconType type)
        {
            HideAll();

            switch (type)
            {
                case IconType.BU:
                    _ic01.SetActive(true);
                    break;
                case IconType.JD:
                    _ic02.SetActive(true);
                    break;
                case IconType.ST:
                    _ic03.SetActive(true);
                    break;
            }
        }
    }
}