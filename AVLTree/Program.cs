using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2Tree;

namespace AVLTree
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Random random = new Random();

            TreeClass a = new TreeClass(new BinaryTreeNode<int>(50));
            for (int i = 0; i < 100; i++)
            {
                a.AddTo(new BinaryTreeNode<int>(random.Next(1, 100)));
            }
            a.AddTo(new BinaryTreeNode<int>(199));

            a.Remove(new BinaryTreeNode<int>(50));
            Console.WriteLine(a.Contains(new BinaryTreeNode<int>(199)).Item1);
            Console.WriteLine("总个数:{0}", a.Count());
        }
    }
}
