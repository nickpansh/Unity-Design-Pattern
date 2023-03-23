/*** 
 * @Author: NickPansh
 * @Date: 2023-03-23 12:55:28
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-03-23 17:43:47
 * @FilePath: \Unity-Design-Pattern\Assets\GameProgrammingPatterns\8.DoubleBuffer\Scripts\MapGenerator.cs
 * @Description: 这部分代码和灵感参考的是https://github.com/Habrador/Unity-Programming-Patterns
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
namespace WenQu.DoubleBuffer
{
    public class MapGenerator : MonoBehaviour
    {
        public static float STEP_DURATION = 0.1f;
        public int width = 20;
        public int height = 20;

        public string seed;

        public int smoothStep = 5;
        public bool useRandomSeed;


        [Range(0, 100)]
        public int randomFillPercent;

        private int[,] bufferOld;
        private int[,] bufferNew;

        public RawImage rawImage;

        private Coroutine _smoothMapCoroutine;
        private string _imgPath;
        private Texture2D _texture;
        void Start()
        {
            bufferNew = new int[width, height];
            bufferOld = new int[width, height];
            _texture = new Texture2D(width, height);
            _imgPath = Application.dataPath + "/GameProgrammingPatterns/8.DoubleBuffer/Res/Textures/MapGood.png";
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
            if (width != bufferOld.GetLength(0) || height != bufferOld.GetLength(1))
            {
                bufferNew = new int[width, height];
                bufferOld = new int[width, height];
                _texture = new Texture2D(width, height);
            }
            else
            {
                // 清空map
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        bufferOld[x, y] = 0;
                        bufferNew[x, y] = 0;
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
            // 初始化旧的缓存区
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    {
                        bufferOld[x, y] = 1;
                    }
                    else
                    {
                        bufferOld[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent) ? 1 : 0;
                    }
                }
            }
        }

        IEnumerator SmoothMap()
        {
            for (int i = 0; i < smoothStep; i++)
            {
                SmoothMapStep();
                // 用新缓冲区来显示地图
                UpdateDisplayTexture(bufferNew);
                // 这一帧执行完毕，交换缓冲区
                (bufferNew, bufferOld) = (bufferOld, bufferNew);
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
                    // 计算结果写入新缓冲区
                    if (neighbourWallTiles > 4)
                        bufferNew[x, y] = 1;
                    else if (neighbourWallTiles < 4)
                        bufferNew[x, y] = 0;

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
                            // 从旧缓冲区取值进行计算
                            wallCount += bufferOld[neighbourX, neighbourY];
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
        //     if (bufferNew != null)
        //     {
        //         for (int x = 0; x < width; x++)
        //         {
        //             for (int y = 0; y < height; y++)
        //             {
        //                 Gizmos.color = (bufferNew[x, y] == 1) ? Color.red : Color.white;
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