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

        private GameObject _towerObj;
        private bool _isDragging;
        private RectTransform _canvasRect;

        void Start()
        {
            _canvasRect = FindAnyObjectByType<Canvas>().GetComponent<RectTransform>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("PointerDown");
            if (_towerObj != null) return;

            Vector2 localPoint = _canvasRect.InverseTransformPoint(Camera.main.ScreenToWorldPoint(eventData.position));
            _towerObj = Instantiate(towerPrefab, localPoint, Quaternion.identity);
            _towerObj.transform.SetParent(transform.parent.parent);
            _isDragging = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("PointerUp");
            if (_towerObj != null)
            {
                GameObject newTower = Instantiate(towerPrefab, _towerObj.transform.position, Quaternion.identity);
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
                    Vector2 localPoint = _canvasRect.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    _towerObj.transform.localPosition = localPoint;
                }
            }
        }
    }
}