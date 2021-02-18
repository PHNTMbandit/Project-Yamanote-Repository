//using System;
//using System.Collections.Generic;
//using ProjectYamanote.Station;
//using UnityEngine;

//namespace ProjectYamanote.Train
//{
//    public class InstantiateTrain : MonoBehaviour
//    {
//        public static InstantiateTrain instance;


//        private Transform _arrivalPosition;
//        private Transform _instantiatePosition;
//        private Transform _despawnPosition;

//        private void Awake()
//        {
//            _arrivalPosition = _station._arrivalPosition;
//            _instantiatePosition = _station._instantiatePosition;
//            _despawnPosition = _station._despawnPosition;

//            if (instance == null)
//                instance = this;
//            else
//            {
//                Destroy(gameObject);
//            }

//            DontDestroyOnLoad(gameObject);
//        }

//        public void LeaveTrain(string trainLine)
//        {
//            switch (trainLine)
//            {
//                case "Tsugaru Line":
//                    Instantiate()
//                    break;
//            }
//        }
//    }
//}
