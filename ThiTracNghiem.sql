USE master
GO

CREATE DATABASE ThiTracNghiem
GO

USE ThiTracNghiem
GO

CREATE TABLE Lophoc
(
	MaLop char primary key,
	tenLop char
);
GO
CREATE TABLE MonHoc
(
	MaMH char primary key,
	tenMH char
);
GO
CREATE TABLE Chuong
(
	MaChuong char primary key,
	TenChuong char,
	MaMH char not null
);
GO
CREATE TABLE TaiKhoan
(
	maTK char primary key,
	email char not null,
	matKhau char not null,
	GioiTinh bit not null,
	NgaySinh date not null,
	NienKhoa char,
	LoaiTK char(1) not null,
	MaLop char
);
GO
CREATE TABLE Cauhoi
(
	MaCauHoi char primary key,
	NoiDungCauHoi nvarchar not null,
	dapanA nvarchar not null,
	dapanB nvarchar not null,
	dapanC nvarchar not null,
	dapanD nvarchar not null,
	dapanDung nvarchar not null,
	MaCHuong char
);
CREATE TABLE DeThi
(
	MaDeThi char primary key,
	TenDeThi nvarchar not null,
	MaCauHoi char,
	TGlambai time,
	SoLuongCau int
);
CREATE TABLE BaiLam
(
	MaBaiLam char primary key,
	MaHS char,
	DapanDaChon nvarchar
);
