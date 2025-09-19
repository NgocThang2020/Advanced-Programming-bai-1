using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MaTran
{
    private int[,] matrix;
    private int rows;
    private int cols;

    public MaTran(int rows, int cols)
    {
        this.rows = rows; // this trỏ đến biến instance của lớp
        this.cols = cols;
        matrix = new int[rows, cols];
    }

    public void Nhap()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Nhap phan tu [{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }
    public void Xuat()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public MaTran Tong(MaTran other)
    {
        if (this.rows != other.rows || this.cols != other.cols)
        {
            Console.WriteLine("Khong the tinh tong hai ma tran co kich thuoc khac nhau.");
            return null;
        }
        MaTran result = new MaTran(this.rows, this.cols);
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.cols; j++)
            {
                result.matrix[i, j] = this.matrix[i, j] + other.matrix[i, j];
            }
        }
        return result;
    }

    public MaTran Nhan(MaTran other)
    {
        if (this.cols != other.rows)
        {
            Console.WriteLine("Khong the nhan hai ma tran voi kich thuoc khong phu hop.");
            return null;
        }
        MaTran result = new MaTran(this.rows, other.cols);
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < other.cols; j++)
            {
                result.matrix[i, j] = 0;
                for (int k = 0; k < this.cols; k++)
                {
                    result.matrix[i, j] += this.matrix[i, k] * other.matrix[k, j];
                }
            }
        }
        return result;
    }

    public MaTran ChuyenVi()
    {
        MaTran result = new MaTran(this.cols, this.rows);
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.cols; j++)
            {
                result.matrix[j, i] = this.matrix[i, j];
            }
        }
        return result;
    }

    public int Min()
    {
        int min = matrix[0, 0];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }
            }
        }
        return min;
    }

    public int Max()
    {
        int max = matrix[0, 0];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
        }
        return max;
    }
}

namespace bai1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so dong: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot: ");
            int cols = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhap ma tran A: ");
            MaTran A = new MaTran(rows, cols);
            A.Nhap();
            A.Xuat();
            Console.WriteLine("Nhap ma tran B: ");
            MaTran B = new MaTran(rows, cols);
            B.Nhap();
            B.Xuat();

            MaTran C = A.Tong(B);
            if (C != null)
            {
                Console.WriteLine("Ma tran C = A + B: ");
                C.Xuat();
            }

            MaTran D = A.Nhan(B);
            if (D != null)
            {
                Console.WriteLine("Ma tran D = A * B: ");
                D.Xuat();
            }

            MaTran E = A.ChuyenVi();
            Console.WriteLine("Ma tran E = A^T: ");
            E.Xuat();

            Console.WriteLine($"Phan tu nho nhat trong ma tran A: {A.Min()}");
            Console.WriteLine($"Phan tu lon nhat trong ma tran A: {A.Max()}");
            Console.ReadKey();
        }
    }
}

