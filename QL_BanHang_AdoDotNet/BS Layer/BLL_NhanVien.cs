﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_BanHang_AdoDotNet.DB_Layer;
using QL_BanHang_AdoDotNet.DTO;

namespace QL_BanHang_AdoDotNet.BS_Layer
{
    public class BLL_NhanVien
    {
        public static List<NhanVien> LayToanBoNhanVien()
        {
            return Query_DAL.LayToanBoNhanVien();
        }
        public static int InsertNhanVien(string MaNhanVien, string TenNhanVien, string DiaChi,
            string DienThoai, string GioiTinh, string NgaySinh, string ChucVu, string Luong)
        {
            if (CheckKey(MaNhanVien))
            {
                return 0;
            }
            string sql = $"Insert into dbo.NhanVien(MaNhanVien,TenNhanVien, DiaChi,"
                + $"DienThoai,GioiTinh,NgaySinh,ChucVu,Luong)"
                + $"Values"
                + $"('{MaNhanVien}',N'{TenNhanVien}',N'{DiaChi}',"
                + $"'{DienThoai}',N'{GioiTinh}','{NgaySinh}',N'{ChucVu}',{Luong})";
            return Query_DAL.InsertData(sql);
        }
        private static bool CheckKey(string MaNhanVien)
        {
            //Return true nếu trùng, return false nếu không trùng
            List<NhanVien> dsNV = Query_DAL.LayToanBoNhanVien();
            foreach (NhanVien nv in dsNV)
            {
                if (nv.MaNhanVien.Trim() == MaNhanVien)
                {
                    return true;
                }

            }
            return false;
        }
        public static int UpdateNhanVien(NhanVien nv)
        {
            string sql = $"Update dbo.NhanVien " +
                $"set TenNhanVien=N'{nv.TenNhanVien}'," +
                $"DiaChi=N'{nv.DiaChi}',DienThoai='{nv.DienThoai}',GioiTinh=N'{nv.GioiTinh}',ChucVu=N'{nv.ChucVu}'," +
                $"Luong={nv.Luong},NgaySinh='{nv.NgaySinh}'" +
                $"Where MaNhanVien='{nv.MaNhanVien}'";
            return Query_DAL.UpdateData(sql);
        }
        public static int DeleteNhanVien(string MaNhanVien)
        {
            string sql = $"Delete from dbo.NhanVien " +
                $"Where MaNhanVien='{MaNhanVien}'";
            return Query_DAL.DeleteData(sql);
        }
    }
}
