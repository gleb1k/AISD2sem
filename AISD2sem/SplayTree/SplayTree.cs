using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD2sem.SplayTree
{
    using System;

    public class SplayTree
    {
        private Node root;

        // Служебная функция для разворота поддерева с корнем y вправо.
        private static Node RightRotate(Node x)
        {
            Node y = x.LeftChild;
            x.LeftChild = y.RightChild;
            y.RightChild = x;
            return y;
        }

        // Служебная функция для разворота поддерева с корнем x влево 
        private static Node LeftRotate(Node x)
        {
            Node y = x.RightChild;
            x.RightChild = y.LeftChild;
            y.LeftChild = x;
            return y;
        }

        // Эта функция поднимет ключ
        // в корень, если он присутствует в дереве. 
        // Если такой ключ отсутствует в дереве, она
        // поднимет в корень самый последний элемент,
        // к которому был осуществлен доступ.
        // Эта функция изменяет дерево
        // и возвращает новый корень (root).
        private static Node Splay(Node root, int key)
        {
            // Базовые случаи: root равен NULL или
            // ключ находится в корне
            if (root == null || root.Key == key)
                return root;

            // Ключ лежит в левом поддереве
            if (root.Key > key)
            {
                // Ключа нет в дереве, мы закончили
                if (root.LeftChild == null) return root;

                // Zig-Zig (Левый-левый) 
                if (root.LeftChild.Key > key)
                {
                    // Сначала рекурсивно поднимем
                    // ключ как корень left-left
                    root.LeftChild.LeftChild = Splay(root.LeftChild.LeftChild, key);

                    // Первый разворот для root, 
                    // второй разворот выполняется после else 
                    root = RightRotate(root);
                }
                else if (root.LeftChild.Key < key) // Zig-Zag (Левый-правый) 
                {
                    // Сначала рекурсивно поднимаем
                    // ключ как корень left-right

                    root.LeftChild.RightChild = Splay(root.LeftChild.RightChild, key);

                    // Выполняем первый разворот для root.left
                    if (root.LeftChild.RightChild != null)
                        root.LeftChild = LeftRotate(root.LeftChild);
                }

                // Выполняем второй разворот для корня
                return (root.LeftChild == null) ?
                                       root : RightRotate(root);
            }
            else // Ключ находится в правом поддереве 
            {
                // Ключа нет в дереве, мы закончили
                if (root.RightChild == null) return root;

                // Zag-Zig (Правый-левый) 
                if (root.RightChild.Key > key)
                {
                    //Поднять ключ как корень right-left
                    root.RightChild.LeftChild = Splay(root.RightChild.LeftChild, key);

                    // Выполняем первый поворот для root.right
                    if (root.RightChild.LeftChild != null)
                        root.RightChild = RightRotate(root.RightChild);
                }
                else if (root.RightChild.Key < key)// Zag-Zag (Правый-правый) 
                {
                    // Поднимаем ключ как корень 
                    // right-right и выполняем первый разворот
                    root.RightChild.RightChild = Splay(root.RightChild.RightChild, key);
                    root = LeftRotate(root);
                }

                // Выполняем второй разворот для root
                return (root.RightChild == null) ?
                                       root : LeftRotate(root);
            }
        }

        // Функция поиска для splay-дерева. 
        // Обратите внимание, что эта функция возвращает 
        // новый корень splay-дерева. Если ключ 
        // присутствует в дереве, он перемещается в корень.
        public Node Search(int key)
        {
            return Splay(root, key);
        }

        // Служебная функция для вывода 
        // обхода в дерева ширину. 
        // Функция также выводит высоту каждого узла 
        public static void PreOrder(Node root)
        {
            if (root != null)
            {
                Console.Write(root.Key + " ");
                PreOrder(root.LeftChild);
                PreOrder(root.RightChild);
            }
        }
        public void Add(int key)
        {

            if (root == null)
                root = new Node(key);
            else
            {
                bool isFind = false;
                var rootCopy = root;
                while (isFind == false)
                {
                    if (key == rootCopy.Key)
                    {
                        rootCopy.Key = key;
                        isFind = true;
                    }
                    else if (key < rootCopy.Key)
                    {
                        if (rootCopy.LeftChild == null)
                        {
                            rootCopy.LeftChild = new Node(key);
                            isFind = true;
                        }
                        else
                            rootCopy = rootCopy.LeftChild;
                    }
                    else
                    {
                        if (rootCopy.RightChild == null)
                        {
                            rootCopy.RightChild = new Node(key);
                            isFind = true;
                        }
                        else
                            rootCopy = rootCopy.RightChild;
                    }
                }
            }
        }
    }
}
