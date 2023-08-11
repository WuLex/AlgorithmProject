using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.RTreeAlg
{
    public class RTree
    {
        private class Node
        {
            public List<Restaurant> Restaurants { get; set; }
            public List<Node> Children { get; set; }

            public Node()
            {
                Restaurants = new List<Restaurant>();
                Children = new List<Node>();
            }
        }

        private Node root;

        public RTree()
        {
            root = new Node();
        }
       
        // 插入餐厅信息到RTree
        public void Insert(Restaurant restaurant)
        {
            InsertRecursive(root, restaurant);
        }

        // 递归插入节点
        private void InsertRecursive(Node node, Restaurant restaurant)
        {
            if (node.Children.Count == 0) // 叶子节点
            {
                node.Restaurants.Add(restaurant);
                if (node.Restaurants.Count > 4) // 如有必要，进行节点分裂
                {
                    SplitNode(node);
                }
            }
            else // 非叶子节点
            {
                Node bestChild = ChooseBestChild(node, restaurant);
                InsertRecursive(bestChild, restaurant);
            }
        }

        /// <summary>
        /// 选择最佳的子节点来插入餐厅。
        /// 它首先初始化一个变量bestChild为null，并将初始最小距离minDistance设置为正无穷大。
        /// 然后，通过遍历节点的所有子节点，计算餐厅与每个子节点的最小距离。
        /// 如果找到了更小的距离，则更新bestChild和minDistance的值。
        /// 最后，返回最佳子节点。
        /// </summary>
        /// <param name="node"></param>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        private Node ChooseBestChild(Node node, Restaurant restaurant)
        {
            Node bestChild = null;
            double minDistance = double.MaxValue;

            foreach (var child in node.Children)
            {
                // 计算餐厅与子节点的最小距离
                double distance = RTreeHelper.CalculateDistance(restaurant.Latitude, restaurant.Longitude, child.Restaurants.Min(r => r.Latitude), child.Restaurants.Min(r => r.Longitude));

                if (distance < minDistance)
                {
                    bestChild = child;
                    minDistance = distance;
                }
            }

            return bestChild;
        }

        // 在这里执行节点分割逻辑
        // 这涉及重新分配餐厅和创建新的子节点
        // 它首先创建两个新的子节点newNode1和newNode2。
        // 然后，根据某种规则（例如，纬度或经度）将节点中的餐厅分配到这两个子节点中。
        // 在这里，我们简单地选择纬度进行分配，即将纬度小于等于中间纬度值的餐厅分配给newNode1，
        // 将纬度大于中间纬度值的餐厅分配给newNode2。分配完成后，清空节点中的餐厅列表，
        // 并将新的两个子节点添加到节点的子节点列表中。这样就完成了节点的分割操作。
        private void SplitNode(Node node)
        {
            // 创建新的两个子节点
            Node newNode1 = new Node();
            Node newNode2 = new Node();

            // 将节点中的餐厅按照某种规则分配到两个子节点中（例如，按照纬度或经度进行分配）
            // 这里简单地按照纬度进行分配
            double midLatitude = (node.Restaurants.Max(r => r.Latitude) + node.Restaurants.Min(r => r.Latitude)) / 2;

            foreach (var restaurant in node.Restaurants)
            {
                if (restaurant.Latitude <= midLatitude)
                {
                    newNode1.Restaurants.Add(restaurant);
                }
                else
                {
                    newNode2.Restaurants.Add(restaurant);
                }
            }

            // 清空节点中的餐厅列表
            node.Restaurants.Clear();

            // 将新的两个子节点添加到节点的子节点列表中
            node.Children.Add(newNode1);
            node.Children.Add(newNode2);
        }

        /// <summary>
        /// 根据给定的经纬度和半径搜索餐厅
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public List<Restaurant> Search(double latitude, double longitude, double radius)
        {
            List<Restaurant> result = new List<Restaurant>();
            SearchRecursive(root, latitude, longitude, radius, result);
            return result;
        }

        /// <summary>
        /// 递归搜索节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="radius"></param>
        /// <param name="result"></param>
        private void SearchRecursive(Node node, double latitude, double longitude, double radius, List<Restaurant> result)
        {
            foreach (var restaurant in node.Restaurants)
            {
                // 计算距离并检查是否在半径范围内
                double distance = RTreeHelper.CalculateDistance(latitude, longitude, restaurant.Latitude, restaurant.Longitude);
                if (distance <= radius)
                {
                    result.Add(restaurant);
                }
            }

            foreach (var child in node.Children)
            {
                // 检查子节点是否与搜索半径重叠
                if (OverlapsWithRadius(child, latitude, longitude, radius))
                {
                    SearchRecursive(child, latitude, longitude, radius, result);
                }
            }
        }

        // 判断节点是否与搜索半径重叠
        private bool OverlapsWithRadius(Node node, double latitude, double longitude, double radius)
        {
            // 计算搜索点到节点边界框的距离
            //通过比较给定纬度值和餐厅列表中最小纬度值以及最大纬度值，找到与给定纬度最接近的纬度值。这样做是为了确保所选择的纬度在给定纬度和餐厅列表纬度范围内。
            double closestLat = Math.Max(node.Restaurants.Min(r => r.Latitude), Math.Min(latitude, node.Restaurants.Max(r => r.Latitude)));
            //通过比较给定经度值和餐厅列表中最小经度值以及最大经度值，找到与给定经度最接近的经度值。这样做是为了确保所选择的经度在给定经度和餐厅列表经度范围内。
            double closestLon = Math.Max(node.Restaurants.Min(r => r.Longitude), Math.Min(longitude, node.Restaurants.Max(r => r.Longitude)));

            //计算给定纬度与最接近纬度之间的差值（绝对值），表示给定纬度与最接近纬度之间的垂直距离。
            double distanceLat = Math.Abs(latitude - closestLat);
            //计算给定经度与最接近经度之间的差值（绝对值），表示给定经度与最接近经度之间的水平距离。
            double distanceLon = Math.Abs(longitude - closestLon);

            // 检查距离是否在搜索半径内
            //根据勾股定理，计算出点与圆心的距离平方（即两点间直线距离的平方），然后与圆的半径的平方进行比较。如果点与圆心之间的距离小于或等于圆的半径，则表示点在圆内部或者在圆上；如果距离大于圆的半径，则表示点在圆外部。
            //可以用来判断某个地理位置（如餐厅的经纬度）是否在以用户当前位置为圆心、指定半径的范围内。如果条件成立，那么该地理位置就被认为是满足距离要求的。
            return (distanceLat * distanceLat + distanceLon * distanceLon) <= (radius * radius);
        }
    }
}
