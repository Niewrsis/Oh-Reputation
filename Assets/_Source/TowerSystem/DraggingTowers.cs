using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TowerSystem
{
    public class DraggingTowers : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private GameObject towerPrefab;
        [SerializeField] private LayerMask groundMask;

        private GameObject _towerObj;
        private bool _isDragging;
        private RectTransform _canvasRect;
        private Tower _tower;
        private TowerShoot _towerShoot;

        void Start()
        {
            _canvasRect = FindAnyObjectByType<Canvas>().GetComponent<RectTransform>();
            _tower = towerPrefab.GetComponent<Tower>();
            _towerShoot = towerPrefab.GetComponent<TowerShoot>();
            _towerShoot.enabled = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_towerObj != null) return;

            _towerObj = Instantiate(towerPrefab, GetLocalPosition(), Quaternion.identity);
            _towerObj.transform.SetParent(transform.parent.parent);
            _isDragging = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_towerObj != null)
            {
                
                if(_tower.Cost > LevelManager.Instance.GetCurrency())
                {
                    Debug.LogWarning("Not enough money to place");
                }
                else
                {
                    //if(!CheckGroundLayer())
                    //{
                    //    Debug.LogWarning("You cannot place it here");
                    //}
                    //else
                    //{
                        GameObject newTower = Instantiate(towerPrefab, _towerObj.transform.position, Quaternion.identity);
                        newTower.GetComponent<TowerShoot>().enabled = true;
                        LevelManager.Instance.RemoveCurrency(_tower.Cost);
                    //}
                }
                Destroy(_towerObj);
                _towerObj = null;
            }
            _isDragging = false;
        }

        void Update()
        {
            if (_isDragging)
            {
                if (_towerObj != null)
                {
                    _towerObj.transform.localPosition = GetLocalPosition();
                }
            }
        }
        private Vector2 GetLocalPosition()
        {
            return _canvasRect.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        //TODO: Improve this system!

        /*private bool CheckGroundLayer()
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, new Vector2(.01f, .01f), .01f, groundMask);
            if (ray.collider != null)
            {
                Debug.Log(ray.collider.name);
                return true;
            }
            else
            {
                return false;
            }
        }*/
    }
}