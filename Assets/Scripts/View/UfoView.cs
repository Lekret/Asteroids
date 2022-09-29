﻿using Model.Obstacles;
using UnityEngine;

namespace View
{
    public class UfoView : MonoBehaviour
    {
        [SerializeField] private PositionView _positionView;
        [SerializeField] private DestroyableView _destroyableView;
        
        private IUfo _ufo;
        
        public void Init(IUfo ufo)
        {
            _ufo = ufo;
            _positionView.Init(ufo);
            _destroyableView.Init(ufo);
        }
        
        private void Update()
        {
            _ufo.Update(Time.deltaTime);
        }
    }
}