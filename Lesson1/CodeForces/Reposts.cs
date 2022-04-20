using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.CodeForces
{
    /// <summary>
    /// Репосты Поликарпа (поиск наиб цепочки) 
    /// </summary>
    public class Reposts
    {
        public static void Run2()
        {
            int n = int.Parse(Console.ReadLine());
            int max = 2;

            string[] line1 = Console.ReadLine().Split(' ');
            string latestName = line1[0].ToLower();
            int max2 = 2;
            for (int i = 0; i < n - 1; i++)
            {

                string[] line = Console.ReadLine().Split(' ');
                if (line == null || line.Length == 0)
                {
                    if (max2 > max)
                        max = max2;
                    max2 = 1;

                }
                if (line[1] != "reposted")
                {
                    continue;
                }
                string name1 = line[0].ToLower();
                string name2 = line[2].ToLower();
                if (name2 == latestName)
                {
                    max2++;
                }
                else
                {
                    if (max2 > max)
                        max = max2;
                    max2 = 1;
                }
                latestName = name1;
            }
            if (max2 >= max)
                max = max2;

            Console.WriteLine(max);

        }
        public static void Run()
        {

            int n = int.Parse(Console.ReadLine());
            string[] firstLine = Console.ReadLine().Split(' ');
            var poly = new TreeNode<string>(firstLine[2].ToLower());
            poly.AddChild(firstLine[0].ToLower());
            var tree = new Tree<string>(poly);
            for (int i = 0; i < n - 1; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                string name1 = line[0].ToLower();
                string name2 = line[2].ToLower();

                var temp = tree.Find(name2);
                if (temp != null)
                    temp.AddChild(name1);
            }
            int maximum = tree.FindMax();
            Console.WriteLine(maximum);
        }
        public class TreeNode<T> where T : IComparable<T>
        {
            public T Value;

            List<TreeNode<T>> childrenList;
            public List<TreeNode<T>> ChildNodeList
            {
                get => childrenList;
            }

            public TreeNode(T value)
            {
                this.Value = value;
            }
            public TreeNode(T value, List<TreeNode<T>> children)
            {
                this.Value = value;
                childrenList = children;
            }

            public void AddChild(T value)
            {
                if (childrenList == null)
                    childrenList = new List<TreeNode<T>>();
                childrenList.Add(new TreeNode<T>(value));
            }

            public bool HasChild()
            {
                return childrenList?.Any() ?? false;
            }
        }
        public class Tree<T> where T : IComparable<T>
        {
            public TreeNode<T> root;
            public Tree(TreeNode<T> r)
            {
                root = r;
            }
            public TreeNode<T> Find(T value)
            {
                return Find(value, root);
            }
            private TreeNode<T> Find(T value, TreeNode<T> root)
            {
                if (root.Value.CompareTo(value) == 0)
                    return root;
                else
                    foreach (var child in root.ChildNodeList)
                    {
                        return Find(value, child);
                    }
                return null;
            }
            
            public int FindMax()
            {
                return FindMax(root);
            }
            public int FindMax(TreeNode<T> root)
            {
                if (root.ChildNodeList == null)
                    return 0;
                else
                {
                    if (root.ChildNodeList != null)
                    {
                        int newmax = 1;
                        foreach (var child in root.ChildNodeList)
                        {
                            if (FindMax(child) > newmax)
                            {
                                newmax = FindMax(child);
                            }
                        }
                        return 1 + newmax;
                    }
                    else return 1;

                }
            }
        }
    }

}