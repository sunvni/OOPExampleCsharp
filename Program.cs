using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication4
{
    class Program
    {
        public static List<SinhVien> dsSinhVien = new List<SinhVien>();
        public static List<GiaoVien> dsGiaoVien = new List<GiaoVien>();
        static void Main(string[] args)
        {
            bool isExit = false;
            int func = 1;
            while (!isExit)
            {
                Console.WriteLine("Chon 1 de them Sinh Vien");
                Console.WriteLine("Chon 2 de them Giao Vien");
                Console.WriteLine("Chon 3 de in danh sach Sinh Vien");
                Console.WriteLine("Chon 4 de in danh sach Giao Vien");
                Console.WriteLine("Chon 5 de sap xep danh sach Sinh Vien");
                Console.WriteLine("Chon 6 de sap xep danh sach Giao Vien");
                Console.WriteLine("Chon 0 de thoat");
                func = Convert.ToInt32(Console.ReadLine());
                switch (func)
                {
                    case 1:
                        {
                            NhapThongTin(true);
                            break;
                        }
                    case 2:
                        {
                            NhapThongTin(false);
                            break;
                        }
                    case 3:
                        {
                            InDanhSachSinhVien();
                            break;
                        }
                    case 4:
                        {
                            InDanhSachGiaoVien();
                            break;
                        }

                    case 5:
                        {
                            SapXep(true);
                            InDanhSachSinhVien();
                            break;
                        }

                    case 6:
                        {
                            SapXep(false);
                            InDanhSachGiaoVien();
                            break;
                        }
                    default:
                        {
                            isExit = true;
                            break;
                        }
                }
            }


        }

        static void NhapThongTin(bool isSinhVien)
        {
            if(isSinhVien)
            {
                Console.WriteLine("Nhap Ho ten");
                string name = Console.ReadLine();

                Console.WriteLine("Nhap Ngay Sinh");
                string ngaySinh = Console.ReadLine();


                Console.WriteLine("Nhap Lop");
                string lop = Console.ReadLine();


                Console.WriteLine("Nhap diem TB");
                int diemTB = Convert.ToInt32(Console.ReadLine());
                dsSinhVien.Add(new SinhVien(name, ngaySinh, lop, diemTB));
            }
            else
            {
                Console.WriteLine("Nhap Ho ten");
                string name = Console.ReadLine();

                Console.WriteLine("Nhap Ngay Sinh");
                string ngaySinh = Console.ReadLine();


                Console.WriteLine("Nhap Khoa");
                string khoa = Console.ReadLine();


                Console.WriteLine("Nhap so bai bao");
                int soBaiBao = Convert.ToInt32(Console.ReadLine());
                dsGiaoVien.Add(new GiaoVien(name, ngaySinh, khoa, soBaiBao));
            }
        }

        static void InDanhSachSinhVien()
        {
            if(dsSinhVien != null)
            {
                foreach (SinhVien sinhVien in dsSinhVien)
                {
                    Console.WriteLine("Ho ten:" + sinhVien.strHoten);
                    Console.WriteLine("Ngay sinh:" + sinhVien.strNgaySinh);
                    Console.WriteLine("Diem TB:" + sinhVien.diemTB);
                    Console.WriteLine("Lop:" + sinhVien.lop);
                    Console.WriteLine("Dieu kien khen thuong :" + sinhVien.setKhenThuong().ToString());
                    Console.WriteLine();
                }
            }
            
        }
        static void InDanhSachGiaoVien()
        {
            if (dsGiaoVien != null)
            {
                foreach (GiaoVien giaoVien in dsGiaoVien)
                {
                    Console.WriteLine("Ho ten:" + giaoVien.strHoten);
                    Console.WriteLine("Ngay sinh:" + giaoVien.strNgaySinh);
                    Console.WriteLine("So bai Bao:" + giaoVien.soBaiBao);
                    Console.WriteLine("Khoa:" + giaoVien.khoa);
                    Console.WriteLine("Dieu kien khen thuong :" + giaoVien.setKhenThuong().ToString());
                    Console.WriteLine();
                }
            }
        }
        static void SapXep(bool isSinhVien)
        {
            if(isSinhVien) dsSinhVien = dsSinhVien.OrderByDescending(o => o.diemTB).ToList();
            else dsGiaoVien = dsGiaoVien.OrderByDescending(o => o.soBaiBao).ToList();
        }
    }
}

public class Nguoi
{
    public string strHoten;
    public string strNgaySinh;

    public Nguoi(string name = "",string ngaysinh = "")
        {
            this.strHoten = name;
            this.strNgaySinh = ngaysinh;
        }
}

public class SinhVien : Nguoi
{
    public string lop;
    public int diemTB;
    public SinhVien(string name="",string ngaysinh="",string lop = "", int diemTB = 0) : base(name,ngaysinh)
    {
        this.diemTB = diemTB;
        this.lop = lop;
    }
    public bool setKhenThuong()
    {
        return diemTB > 8;
    }
}
public class GiaoVien:Nguoi
{
    public string khoa;
    public int soBaiBao;
    public GiaoVien(string name = "", string ngaysinh = "", string khoa = "", int soBaiBao = 0) : base(name,ngaysinh)
    {
        this.khoa = khoa;
        this.soBaiBao = soBaiBao;
    }
    public bool setKhenThuong()
    {
        return soBaiBao > 0;
    }
}