--Tạo cơ sở dữ liệu
create database QuanLyDoanVien

--Tạo bảng và liên kết
create table DangNhap (
	TenDangNhap nvarchar(50) not null,
	constraint FK_DangNhap primary key (TenDangNhap),
	MatKhau nvarchar(50) not null,
	Quyen nvarchar(50) null
)

create table Truong (
	MaTruong varchar(50) not null,
	constraint FK_Truong primary key (MaTruong),
	TenTruong nvarchar(250) null
)

create table Khoa (
	MaKhoa varchar(50) not null,
	constraint FK_Khoa primary key (MaKhoa),
	TenKhoa nvarchar(250) null,
	MaTruong varchar(50) null,
	constraint FK_Khoa_Truong
	foreign key (MaTruong)
	references Truong(MaTruong)
	on delete cascade
	on update cascade
)

create table Lop (
	MaLop varchar(50) not null,
	constraint FK_Lop primary key (MaLop),
	TenLop nvarchar(250) null,
	MaKhoa varchar(50) null,
	constraint FK_Lop_Khoa
	foreign key (MaKhoa)
	references Khoa(MaKhoa)
	on delete cascade
	on update cascade
)

create table DoanVien (
	MaDoanVien varchar(50) not null,
	constraint FK_DoanVien primary key (MaDoanVien),
	TenDoanVien nvarchar(250) null,
	NgaySinh datetime null,
	GioiTinh nvarchar(50) null,
	NoiSinh nvarchar(50) null,
	MaLop varchar(50) null,
	NangKhieu nvarchar(50) null,
	HocLuc nvarchar(50) null,
	HanhKiem nvarchar(500) null,
	constraint FK_DoanVien_Lop
	foreign key (MaLop)
	references Lop(MaLop)
	on delete cascade
	on update cascade
)

create table PhiVaSoDoan (
	MaDoanVien varchar(50) not null,
	constraint PK_PhiVaSoDoan primary key (MaDoanVien),
	DongDoanPhi bit null,
	SoDoan nvarchar(50) null,
	constraint FK_PhiVaSoDoan_DoanVien
	foreign key (MaDoanVien)
	references DoanVien(MaDoanVien)
	on delete cascade
	on update cascade
)

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

--Nhập dữ liệu vào các bảng
insert into DangNhap values (N'abcxyz', N'12345', N'Nhân viên')
insert into DangNhap values (N'admin', N'1234', N'Quản trị')
insert into DangNhap values (N'mono', N'xyz', N'Nhân viên')
insert into DangNhap values (N'quantri', N'999', N'Quản trị')
insert into DangNhap values (N'zero', N'0000', N'Nhân viên')

insert into Truong values ('T01', N'Trường Đại học Nhật Bản')
insert into Truong values ('T02', N'Trường Đại học Công nghệ')
insert into Truong values ('T03', N'Trường Đại học Luật')

insert into Khoa values ('K101', N'Khoa Tiếng Nhật', 'T01')
insert into Khoa values ('K201', N'Khoa Công nghệ thông tin', 'T02')
insert into Khoa values ('K202', N'Khoa Truyền thông - Mạng máy tính', 'T02')
insert into Khoa values ('K301', N'Khoa Luật', 'T03')

insert into Lop values ('L10101', N'Lớp TN01', 'K101')
insert into Lop values ('L10102', N'Lớp TN02', 'K101')
insert into Lop values ('L20101', N'Lớp CNTT01', 'K201')
insert into Lop values ('L20102', N'Lớp CNTT02', 'K201')
insert into Lop values ('L20201', N'Lớp TM01', 'K202')
insert into Lop values ('L20202', N'Lớp TM02', 'K202')
insert into Lop values ('L30101', N'Lớp Luat01', 'K301')
insert into Lop values ('L30102', N'Lớp Luat02', 'K301')

--Tạo khung nhìn
create view ThongTinDoanVien
as
	select DoanVien.MaDoanVien, DoanVien.TenDoanVien, DoanVien.NgaySinh, DoanVien.GioiTinh, DoanVien.NoiSinh, Lop.TenLop, Khoa.TenKhoa, Truong.TenTruong, DoanVien.NangKhieu, DoanVien.HocLuc, DoanVien.HanhKiem
	from DoanVien, Lop, Khoa, Truong
	where DoanVien.MaLop = Lop.MaLop and Lop.MaKhoa = Khoa.MaKhoa and Khoa.MaTruong = Truong.MaTruong

create view TrangThaiPhiVaSoDoan
as
	select PhiVaSoDoan.MaDoanVien, DoanVien.TenDoanVien, PhiVaSoDoan.DongDoanPhi, PhiVaSoDoan.SoDoan
	from DoanVien, PhiVaSoDoan
	where DoanVien.MaDoanVien = PhiVaSoDoan.MaDoanVien

create view ThongTinKhenThuongDoanVien
as
	select KhenThuongDoanVien.MaDoanVien, DoanVien.TenDoanVien, KhenThuongDoanVien.TieuDeKhenThuong, KhenThuongDoanVien.NoiDungKhenThuong, KhenThuongDoanVien.NgayKhenThuong
	from KhenThuongDoanVien, DoanVien
	where KhenThuongDoanVien.MaDoanVien = DoanVien.MaDoanVien

create view ThongTinLichSuChuyenDiaDiem
as
	select LichSuChuyenDiaDiem.MaDoanVien, DoanVien.TenDoanVien, LichSuChuyenDiaDiem.ThoiGian, Lop.TenLop as 'LopChuyen', Khoa.TenKhoa as 'KhoaChuyen', Truong.TenTruong as 'TruongChuyen', LichSuChuyenDiaDiem.ThoiGianChuyen
	from LichSuChuyenDiaDiem, DoanVien, Lop, Khoa, Truong
	where LichSuChuyenDiaDiem.MaDoanVien = DoanVien.MaDoanVien and LichSuChuyenDiaDiem.MaLop = Lop.MaLop and Lop.MaKhoa = Khoa.MaKhoa and Khoa.MaTruong = Truong.MaTruong