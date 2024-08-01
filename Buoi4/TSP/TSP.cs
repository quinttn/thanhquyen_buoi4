using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    internal class TSP
    {
        static int soDiem;
        static double[,] maTranKhoangCach;
        static bool[] daThamQuan;
        static double chiPhiTong;

        static void Main()
        {
            Console.Write("Nhap so diem: ");
            soDiem = int.Parse(Console.ReadLine());

            double[,] toaDo = new double[soDiem, 2];
            for (int i = 0; i < soDiem; i++)
            {
                Console.WriteLine($"\nNhap toa do {i + 1}:");
                Console.Write("Nha x: ");
                toaDo[i, 0] = double.Parse(Console.ReadLine());
                Console.Write("Nhap y: ");
                toaDo[i, 1] = double.Parse(Console.ReadLine());
            }

            // Tạo ma trận khoảng cách 
            maTranKhoangCach = new double[soDiem, soDiem];
            for (int i = 0; i < soDiem; i++)
            {
                for (int j = 0; j < soDiem; j++)
                {
                    // Tính khoảng cách
                    maTranKhoangCach[i, j] = tinhKhoangCach(toaDo[i, 0], toaDo[i, 1], toaDo[j, 0], toaDo[j, 1]);
                }
            }

            Console.WriteLine("\nMa tran khoang cach");
            for (int i = 0; i < soDiem; i++)
            {
                for (int j = 0; j < soDiem; j++)
                {
                    Console.Write($"{maTranKhoangCach[i, j]:F2}\t");
                }
                Console.WriteLine();
            }

            // Khởi tạo mảng đánh dấu các điểm đã được tham quan
            daThamQuan = new bool[soDiem];

            Console.WriteLine("\nDuong di co chi phi thap nhat:");
            duongDiChiPhiThapNhat(0);

            Console.WriteLine($"\nChi phi toi thieu la {chiPhiTong:F2}");
        }

        static double tinhKhoangCach(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        static int chiPhiThapNhat(int diem)
        {
            int diemGanNhat = -1; // Khởi tạo biến lưu điểm gần nhất
            double chiPhiThapNhat = double.MaxValue; // Khởi tạo chi phí thấp nhất

            // Duyệt qua tất cả các điểm để tìm điểm gần nhất chưa được tham quan
            for (int i = 0; i < soDiem; i++)
            {
                // Kiểm tra điểm chưa được tham quan và có khoảng cách nhỏ hơn chi phí thấp nhất hiện tại
                if (maTranKhoangCach[diem, i] != 0 && !daThamQuan[i] && maTranKhoangCach[diem, i] < chiPhiThapNhat)
                {
                    chiPhiThapNhat = maTranKhoangCach[diem, i]; // Cập nhật chi phí thấp nhất
                    diemGanNhat = i; // Cập nhật điểm gần nhất
                }
            }

            // Cập nhật tổng chi phí nếu tìm thấy điểm kế tiếp
            if (diemGanNhat != -1)
            {
                chiPhiTong += chiPhiThapNhat;
            }

            return diemGanNhat;
        }

        static void duongDiChiPhiThapNhat(int diem)
        {
            daThamQuan[diem] = true;
            Console.Write($"{diem + 1} ---> ");

            int diemKeTiep = chiPhiThapNhat(diem);
            if (diemKeTiep == -1)
            {
                diemKeTiep = 0;
                Console.Write($"{diemKeTiep + 1}");
                chiPhiTong += maTranKhoangCach[diem, diemKeTiep];
                return;
            }

            duongDiChiPhiThapNhat(diemKeTiep);
        }
    }
}
