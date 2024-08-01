using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        List<Item> items = new List<Item>
        {
            new Item { Value = 60, Weight = 10 },
            new Item { Value = 100, Weight = 20 },
            new Item { Value = 120, Weight = 30 }
        };

        int capacity = 50; // Đặt dung lượng tối đa của balo

        double maxValue = GreedyKnapsack(capacity, items);

        Console.WriteLine("Maximum value in Knapsack = " + maxValue);
    }

    public class Item
    {
        public int Value { get; set; } 
        public int Weight { get; set; } 

        public double Ratio { get { return (double)Value / Weight; } }
    }

    public static double GreedyKnapsack(int capacity, List<Item> items)
    {
        // Sắp xếp các item theo tỉ lệ giá trị/trọng lượng giảm dần
        items.Sort((x, y) => y.Ratio.CompareTo(x.Ratio));

        double totalValue = 0; // Khởi tạo tổng giá trị hiện tại
        int currentWeight = 0; // Khởi tạo trọng lượng hiện tại

        foreach (var item in items)
        {
            // Nếu trọng lượng hiện tại cộng thêm trọng lượng của item hiện tại vẫn nhỏ hơn hoặc bằng dung lượng tối đa
            if (currentWeight + item.Weight <= capacity)
            {
                // Thêm toàn bộ trọng lượng của item vào balo
                currentWeight += item.Weight;

                // Thêm toàn bộ giá trị của item vào tổng giá trị
                totalValue += item.Value;
            }
            else
            {
                // Nếu không thể thêm toàn bộ item, thêm phần trọng lượng còn lại của item vào balo
                int remainingWeight = capacity - currentWeight;

                // Tính toán và thêm giá trị tương ứng với phần trọng lượng còn lại vào tổng giá trị
                totalValue += item.Value * ((double)remainingWeight / item.Weight);

                break;
            }
        }

        return totalValue; 
    }
}
