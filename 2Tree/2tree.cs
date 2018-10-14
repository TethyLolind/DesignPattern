using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _2Tree
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        private BinaryTreeNode<T> _leftTreeNode;
        private BinaryTreeNode<T> _rightTreeNode;
        private BinaryTreeNode<T> _parentTreeNode;


        public  BinaryTreeNode<T> LeftTreeNode
        {
            get { return _leftTreeNode; }
            set
            {
                _leftTreeNode = value;
                value._parentTreeNode = this;
            }
        }

        public BinaryTreeNode<T> RightTreeNode {
            get { return _rightTreeNode; }
            set
            {
                _rightTreeNode = value;
                value._parentTreeNode = this;
            }
        }

        public BinaryTreeNode<T> ParentTreeNode
        {
            get { return _parentTreeNode; }
            set { _parentTreeNode = value; }
        }
    }

    public class BinaryTree
    {
        public  BinaryTreeNode<int> Head;
        public BinaryTreeNode<int> Current;
        private int count = 0;

        public BinaryTree(BinaryTreeNode<int> headNode)
        {
            Head = headNode;
            Current = Head;
        }

        public virtual void AddTo(BinaryTreeNode<int> addInNode)
        {
            Current = Head;
            AddToRe(addInNode);

            #region avl++

           

            #endregion

        }



        private void AddToRe(BinaryTreeNode<int> addInNode)
        {
            if (Current != null)
            {
                var isLargerThanCurrent = CompareTo(addInNode, Current);
                if (isLargerThanCurrent > 0)//比当前大
                {
                    if (Current.RightTreeNode == null)
                    {
                        Current.RightTreeNode = addInNode;
                        
                    }
                    else
                    {
                        Current = Current.RightTreeNode;
                        AddToRe(addInNode);
                    }
                }
                else if (isLargerThanCurrent < 0)//比当前小
                {
                    if (Current.LeftTreeNode == null)
                    {
                        Current.LeftTreeNode = addInNode;
                        
                    }
                    else
                    {
                        Current = Current.LeftTreeNode;
                        AddToRe(addInNode);
                    }
                }
                else//两者相等
                {
                    if (Current.RightTreeNode != null)
                    {

                        Current = Current.RightTreeNode;
                        AddToRe(addInNode);
                    }
                    else
                    {
                        Current.RightTreeNode = addInNode; //相同的加在右边
                        
                    }
                }
            }
            else
            {
                Head = addInNode;
                addInNode.ParentTreeNode = null;
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

            var isLargerThanCurrent = CompareTo(searchNode, Current);
            if (isLargerThanCurrent > 0)//比当前大
            {
                if (Current.RightTreeNode == null)//当前没有更大的
                {
                    return new Tuple<bool, BinaryTreeNode<int>>(false, null);
                }
                //当前右边有更大的
                parentNode = Current;
                Current = Current.RightTreeNode;
                return ContainsRe(searchNode, parentNode);


            }
            else if (isLargerThanCurrent < 0)//比当前小
            {
                if (Current.LeftTreeNode == null)//当前没有更小的
                {
                    return new Tuple<bool, BinaryTreeNode<int>>(false, null);
                }

                parentNode = Current;
                Current = Current.LeftTreeNode;
                return ContainsRe(searchNode, parentNode);
            }
            else//正好就是
            {
                return new Tuple<bool, BinaryTreeNode<int>>(true, parentNode);
            }


        }

        public Tuple<bool, BinaryTreeNode<int>> Contains(BinaryTreeNode<int> searchNode)
        {
            Current = Head;
            if (Current == null)
            {
                return new Tuple<bool, BinaryTreeNode<int>>(false, null);
            }
            
            return ContainsRe(searchNode, Current.ParentTreeNode);
        }


        public virtual void Remove(BinaryTreeNode<int> searchNode)
        {
            RemoveRe(searchNode);
            
        }

        public void RemoveRe(BinaryTreeNode<int> searchNode)
        {
            var searchResult = Contains(searchNode);
            if (!searchResult.Item1)//没找到
            {
                Console.WriteLine("do not have this node");
            }
            else//找到了
            {
                var parentNode = searchResult.Item2;
                if (parentNode == null) //如果删除的是头结点
                {
                    var mostLeft = ToMostLeft(Head.RightTreeNode); //找到右子树最左

                    mostLeft.LeftTreeNode = Head.LeftTreeNode; //左子树放在右子树最左的节点的左节点上
                    

                    Head = Head.RightTreeNode; //右子书上提
                    Head.ParentTreeNode = null;

                    return;
                }

                if (searchNode.Value > parentNode.Value) //找到的点 是parent的右节点
                {
                    if (parentNode.RightTreeNode.RightTreeNode != null) //要移除的节点的  右节点不为空
                    {
                        parentNode.RightTreeNode = parentNode.RightTreeNode.RightTreeNode;//设儿子
                      

                        if (parentNode.RightTreeNode.LeftTreeNode == null) //左空右不空
                        {
                            
                        }
                        else//左右都不空
                        {
                            var mostLeft = ToMostLeft(parentNode.RightTreeNode.RightTreeNode);
                            
                            mostLeft.LeftTreeNode = parentNode.RightTreeNode.LeftTreeNode;//设儿子
                    
                        }

                    }
                    else //要移除的节点的  右节点为空
                    {
                        if (parentNode.RightTreeNode.LeftTreeNode == null) //左右都为空
                        {
                            parentNode.RightTreeNode = null;
                        }
                        else //左不空右空
                        {
                            parentNode.RightTreeNode = parentNode.RightTreeNode.LeftTreeNode;//设儿子
                         
                        }
                    }
                }
                else ////找到的点 是parent的左节点
                {
                    if (parentNode.LeftTreeNode.RightTreeNode != null) //要移除的节点的右节点不为空
                    {
                        parentNode.LeftTreeNode = parentNode.LeftTreeNode.RightTreeNode;
     
                        if (parentNode.LeftTreeNode.LeftTreeNode == null)
                        {
                            
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
            Current = Head;
            return Tranverse();
        }

        private int Tranverse()
        {
            if (this.Current==null)
            {
                return 0;
            }

            int count = 0;
            PreOrder(this.Current, ref count);
            return count;


        }

        private void PreOrder(BinaryTreeNode<int> node,ref int count)
        {
            if (node==null)
            {
                return;
            }
            Console.WriteLine(node.Value);
            count++;
            PreOrder(node.LeftTreeNode,ref count);
            PreOrder(node.RightTreeNode, ref count);
            
        }

    }
}
