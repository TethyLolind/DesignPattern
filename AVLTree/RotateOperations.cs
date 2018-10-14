using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2Tree;
using NotImplementedException = System.NotImplementedException;

namespace AVLTree
{
    public class TreeClass : BinaryTree
    {
        public int Leftheight(BinaryTreeNode<int> node)
        {
            return MaxChildHeight(node.LeftTreeNode);
        }

        public int Rightheight(BinaryTreeNode<int> node)
        {
            return MaxChildHeight(node.RightTreeNode);
        }

        public int MaxChildHeight(BinaryTreeNode<int> node)
        {
            if (node!=null)
            {
                return 1 + Math.Max(MaxChildHeight(node.LeftTreeNode), MaxChildHeight(node.RightTreeNode));
            }

            return 0;
        }

        public int BalanceFactor(BinaryTreeNode<int> node)
        {
            return Rightheight(node) - Leftheight(node);
        }

        public string BalanceState(BinaryTreeNode<int> node)
        {
            if (BalanceFactor(node)>1)
            {
                return "right";//右边高的大于1了
            }
            else if (BalanceFactor(node) < -1)
            {
                return "left";//左边高的大于1了
            }
            else
            {
                return "equal";//平衡状态
            }
            
        }

        public override void AddTo(BinaryTreeNode<int> addInNode)
        {
            base.AddTo(addInNode);
            Balance();
        }

        public override void Remove(BinaryTreeNode<int> searchNode)
        {
            base.Remove(searchNode);
            Balance();
        }

        internal void Balance()
        {
            var ops = new AvlRotateOperations(this);
            if (BalanceState(Current)=="right")
            {
                if (Current.RightTreeNode!=null&&BalanceFactor(Current.RightTreeNode)<0)
                {
                    
                    ops.LeftRightRotate();
                }
                else
                {
                    ops.LeftRotate();
                   
                }
            }
            else if (BalanceState(Current) == "left")
            {
                if (Current.LeftTreeNode!=null&& BalanceFactor(Current.LeftTreeNode) > 0)
                {
                    ops.RightLeftRotate();
                }
                else
                {
                    ops.RightRotate();
                }
            }
        }

        public TreeClass(BinaryTreeNode<int> headNode) : base(headNode)
        {

            
        }


    }


    class AvlRotateOperations
    {
        public TreeClass Tree { get; }

        public AvlRotateOperations(TreeClass e)
        {
            this.Tree = e;
            //如果是删除操作时 current就是被删的哪一个结点 如果是被加入时 cureent时被加入的节点的父节点
        }

       

        public void LeftRotate()
        {
           


        }

        public void RightRotate()
        {
            

        }

        public void LeftRightRotate()
        {

        }

        public void RightLeftRotate()
        {

        }
    }
}
