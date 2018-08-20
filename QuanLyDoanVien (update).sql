create table KhenThuongDoanVien (
	MaDoanVien varchar(50) not null,
	TieuDeKhenThuong nvarchar(250) not null,
	NoiDungKhenThuong nvarchar(500) null,
	NgayKhenThuong datetime null,
	constraint FK_KhenThuongDoanVien_DoanVien
	foreign key (MaDoanVien)
	references DoanVien(MaDoanVien)
	on delete cascade
	on update cascade
)

create table LichSuChuyenDiaDiem (
	MaDoanVien varchar(50) null,
	ThoiGian datetime null,
	MaLop varchar(50) null,
	ThoiGianChuyen datetime null
)

create table LichSuChuyenDiaDiem (
	MaDoanVien varchar(50) null,
	ThoiGian datetime null,
	MaLop varchar(50) null,
	ThoiGianChuyen datetime null
)

alter table DoanVien
add
	HocLuc nvarchar(50) null,
	HanhKiem nvarchar(500) null

update DoanVien set HocLuc = N'Giỏi'
update DoanVien set HanhKiem = N'Tốt'

create view ThongTinKhenThuongDoanVien
as
	select KhenThuongDoanVien.MaDoanVien, DoanVien.TenDoanVien, KhenThuongDoanVien.TieuDeKhenThuong, KhenThuongDoanVien.NoiDungKhenThuong, KhenThuongDoanVien.NgayKhenThuong
	from KhenThuongDoanVien, DoanVien
	where KhenThuongDoanVien.MaDoanVien = DoanVien.MaDoanVien

alter view ThongTinDoanVien
as
	select DoanVien.MaDoanVien, DoanVien.TenDoanVien, DoanVien.NgaySinh, DoanVien.GioiTinh, DoanVien.NoiSinh, Lop.TenLop, Khoa.TenKhoa, Truong.TenTruong, DoanVien.NangKhieu, DoanVien.HocLuc, DoanVien.HanhKiem
	from DoanVien, Lop, Khoa, Truong
	where DoanVien.MaLop = Lop.MaLop and Lop.MaKhoa = Khoa.MaKhoa and Khoa.MaTruong = Truong.MaTruong

create view ThongTinLichSuChuyenDiaDiem
as
	select LichSuChuyenDiaDiem.MaDoanVien, DoanVien.TenDoanVien, LichSuChuyenDiaDiem.ThoiGian, Lop.TenLop as 'LopChuyen', Khoa.TenKhoa as 'KhoaChuyen', Truong.TenTruong as 'TruongChuyen', LichSuChuyenDiaDiem.ThoiGianChuyen
	from LichSuChuyenDiaDiem, DoanVien, Lop, Khoa, Truong
	where LichSuChuyenDiaDiem.MaDoanVien = DoanVien.MaDoanVien and LichSuChuyenDiaDiem.MaLop = Lop.MaLop and Lop.MaKhoa = Khoa.MaKhoa and Khoa.MaTruong = Truong.MaTruong