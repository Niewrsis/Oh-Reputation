using Core;
using TowerSystem.View;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerSystem
{
    [RequireComponent(typeof(TowerIcon))]
    public class DraggingTowers : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private TowerSO tower;

        private GameObject _towerObj;
        private bool _isDragging;
        private TowerIcon _towerIcon;

        void Start()
        {
            if (tower == null)
            {
                this.enabled = false;
                return;
            }
            tower.CurrentCount = 0;

            _towerIcon = GetComponent<TowerIcon>();

            _towerIcon.Construct(tower);

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (tower == null) return;
            if (_towerObj != null) return;

            _towerObj = Instantiate(tower.Prefab, GetLocalPosition(), Quaternion.identity);
            _isDragging = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (tower == null) return;
            if (_towerObj == null)
            {
                Destroy(_towerObj);
                _towerObj = null;
                _isDragging = false;
                return;
            }

                if (tower.BaseCost > LevelManager.Instance.GetCurrency())
            {
                Debug.LogWarning("Not enough money to place");
                Destroy(_towerObj);
                _towerObj = null;
                _isDragging = false;
                return;
            }
            if(tower.TryAddOneTower() == true)
            {
                GameObject newTower = Instantiate(tower.Prefab, _towerObj.transform.position, Quaternion.identity);
                newTower.GetComponent<TowerShoot>().enabled = true;
                LevelManager.Instance.RemoveCurrency(tower.BaseCost);
            }

            Destroy(_towerObj);
            _towerObj = null;
            _isDragging = false;
        }

        void Update()
        {
            if (tower == null) return;
                if (_isDragging)
            {
                if (_towerObj != null)
                {
                    _towerObj.transform.localPosition = GetLocalPosition();
                }
            }
        }
        private Vector3 GetLocalPosition()
        {
            Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return new Vector3(vec.x, vec.y, 0);
        }

        private bool CheckGroundLayer()
        {
            Debug.Log(GetLocalPosition());
            RaycastHit2D ray = Physics2D.Raycast(GetLocalPosition(), new Vector2(.01f, .01f), .01f, groundMask);
            Debug.Log(ray.collider);
            if (ray.collider.CompareTag("PlaceForSpawn"))
            {
                Debug.Log(ray.collider.name);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}