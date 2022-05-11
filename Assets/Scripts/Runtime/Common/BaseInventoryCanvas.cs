using Game.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Common.UI
{
    [Serializable]
    struct InventoryCell
    {
        public Vector2 pos;
        public bool blocked;
    }

    public class BaseInventoryCanvas : MonoBehaviour
    {
        public GameObject InventoryCanvas;

        [SerializeField]
        private RectTransform GridTransform;

        [SerializeField]
        [Min(10.0f)]
        private float CellSize = 10.0f;

        [SerializeField]
        private uint cellsX = 10;
        [SerializeField]
        private uint cellsY = 10;

        [SerializeField]
        private InventoryCell[,] grid;

        private void Start()
        {
            grid = new InventoryCell[cellsX, cellsY];
            GenerateGrid();
        }

        public void RefreshItems(in List<BaseItem> items)
        {
            foreach (Transform t in GridTransform)
            {
                BaseItem item = items.Find(h => h.GetInstanceID() == t.GetComponent<InventoryItem>().uniqueId);
                if (item == null)
                {
                    if (AddToGrid(item) == false)
                    {
                        Debug.Log("hueta");
                    }

                }
            }
        }

        //Генерация массива клеток
        private void GenerateGrid()
        {
            for (uint i = 0; i < cellsX; i++)
            {
                for (uint j = 0; j < cellsY; j++)
                {
                    grid[i, j].blocked = false;
                    grid[i, j].pos = new Vector2(i * CellSize, j * CellSize);
                }
            }
        }

        //Автоматическое добавление item в массив клеток
        private bool AddToGrid(in BaseItem baseItem)
        {
            InventoryItem item = GridTransform.GetChild(0).GetComponent<InventoryItem>();
            item.widthCells = baseItem.widthCells;
            item.heightCells = baseItem.heightCells;
            item.uniqueId = baseItem.GetInstanceID();
            item.GenerateItem(CellSize);

            for (uint i = 0; i < cellsX; i++)
            {
                for (uint j = 0; j < cellsY; j++)
                {
                    bool isUnlockedRect = FindRectUnlocked(i, j, item.widthCells, item.heightCells);
                    if (isUnlockedRect)
                    {
                        FillItem(i, j, item.widthCells, item.heightCells);
                        //Add item
                        GameObject newItem = Instantiate(GridTransform.GetChild(0).gameObject, GridTransform);
                        newItem.GetComponent<RectTransform>().anchoredPosition = grid[i, j].pos;
                        newItem.SetActive(true);
                        return true;
                    }
                }
            }
            return false;
        }

        //Поиск свободного прямоугольника в массиве клеток по позиции в клеточном пространстве
        private bool FindRectUnlocked(uint posx, uint posy, uint widthCells, uint heightCells)
        {
            if (posx < 0 || posy < 0)
            {
                return false;
            }

            if (posx + widthCells <= grid.GetLength(0) && posy + heightCells <= grid.GetLength(1))
            {
                for (uint i = posx; i < posx + widthCells; i++)
                {
                    for (uint j = posy; j < posy + heightCells; j++)
                    {
                        if (grid[i, j].blocked)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        //Поиск свободного прямоугольника в массиве клеток по позиции в пространстве canvas
        public bool FindRectUnlocked(Vector2 pos, uint widthCells, uint heightCells, out Vector2 newPos)
        {
            uint newCellX = (uint)Mathf.Max(Mathf.RoundToInt(pos.x / CellSize), 0);
            uint newCellY = (uint)Mathf.Max(Mathf.RoundToInt(pos.y / CellSize), 0);

            if (FindRectUnlocked(newCellX, newCellY, widthCells, heightCells))
            {
                newPos = new Vector2(newCellX * CellSize, newCellY * CellSize);
                return true;
            }

            newPos = Vector2.zero;
            return false;
        }

        //разблокировка клеток прошлой позиции item и установка блокировки клетов на текущей позиции item
        public void FillItem(Vector2 originalPos, uint widthCells, uint heightCells, Vector2 newPos)
        {
            uint oldCellX = (uint)Mathf.RoundToInt(originalPos.x / CellSize);
            uint oldCellY = (uint)Mathf.RoundToInt(originalPos.y / CellSize);

            for (uint i = oldCellX; i < oldCellX + widthCells; i++)
            {
                for (uint j = oldCellY; j < oldCellY + heightCells; j++)
                {
                    grid[i, j].blocked = false;
                }
            }

            uint newCellX = (uint)Mathf.RoundToInt(newPos.x / CellSize);
            uint newCellY = (uint)Mathf.RoundToInt(newPos.y / CellSize);

            FillItem(newCellX, newCellY, widthCells, heightCells);
        }

        //разблокировка клеток по позиции item
        public void FillItem(Vector2 originalPos, uint widthCells, uint heightCells)
        {
            uint oldCellX = (uint)Mathf.RoundToInt(originalPos.x / CellSize);
            uint oldCellY = (uint)Mathf.RoundToInt(originalPos.y / CellSize);

            for (uint i = oldCellX; i < oldCellX + widthCells; i++)
            {
                for (uint j = oldCellY; j < oldCellY + heightCells; j++)
                {
                    grid[i, j].blocked = false;
                }
            }
        }

        //блокировка клеток item по позции в клеточном пространстве
        private void FillItem(uint posx, uint posy, uint widthCells, uint heightCells)
        {
            for (uint i = posx; i < posx + widthCells; i++)
            {
                for (uint j = posy; j < posy + heightCells; j++)
                {
                    grid[i, j].blocked = true;
                }
            }
        }
    }

}
