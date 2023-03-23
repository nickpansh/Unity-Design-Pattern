/*** 
 * @Author: NickPansh
 * @Date: 2023-03-23 12:20:51
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-03-23 12:22:00
 * @FilePath: \Unity-Design-Pattern\Assets\GameProgrammingPatterns\DoubleBuffer\Scripts\BadCodeExample\GameController.cs
 * @Description: 这一段代码来自于：https://github.com/SebLague/Procedural-Cave-Generation/blob/master/Episode%2001/MapGenerator.cs
 * @Description: 在原始工程里，它用于生成一个程序化的洞穴，它能工作但是存在bug：未处理的单元格将访问了已处理单元格的当前前状态。这会导致地图出现强烈的对角线偏差。
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
using System.Collections;
using System;
namespace WenQu.DoubleBuffer.BadCodeExample
{
    public class MapGenerator : MonoBehaviour
    {

        public int width;
        public int height;

        public string seed;
        public bool useRandomSeed;

        [Range(0, 100)]
        public int randomFillPercent;

        int[,] map;

        void Start()
        {
            GenerateMap();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GenerateMap();
            }
        }

        void GenerateMap()
        {
            map = new int[width, height];
            RandomFillMap();

            for (int i = 0; i < 5; i++)
            {
                SmoothMap();
            }
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

        void SmoothMap()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
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


        void OnDrawGizmos()
        {
            if (map != null)
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        Gizmos.color = (map[x, y] == 1) ? Color.black : Color.white;
                        Vector3 pos = new Vector3(-width / 2 + x + .5f, 0, -height / 2 + y + .5f);
                        Gizmos.DrawCube(pos, Vector3.one);
                    }
                }
            }
        }

    }
}