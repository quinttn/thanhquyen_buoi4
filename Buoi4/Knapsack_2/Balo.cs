using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_2
{
    internal class Balo
    {
        static void Nhap(out int n, out int[] a, out int[] b)
        {
            Console.Write("Nhap so do vat n = ");
            n = int.Parse(Console.ReadLine());

            a = new int[n + 1];  // Mảng chứa trọng lượng của từng đồ vật
            b = new int[n + 1];  // Mảng chứa giá trị của từng đồ vật

            for (int i = 1; i <= n; i++)
            {
                Console.Write($"\nTrong luong vat {i} = ");
                a[i] = int.Parse(Console.ReadLine());
                Console.Write($"Gia tri vat {i} = ");
                b[i] = int.Parse(Console.ReadLine());
            }
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

        static void Sx(int n, int[] a, int[] b, out int[] id)
        {
            id = new int[n + 1];  // Mảng chứa chỉ số của các đồ vật
            float[] t = new float[n + 1];  // Mảng chứa đơn giá

            for (int i = 1; i <= n; i++)
            {
                id[i] = i;  // Gán chỉ số ban đầu cho từng đồ vật
                t[i] = (float)b[i] / a[i];  // Tính đơn giá của đồ vật thứ i
            }
            // Sắp xếp giảm dần
            for (int i = 1; i <= n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    if (t[i] < t[j])
                    {
                        // Nếu đơn giá của đồ vật j lớn hơn đơn giá của đồ vật i, đổi chỗ chúng
                        Swap(ref a[i], ref a[j]);
                        Swap(ref id[i], ref id[j]);
                        Swap(ref b[i], ref b[j]);
                        Swap(ref t[i], ref t[j]);
                    }
                }
            }
        }

        static void balo(int n, int[] a, int[] b, int M)
        {
            int[] id;
            Sx(n, a, b, out id);

            int tkt = 0, tgt = 0;
            for (int i = 1; i <= n; i++)
            {
                while (tkt + a[i] <= M) // Lấy số lượng tối đa của đồ vật hiện tại sao cho tổng trọng lượng không vượt quá M
                {
                    Console.WriteLine($"Chon vat {id[i]} co trong luong la {a[i]} va gia tri la {b[i]}");
                    tgt += b[i];  // Cộng giá trị của đồ vật vào tổng giá trị
                    tkt += a[i];  // Cộng trọng lượng của đồ vật vào tổng trọng lượng
                }
            }

            Console.WriteLine($"\nTong trong luong la {tkt}");
            Console.WriteLine($"\nTong gia tri lon nhat la {tgt}");
        }

        static void Main(string[] args)
        {
            int n, m;
            int[] a, b;
            Nhap(out n, out a, out b);
            Console.Write("\nNhap kich thuoc ba lo M = ");
            m = int.Parse(Console.ReadLine());
            Console.WriteLine();
            balo(n, a, b, m);
        }
    }
}
