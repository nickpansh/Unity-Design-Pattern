
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WenQu.DesignPattern;
namespace WenQu.Command
{
    public class Starter : MonoBehaviour
    {
        public Transform controlTransform;

        // 指令字典
        private Dictionary<KeyCode, AbstractCommand> _cmdDict;

        // 使用栈，LIFO非常适合用来做撤销操作
        private Stack<AbstractCommand> undoCommands = new Stack<AbstractCommand>();
        private Stack<AbstractCommand> redoCommands = new Stack<AbstractCommand>();

        private bool isReplaying = false;

        // 重放间隔时间
        private const float _REPLAY_PAUSE_TIMER = 0.5f;



        void Start()
        {
            _cmdDict = new Dictionary<KeyCode, AbstractCommand>();
            // 按键和命令的映射
            _cmdDict.Add(KeyCode.UpArrow, new LargerCommand(controlTransform));
            _cmdDict.Add(KeyCode.DownArrow, new SmallerCommand(controlTransform));
            _cmdDict.Add(KeyCode.LeftArrow, new RotateLeft(controlTransform));
            _cmdDict.Add(KeyCode.RightArrow, new RotateRight(controlTransform));
            _cmdDict.Add(KeyCode.W, new UpCommand(controlTransform));
            _cmdDict.Add(KeyCode.S, new DownCommand(controlTransform));
            _cmdDict.Add(KeyCode.A, new LeftCommand(controlTransform));
            _cmdDict.Add(KeyCode.D, new RightCommand(controlTransform));

            // 命令组合
            CommandQueue queue = new CommandQueue();
            queue.AddCommand(new LargerCommand(controlTransform));
            queue.AddCommand(new RotateRight(controlTransform));
            // 命令组合，这里是同时变大旋转 
            _cmdDict.Add(KeyCode.Space, queue);
        }



        /// <summary>
        /// 找到Input所对应的command
        /// </summary>
        /// <returns>按钮对应的Command</returns>
        private AbstractCommand HandleInput()
        {
            if (Input.anyKeyDown)
            {
                foreach (var item in _cmdDict)
                {
                    if (Input.GetKeyDown(item.Key))
                    {
                        return item.Value;
                    }
                }
            }
            return null;
        }

        void Update()
        {
            // 回放中直接跳过
            if (isReplaying)
            {
                return;
            }

            // 命令的指针执行XX动作
            // 这一句调用是命令模式的精髓——把调用方和接收者进行了解耦
            // 如果不用命令模式，这里的代码应该是直接调用接收者的方法，调用方的代码将会很庞大
            var cmd = HandleInput();
            if (cmd != null)
            {
                cmd.Execute();
                // 插入undo栈
                undoCommands.Push(cmd);

                // 清空redo栈
                redoCommands.Clear();
            }

            // 撤销操作
            if (Input.GetKeyDown(KeyCode.U))
            {
                if (undoCommands.Count == 0)
                {
                    Debug.LogError("Can't undo because we are back where we started");
                }
                else
                {
                    AbstractCommand lastCommand = undoCommands.Pop();

                    lastCommand.Undo();

                    // 插入redo栈
                    redoCommands.Push(lastCommand);
                }
            }
            // 回撤操作
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (redoCommands.Count == 0)
                {
                    Debug.Log("Can't redo because we are at the end");
                }
                else
                {
                    AbstractCommand nextCommand = redoCommands.Pop();

                    nextCommand.Execute();

                    // 插入undo栈
                    undoCommands.Push(nextCommand);
                }
            }

            // 重放操作
            //Start replay
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartCoroutine(Replay());

                isReplaying = true;
            }
        }

        /// <summary>
        /// 重放操作
        /// </summary>
        /// <returns></returns>
        private IEnumerator Replay()
        {

            //强制重设状态
            (new ResetCommand(controlTransform)).Execute();
            yield return new WaitForSeconds(_REPLAY_PAUSE_TIMER);

            //undo栈转undo数组
            AbstractCommand[] oldCommands = undoCommands.ToArray();

            //This array is inverted so we iterate from the back
            for (int i = oldCommands.Length - 1; i >= 0; i--)
            {
                AbstractCommand currentCommand = oldCommands[i];

                currentCommand.Execute();

                yield return new WaitForSeconds(_REPLAY_PAUSE_TIMER);
            }

            isReplaying = false;
        }


    }
}