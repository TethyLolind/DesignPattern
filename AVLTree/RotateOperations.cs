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
            Balance(Head);
        }

        public override void Remove(BinaryTreeNode<int> searchNode)
        {
            base.Remove(searchNode);
            Balance(Head);
        }

        internal void Balance(BinaryTreeNode<int> node)
        {
            var ops = new AvlRotateOperations(this,node);
            if (BalanceState(node) =="right")
            {
                if (node.RightTreeNode!=null&&BalanceFactor(node.RightTreeNode)<0)
                {
                    
                    ops.LeftRightRotate();
                }
                else
                {
                    ops.LeftRotate();
                   
                }
            }
            else if (BalanceState(node) == "left")
            {
                if (node.LeftTreeNode!=null&& BalanceFactor(node.LeftTreeNode) > 0)
                {
                    ops.RightLeftRotate();
                }
                else
                {
                    ops.RightRotate();
                }
            }
            else
            {
                Balance(node.LeftTreeNode);
                Balance(node.RightTreeNode);
            }
        }

        public TreeClass(BinaryTreeNode<int> headNode) : base(headNode)
        {

            
        }


    }


    class AvlRotateOperations
    {
        private TreeClass tree;
        private BinaryTreeNode<int> node;
        private string nodeLocation;

        public AvlRotateOperations(TreeClass e,BinaryTreeNode<int> node)
        {
            this.tree = e;
            this.node = node;
            //如果是删除操作时 current就是被删的哪一个结点 如果是被加入时 cureent时被加入的节点的父节点
            if (node.ParentTreeNode.Value>node.Value)
            {
                this.nodeLocation = "left";
            }
            else
            {
                this.nodeLocation = "right";
            }

        }

       

        public void LeftRotate()
        {
           var newRootNode = node.RightTreeNode;
            //step1:
            if (this.nodeLocation=="left")
            {
                node.ParentTreeNode.RightTreeNode = newRootNode;
            }
            else if (this.nodeLocation == "right")
            {
                node.ParentTreeNode.LeftTreeNode = newRootNode;
            }
            //step2:
            node.RightTreeNode = newRootNode.LeftTreeNode;
            //step3:
            newRootNode.LeftTreeNode = node;   


        }

        public void RightRotate()
        {
            var newRootNode = node.LeftTreeNode;
            //step1:
            if (this.nodeLocation=="left")
            {
                node.ParentTreeNode.LeftTreeNode = newRootNode;
            }
            else if (this.nodeLocation == "right")
            {
                node.ParentTreeNode.RightTreeNode = newRootNode;
            }
            //step2:
            node.LeftTreeNode = newRootNode.RightTreeNode;
            //step3:
            newRootNode.RightTreeNode = node;            

        }

        public void LeftRightRotate()
        {
            var newRootNode = node.RightTreeNode.LeftTreeNode;


            node.RightTreeNode = newRootNode;

            newRootNode.RightTreeNode = newRootNode.ParentTreeNode;

            if (this.nodeLocation == "left")
            {
                node.ParentTreeNode.LeftTreeNode = newRootNode;
            }
            else if (this.nodeLocation == "right")
            {
                node.ParentTreeNode.RightTreeNode = newRootNode;
            }

            newRootNode.LeftTreeNode = node;
        }

        public void RightLeftRotate()
        {
            var newRootNode = node.LeftTreeNode.RightTreeNode;


            node.LeftTreeNode =newRootNode;

            newRootNode.LeftTreeNode = newRootNode.ParentTreeNode;

            if (this.nodeLocation == "left")
            {
                node.ParentTreeNode.LeftTreeNode = newRootNode;
            }
            else if (this.nodeLocation == "right")
            {
                node.ParentTreeNode.RightTreeNode = newRootNode;
            }

            newRootNode.RightTreeNode = node;

        }
    }
}
