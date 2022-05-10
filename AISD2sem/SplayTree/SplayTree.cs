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

        public SplayTree(Node head)
        {
            root = head;
        }
        public SplayTree() { }

        //Служебная функция для разворота поддерева с корнем y вправо.
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
        private  Node Splay(Node root, int key)
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
        public void Search(int key)
        {
            root =  Splay(root, key);
            root.Parent = null;
            MakeParents(root);
        }
        public void MakeParents(Node root)
        {
            if (root.RightChild != null)
            {
                root.RightChild.Parent = root;
                MakeParents(root.RightChild);
            }
            if (root.LeftChild != null)
            {
                root.LeftChild.Parent = root;
                MakeParents(root.LeftChild);
            }
        }
        /// <summary>
        /// Обход в ширину
        /// Вывод на консоль и возвращается строка (в конце всегда пробел)
        /// </summary>
        /// <returns></returns>
        public string BreadthFirst()
        {
            List<Node> toVist = new List<Node>();
            Console.WriteLine("Обход в ширину: ");
            toVist.Add(root);
            string str = null;
            while (toVist.Any())
            {
                var current = toVist[0];

                if (current.RightChild != null)
                    toVist.Add(current.RightChild);
                if (current.LeftChild != null)
                    toVist.Add(current.LeftChild);
                toVist.RemoveAt(0);
                Console.Write($"{current.Key} ");
                str += current.Key + " ";
            }
            Console.WriteLine();
            return str;
        }
        /// <summary>
        /// обойти всё дерево, следуя порядку (левое поддерево, вершина, правое поддерево). Элементы по возрастанию
        /// </summary>
        public void InfixTraverse()
        {
            Console.WriteLine("Обход: левое поддерево, вершина, правое поддерево");
            InfixTraverse(root);
            Console.WriteLine();
        }
        private void InfixTraverse(Node root)
        {
            if (root == null)
                return;
            if (root.LeftChild != null)
                InfixTraverse(root.LeftChild);
            Console.Write(root.Key + " ");
            if (root.RightChild != null)
                InfixTraverse(root.RightChild);

        }
        public void Add(int key)
        {

            if (root == null)
                root = new Node( key);
            else
            {
                bool isFind = false;
                var rootCopy = root;
                while (isFind == false)
                {
                    if (key == rootCopy.Key)
                    {
                        isFind = true;
                    }
                    else if (key < rootCopy.Key)
                    {
                        if (rootCopy.LeftChild == null)
                        {
                            rootCopy.LeftChild = new Node(key, rootCopy);
                            isFind = true;
                        }
                        else
                            rootCopy = rootCopy.LeftChild;
                    }
                    else
                    {
                        if (rootCopy.RightChild == null)
                        {
                            rootCopy.RightChild = new Node(key, rootCopy);
                            isFind = true;
                        }
                        else
                            rootCopy = rootCopy.RightChild;
                    }
                }
            }
        }
        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="value">удаляемое значение</param>
        public void Remove(int key)
        {
            if (root == null)
            {
                Console.WriteLine("Дерево пусто");
                return;
            }
            Remove(key, root);
        }
        private void Remove(int key, Node root)
        {
            if (root == null)
            {
                Console.WriteLine($"Элемент {key} в дереве отсутствует");
                return;
            }
            //Проверяем, надо ли искать в левом поддереве
            if (root.Key > key)
            {
                if (root.LeftChild == null)
                {
                    Console.WriteLine($"Элемент {key} в дереве отсутствует");
                    return;
                }
                else
                    Remove(key, root.LeftChild);
            }
            else if (root.Key < key)
            {
                if (root.RightChild == null)
                {
                    Console.WriteLine($"Элемент {key} в дереве отсутствует");
                    return;
                }
                else
                    Remove(key, root.RightChild);
            }
            else //root.Key == key - нашли узел, которы надо удалить
            {
                bool? isLeft = root.Parent != null
                    ? root.Parent.Key > root.Key
                    : (bool?)null; //нет родительского элемента - не может быть левыйм или правым
                //Если обоих детей нет, то удаляем текущий узел и 
                //обнуляем ссылку на него у родительского узла
                if (root.LeftChild == null && root.RightChild == null)
                {
                    if (root.Parent != null) //isLeft.HasValue
                    {
                        if (isLeft.Value)
                            root.Parent.LeftChild = null;
                        else
                            root.Parent.RightChild = null;
                    }
                    else
                        this.root = null;
                }
                //Если одного из детей нет, то значения полей 
                //ребёнка m ставим вместо соответствующих значений 
                //корневого узла, затирая его старые значения, 
                //и освобождаем память, занимаемую узлом m;
                else if (root.LeftChild != null && root.RightChild == null)
                {
                    //левый потомок есть, правого нет
                    if (isLeft.HasValue) //имеется родительский элемент
                    {
                        if (isLeft.Value)
                            root.Parent.LeftChild = root.LeftChild;
                        else
                            root.Parent.RightChild = root.LeftChild;
                    }
                    else
                        this.root = root.LeftChild;
                }
                else if (root.LeftChild == null && root.RightChild != null)
                {
                    //правый потомок есть, левого нет
                    if (isLeft.HasValue)
                    {
                        if (isLeft.Value)
                            root.Parent.LeftChild = root.RightChild;
                        else
                            root.Parent.RightChild = root.RightChild;
                    }
                    else
                        this.root = root.RightChild;
                }
                //оба потомка имеются
                else
                {
                    //Если левый узел m правого 
                    //поддерева отсутствует(n->right->left)
                    if (root.RightChild.LeftChild == null)
                    {
                        //Копируем из правого узла в удаляемый поля K, V 
                        //и ссылку на правый узел правого потомка.
                        root.Key = root.RightChild.Key;
                        root.RightChild = root.RightChild.RightChild;
                        if (root.RightChild != null)
                            root.RightChild.Parent = root;
                    }
                    else
                    {
                        //Возьмём самый левый узел m, правого поддерева n->right;
                        var mostLeft = root.RightChild;
                        while (mostLeft.LeftChild != null)
                            mostLeft = mostLeft.LeftChild;
                        //Скопируем данные (кроме ссылок на дочерние элементы) из m в n
                        root.Key = mostLeft.Key;
                        //удалим узел m.
                        mostLeft.Parent.LeftChild = null;
                    }
                }
            }
        }
    }
}
