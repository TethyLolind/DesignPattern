using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _2Tree
{
    class BinaryTreeNode<T>
    {
        private BinaryTreeNode<T> _leftTreeNode;
        private BinaryTreeNode<T> _rightTreeNode;
        private T _value;
      

        public BinaryTreeNode(T value)
        {
            this._value = value;
        }

        public T Value { get => _value; set => _value = value; }

        internal BinaryTreeNode<T> LeftTreeNode { get => _leftTreeNode; set => _leftTreeNode = value; }
        internal BinaryTreeNode<T> RightTreeNode { get => _rightTreeNode; set => _rightTreeNode = value; }

    }

    class BinaryTree
    {
        private BinaryTreeNode<int> _head;
        private BinaryTreeNode<int> _current;
        private int count = 0;

        public BinaryTree(BinaryTreeNode<int> headNode)
        {
            _head = headNode;
            _current = _head;
        }

        public void AddTo(BinaryTreeNode<int> addInNode)
        {
            _current = _head;
            AddToRe(addInNode);
        }

        private void AddToRe(BinaryTreeNode<int> addInNode)
        {
            if (_current != null)
            {
                var isLargerThanCurrent = CompareTo(addInNode, _current);
                if (isLargerThanCurrent > 0)
                {
                    if (_current.RightTreeNode == null)
                    {
                        _current.RightTreeNode = addInNode;
                    }
                    else
                    {
                        _current = _current.RightTreeNode;
                        AddToRe(addInNode);
                    }
                }
                else if (isLargerThanCurrent < 0)
                {
                    if (_current.LeftTreeNode == null)
                    {
                        _current.LeftTreeNode = addInNode;
                    }
                    else
                    {
                        _current = _current.LeftTreeNode;
                        AddToRe(addInNode);
                    }
                }
                else
                {
                    if (_current.RightTreeNode != null)
                    {

                        _current = _current.RightTreeNode;
                        AddToRe(addInNode);
                    }
                    else
                    {
                        _current.RightTreeNode = addInNode; //相同的加在右边
                    }
                }
            }
            else
            {
                _head = addInNode;
            }
        }

        private int CompareTo(BinaryTreeNode<int> addInNode, BinaryTreeNode<int> current)
        {
            if (addInNode.Value == current.Value)
            {
                return 0;
            }
            else if (addInNode.Value > current.Value)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public Tuple<bool, BinaryTreeNode<int>> ContainsRe(BinaryTreeNode<int> searchNode,
            BinaryTreeNode<int> parentNode)
        {

            var isLargerThanCurrent = CompareTo(searchNode, _current);
            if (isLargerThanCurrent > 0)
            {
                if (_current.RightTreeNode == null)
                {
                    return new Tuple<bool, BinaryTreeNode<int>>(false, null);
                }

                parentNode = _current;
                _current = _current.RightTreeNode;
                return ContainsRe(searchNode, parentNode);


            }
            else if (isLargerThanCurrent < 0)
            {
                if (_current.LeftTreeNode == null)
                {
                    return new Tuple<bool, BinaryTreeNode<int>>(false, null);
                }

                parentNode = _current;
                _current = _current.LeftTreeNode;
                return ContainsRe(searchNode, parentNode);
            }
            else
            {
                return new Tuple<bool, BinaryTreeNode<int>>(true, parentNode);
            }


        }

        public Tuple<bool, BinaryTreeNode<int>> Contains(BinaryTreeNode<int> searchNode)
        {
            _current = _head;
            if (_current == null)
            {
                return new Tuple<bool, BinaryTreeNode<int>>(false, null);
            }

            BinaryTreeNode<int> parent = null;
            return ContainsRe(searchNode, parent);
        }


        public void Remove(BinaryTreeNode<int> searchNode)
        {
            var searchResult = Contains(searchNode);
            if (!searchResult.Item1)
            {
                Console.WriteLine("do not have this node");
            }
            else
            {
                var parentNode = searchResult.Item2;
                if (parentNode == null) //如果删除的是头结点
                {
                    var mostLeft = ToMostLeft(_head.RightTreeNode); //找到最左
                    mostLeft.LeftTreeNode = _head.LeftTreeNode; //左子书放在柚子树最左
                    _head = _head.RightTreeNode; //右子书上提

                    return;
                }

                if (searchNode.Value > parentNode.Value) //是rightnode
                {
                    if (parentNode.RightTreeNode.RightTreeNode != null) //要移除的节点的  右不为空
                    {
                        if (parentNode.RightTreeNode.LeftTreeNode == null) //左空右不空
                        {
                            parentNode.RightTreeNode = parentNode.RightTreeNode.RightTreeNode;
                        }
                        else
                        {
                            var mostLeft = ToMostLeft(parentNode.RightTreeNode.RightTreeNode);
                            mostLeft.LeftTreeNode = parentNode.RightTreeNode.LeftTreeNode;
                        }

                    }
                    else
                    {
                        if (parentNode.RightTreeNode.LeftTreeNode == null) //左右都为空
                        {
                            parentNode.RightTreeNode = null;
                        }
                        else //左不空右空
                        {
                            parentNode.RightTreeNode = parentNode.RightTreeNode.LeftTreeNode;
                        }
                    }
                }
                else //是leftnode
                {
                    if (parentNode.LeftTreeNode.RightTreeNode != null) //要移除的节点的右节点不为空
                    {
                        if (parentNode.LeftTreeNode.LeftTreeNode == null)
                        {
                            parentNode.LeftTreeNode = parentNode.LeftTreeNode.RightTreeNode;
                        }
                        else
                        {
                            var mostLeft = ToMostLeft(parentNode.RightTreeNode.RightTreeNode);
                            mostLeft.LeftTreeNode = parentNode.LeftTreeNode.LeftTreeNode;
                        }

                    }
                    else
                    {
                        if (parentNode.LeftTreeNode.LeftTreeNode == null) //左右都为空
                        {
                            parentNode.LeftTreeNode = null;
                        }
                        else //左不空右空
                        {
                            parentNode.LeftTreeNode = parentNode.LeftTreeNode.LeftTreeNode;
                        }
                    }
                }


            }

        }

        private BinaryTreeNode<int> ToMostLeft(BinaryTreeNode<int> node)
        {
            while (node.LeftTreeNode != null)
            {
                node = ToMostLeft(node.LeftTreeNode);
            }

            return node;
        }

        public int Count()
        {
            _current = _head;
            return Tranversal(_current);
        }

        public int Tranversal(BinaryTreeNode<int> node)
        {
            var current = node;
            count++;
            if (current.LeftTreeNode==null)
            {
                if (current.RightTreeNode == null)
                {
                    return count;
                }
                else
                {
                    Tranversal(current.RightTreeNode);
                    return count;
                }
                
            }
            else
            {
                Tranversal(current.LeftTreeNode);
                Tranversal(current.RightTreeNode);
                return count;
            }

            
            
        }

    }
}
