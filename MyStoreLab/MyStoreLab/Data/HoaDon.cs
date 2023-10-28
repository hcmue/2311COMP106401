﻿using System;
using System.Collections.Generic;

namespace MyStoreLab.Data
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietHds = new HashSet<ChiTietHd>();
        }

        public int MaHd { get; set; }
        public string MaKh { get; set; } = null!;
        public DateTime NgayDat { get; set; }
        public DateTime? NgayCan { get; set; }
        public DateTime? NgayGiao { get; set; }
        public string? HoTen { get; set; }
        public string DiaChi { get; set; } = null!;
        public string CachThanhToan { get; set; } = null!;
        public string CachVanChuyen { get; set; } = null!;
        public double PhiVanChuyen { get; set; }
        public int MaTrangThai { get; set; }
        public string? MaNv { get; set; }
        public string? GhiChu { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; } = null!;
        public virtual NhanVien? MaNvNavigation { get; set; }
        public virtual TrangThai MaTrangThaiNavigation { get; set; } = null!;
        public virtual ICollection<ChiTietHd> ChiTietHds { get; set; }
    }
}
