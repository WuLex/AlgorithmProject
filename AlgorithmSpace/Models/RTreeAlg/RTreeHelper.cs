using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.RTreeAlg
{
    public class RTreeHelper
    {
        public static void RunRTreeSearch(double searchLatitude, double searchLongitude, double searchRadius)
        {
            RTree rTree = new RTree();

            // 插入餐厅到 R-tree 中
            rTree.Insert(new Restaurant { Name = "餐厅 1", Latitude = 37.7749, Longitude = -122.4194 });
            rTree.Insert(new Restaurant { Name = "餐厅 2", Latitude = 37.7894, Longitude = -122.4061 });
            rTree.Insert(new Restaurant { Name = "餐厅 3", Latitude = 37.7955, Longitude = -122.3940 });
            rTree.Insert(new Restaurant { Name = "餐厅 4", Latitude = 37.7836, Longitude = -122.4192 });
            rTree.Insert(new Restaurant { Name = "餐厅 5", Latitude = 37.7689, Longitude = -122.4331 });

            // 搜索指定范围内的餐厅
            List<Restaurant> nearbyRestaurants = rTree.Search(searchLatitude, searchLongitude, searchRadius);

            // 打印附近的餐厅
            Console.WriteLine($"{searchRadius} 公里范围内的附近餐厅:");
            foreach (var restaurant in nearbyRestaurants)
            {
                Console.WriteLine(restaurant.Name);
            }
        }

        //测试
        public static void RunRTreeSearch()
        {
            RTree rTree = new RTree();

            // 插入餐厅到 R-tree 中
            rTree.Insert(new Restaurant { Name = "餐厅 1", Latitude = 37.7749, Longitude = -122.4194 });
            rTree.Insert(new Restaurant { Name = "餐厅 2", Latitude = 37.7894, Longitude = -122.4061 });
            rTree.Insert(new Restaurant { Name = "餐厅 3", Latitude = 37.7955, Longitude = -122.3940 });
            rTree.Insert(new Restaurant { Name = "餐厅 4", Latitude = 37.7836, Longitude = -122.4192 });
            rTree.Insert(new Restaurant { Name = "餐厅 5", Latitude = 37.7689, Longitude = -122.4331 });

            // 搜索 20 公里内的餐厅
            List<Restaurant> nearbyRestaurants = rTree.Search(37.7749, -122.4194, 20.0);

            // 打印附近的餐厅
            Console.WriteLine("20 公里范围内的附近餐厅:");
            foreach (var restaurant in nearbyRestaurants)
            {
                Console.WriteLine(restaurant.Name);
            }
        }

        //测试
        public static void RunRTreeTestData()
        {
            RTree rTree = new RTree();

            // 插入餐厅到 R-tree 中
            rTree.Insert(new Restaurant { Name = "餐厅 1", Latitude = 37.7749, Longitude = -122.4194 });
            rTree.Insert(new Restaurant { Name = "餐厅 2", Latitude = 37.7894, Longitude = -122.4061 });
            rTree.Insert(new Restaurant { Name = "餐厅 3", Latitude = 37.7955, Longitude = -122.3940 });
            rTree.Insert(new Restaurant { Name = "餐厅 4", Latitude = 37.7836, Longitude = -122.4192 });
            rTree.Insert(new Restaurant { Name = "餐厅 5", Latitude = 37.7689, Longitude = -122.4331 });

            // 搜索指定范围内的餐厅
            List<Restaurant> nearbyRestaurants = rTree.Search(37.7749, -122.4194, 20.0);

            Console.WriteLine("计算结果如下：");
            foreach (var restaurant in nearbyRestaurants)
            {
                double distance = CalculateDistance(restaurant.Latitude, restaurant.Longitude, 37.7749, -122.4194);
                Console.WriteLine($"{restaurant.Name}与目标位置之间的距离：{distance}公里");
            }
        }

        // 计算两点之间的距离
        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double earthRadius = 6371.39;  // 地球半径（单位：公里）

            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return earthRadius * c;
        }

        //将角度值转换为弧度值的方法
        //角度制到弧度制的公式：弧度 = 角度 * π / 180。其中，π 是一个无理数，代表圆的周长与直径之间的比值，约等于 3.14159。
        private static double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
