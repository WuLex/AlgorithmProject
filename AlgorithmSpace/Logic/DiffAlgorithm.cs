using AlgorithmSpace.Models.DiffAlg;

namespace AlgorithmSpace.Logic
{
    public static class DiffAlgorithm
    {
        public static void Diff(VNode oldVnode, VNode newVnode)
        {
            if (oldVnode.type != newVnode.type)
            {
                // 两个节点类型不同，直接用新节点替换旧节点
                Replace(oldVnode, newVnode);
            }
            else if (oldVnode.type == VNodeType.Element)
            {
                // 如果是元素节点，则进行属性和子元素的比较
                DiffElement(oldVnode, newVnode);
            }
            else if (oldVnode.type == VNodeType.Text)
            {
                // 如果是文本节点，则直接替换文本内容
                Replace(oldVnode, newVnode);
            }
            else if (oldVnode.type == VNodeType.Component)
            {
                // 如果是组件，则比较组件实例的相关属性和子元素
                DiffComponent(oldVnode, newVnode);
            }
        }

        private static void DiffElement(VNode oldVnode, VNode newVnode)
        {
            // 比较属性
            DiffProps(oldVnode.props, newVnode.props);

            // 比较子元素
            DiffChildren(oldVnode.children, newVnode.children);
        }

        private static void DiffComponent(VNode oldVnode, VNode newVnode)
        {
            // 如果组件名不同，则直接替换
            if (oldVnode.component.name != newVnode.component.name)
            {
                Replace(oldVnode, newVnode);
            }
            else
            {
                // 比较组件属性
                DiffProps(oldVnode.component.props, newVnode.component.props);

                // 比较子元素
                DiffChildren(oldVnode.children, newVnode.children);
            }
        }

        private static void DiffProps(Props oldProps, Props newProps)
        {
            if (!oldProps.Equals(newProps))
            {
                // 如果属性不同，则更新属性
                UpdateProps(oldProps, newProps);
            }
        }

        private static void DiffChildren(Children oldChildren, Children newChildren)
        {
            int oldStartIdx = 0;
            int oldEndIdx = oldChildren.nodes.Count - 1;
            int newStartIdx = 0;
            int newEndIdx = newChildren.nodes.Count - 1;

            // 从左到右比较子元素，直到有一个序列比较完毕
            while (oldStartIdx <= oldEndIdx && newStartIdx <= newEndIdx)
            {
                VNode oldNode = oldChildren.nodes[oldStartIdx];
                VNode newNode = newChildren.nodes[newStartIdx];

                if (oldNode.Equals(newNode))
                {
                    // 如果两个节点相同，则不需要更新
                    oldStartIdx++;
                    newStartIdx++;
                }
                else
                {
                    // 如果两个节点不同，则需要根据情况进行更新
                    bool hasOldNode = false;
                    for (int i = oldStartIdx; i <= oldEndIdx; i++)
                    {
                        if (oldChildren.nodes[i].Equals(newNode))
                        {
                            hasOldNode = true;
                            Replace(oldChildren.nodes[i], newNode);
                            oldStartIdx = i + 1;
                            newStartIdx++;
                            break;
                        }
                    }

                    if (!hasOldNode)
                    {
                        // 如果旧序列中没有相同的节点，则直接插入新节点
                        Insert(newNode, oldChildren.nodes[oldStartIdx]);
                        newStartIdx++;
                    }
                }
            }

            // 如果新序列还有剩余，则直接插入
            while (newStartIdx <= newEndIdx)
            {
                Insert(newChildren.nodes[newStartIdx], oldChildren.nodes[oldStartIdx]);
                newStartIdx++;
            }

            // 如果旧序列还有剩余，则删除
            while (oldStartIdx <= oldEndIdx)
            {
                Delete(oldChildren.nodes[oldStartIdx]);
                oldStartIdx++;
            }
        }

        private static void Replace(VNode oldNode, VNode newNode)
        {
            Console.WriteLine($"Replace {oldNode.type} node: {oldNode.tag ?? oldNode.text} => {newNode.tag ?? newNode.text}");
        }

        private static void UpdateProps(Props oldProps, Props newProps)
        {
            Console.WriteLine("Update props:");
            foreach (KeyValuePair<string, string> pair in newProps.attributes)
            {
                string oldValue;
                if (oldProps.attributes.TryGetValue(pair.Key, out oldValue))
                {
                    if (oldValue != pair.Value)
                    {
                        Console.WriteLine($"    {pair.Key}: {oldValue} => {pair.Value}");
                    }
                }
                else
                {
                    Console.WriteLine($"    {pair.Key}: {pair.Value}");
                }
            }
            foreach (string oldAttr in oldProps.attributes.Keys)
            {
                if (!newProps.attributes.ContainsKey(oldAttr))
                {
                    Console.WriteLine($" {oldAttr}: {oldProps.attributes[oldAttr]} => (removed)");
                }
            }
        }

        private static void Insert(VNode newNode, VNode refNode)
        {
            Console.WriteLine($"Insert node: {newNode.tag ?? newNode.text} (before {refNode.tag ?? refNode.text})");
        }

        private static void Delete(VNode oldNode)
        {
            Console.WriteLine($"Delete node: {oldNode.tag ?? oldNode.text}");
        }
    }
}