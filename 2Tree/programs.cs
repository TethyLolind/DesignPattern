using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Tree
{
    class programs
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            
            BinaryTree a=new BinaryTree(new BinaryTreeNode<int>(111));
            a.AddTo(new BinaryTreeNode<int>(random.Next(1, 100)));
            a.AddTo(new BinaryTreeNode<int>(random.Next(1, 100)));
            a.AddTo(new BinaryTreeNode<int>(random.Next(1, 100)));
            a.AddTo(new BinaryTreeNode<int>(random.Next(1, 100)));
            a.AddTo(new BinaryTreeNode<int>(random.Next(1, 100)));
            a.AddTo(new BinaryTreeNode<int>(random.Next(1, 100)));
            a.AddTo(new BinaryTreeNode<int>(random.Next(1, 100)));
            a.AddTo(new BinaryTreeNode<int>(random.Next(1, 100)));
            a.AddTo(new BinaryTreeNode<int>(random.Next(1, 100)));

            a.AddTo(new BinaryTreeNode<int>(199));

            //a.Remove(new BinaryTreeNode<int>(199));
            a.Remove(new BinaryTreeNode<int>(111));
            Console.WriteLine(a.Contains(new BinaryTreeNode<int>(111)).Item1);
            Console.WriteLine(a.Count());
            
        }
    }
}
