/*** 
 * @Author: NickPansh
 * @Date: 2023-03-23 12:55:28
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-03-23 17:41:46
 * @FilePath: \Unity-Design-Pattern\Assets\GameProgrammingPatterns\8.DoubleBuffer\Scripts\BadCodeExample\BadMapGenerator.cs
 * @Description: 这一段代码基于：https://github.com/SebLague/Procedural-Cave-Generation/blob/master/Episode%2001/MapGenerator.cs
 * @Description: 在原始工程里，它用于生成一个程序化的洞穴，它能工作但是存在bug：未处理的单元格将访问了已处理单元格的当前前状态。这会导致地图出现强烈的对角线偏差。
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
namespace WenQu.DoubleBuffer.BadCodeExample
{
    public class BadMapGenerator : MonoBehaviour
    {
        public static float STEP_DURATION = 0.5f;
        public int width = 20;
        public int height = 20;

        public string seed;

        public int smoothStep = 5;
        public bool useRandomSeed;
        public RawImage rawImage;

        [Range(0, 100)]
        public int randomFillPercent;

        private int[,] map;

        private Texture2D _texture;
        private Coroutine _smoothMapCoroutine;
        private string _imgPath;
        void Start()
        {
            map = new int[width, height];
            _texture = new Texture2D(width, height);
            _imgPath = Application.dataPath + "/GameProgrammingPatterns/8.DoubleBuffer/Res/Textures/Map.png";
            GenerateMap();
        }

        void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                GenerateMap();
            }
        }
        private void ClearMap()
        {
            if (width != map.GetLength(0) || height != map.GetLength(1))
            {
                map = new int[width, height];
            }
            else
            {
                // 清空map
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        map[x, y] = 0;
                    }
                }
            }

        }
        void GenerateMap()
        {
            ClearMap();
            RandomFillMap();

            if (_smoothMapCoroutine != null)
                StopCoroutine(_smoothMapCoroutine);
            _smoothMapCoroutine = StartCoroutine(SmoothMap());

        }


        void RandomFillMap()
        {
            if (useRandomSeed)
            {
                seed = Time.time.ToString();
            }

            System.Random pseudoRandom = new System.Random(seed.GetHashCode());

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    {
                        map[x, y] = 1;
                    }
                    else
                    {
                        map[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent) ? 1 : 0;
                    }
                }
            }
        }

        IEnumerator SmoothMap()
        {
            for (int i = 0; i < smoothStep; i++)
            {
                SmoothMapStep();
                UpdateDisplayTexture(map);
                yield return new WaitForSeconds(STEP_DURATION);
            }
            _smoothMapCoroutine = null;
            byte[] bytes = _texture.EncodeToPNG();
            System.IO.File.WriteAllBytes(_imgPath, bytes);
        }

        void SmoothMapStep()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // 检查8方向，如果周围的墙的数量大于4，那么就是墙，否则就是路
                    int neighbourWallTiles = GetSurroundingWallCount(x, y);

                    if (neighbourWallTiles > 4)
                        map[x, y] = 1;
                    else if (neighbourWallTiles < 4)
                        map[x, y] = 0;

                }
            }
        }

        int GetSurroundingWallCount(int gridX, int gridY)
        {
            int wallCount = 0;
            for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
            {
                for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
                {
                    if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height)
                    {
                        if (neighbourX != gridX || neighbourY != gridY)
                        {
                            wallCount += map[neighbourX, neighbourY];
                        }
                    }
                    else
                    {
                        wallCount++;
                    }
                }
            }

            return wallCount;
        }

        // 为了演示每一步的变化，这里手动绘制地图，不用OnDrawGizmos
        // void OnDrawGizmos()
        // {
        //     if (map != null)
        //     {
        //         for (int x = 0; x < width; x++)
        //         {
        //             for (int y = 0; y < height; y++)
        //             {
        //                 Gizmos.color = (map[x, y] == 1) ? Color.red : Color.white;
        //                 Vector3 pos = new Vector3(-width / 2 + x + .5f, 0, -height / 2 + y + .5f);
        //                 Gizmos.DrawCube(pos, Vector3.one);
        //             }
        //         }
        //     }
        // }
        private void UpdateDisplayTexture(int[,] map)
        {

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _texture.SetPixel(x, y, map[x, y] == 1 ? Color.red : Color.white);
                }
            }
            _texture.Apply();
            rawImage.material.mainTexture = _texture;

        }

    }
}