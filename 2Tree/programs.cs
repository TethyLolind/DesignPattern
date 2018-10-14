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
            
            BinaryTree a=new BinaryTree(new BinaryTreeNode<int>(50));
            for (int i = 0; i < 100; i++)
            {
                a.AddTo(new BinaryTreeNode<int>(random.Next(1, 100)));
            }
            a.AddTo(new BinaryTreeNode<int>(199));

            a.Remove(new BinaryTreeNode<int>(50));
            Console.WriteLine(a.Contains(new BinaryTreeNode<int>(199)).Item1);
            Console.WriteLine("总个数:{0}",a.Count());
            
        }
    }
}
