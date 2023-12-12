USE master
GO

CREATE DATABASE ThiTracNghiem
GO

USE ThiTracNghiem
GO

CREATE TABLE Lophoc
(
	MaLop CHAR(10) PRIMARY KEY,
	TenLop NVARCHAR
);
GO
CREATE TABLE MonHoc
(
	MaMH CHAR(10) PRIMARY KEY,
	TenMH NVARCHAR
);
GO
CREATE TABLE Chuong
(
	MaChuong CHAR(10) PRIMARY KEY,
	TenChuong NVARCHAR NOT NULL,
	MaMH CHAR(10),
	CONSTRAINT FK_Chuong_MonHoc FOREIGN KEY(MaMH)REFERENCES MonHoc(MaMH)
);
GO
CREATE TABLE TaiKhoan
(
	MaTK CHAR(10) PRIMARY KEY,
	MatKhau NVARCHAR NOT NULL,
	Email NVARCHAR NOT NULL,
	LoaiTK CHAR(1) NOT NULL,
);
GO
CREATE TABLE ThongTinCB
(
	MaCB CHAR(10) PRIMARY KEY,
	GioiTinh BIT NOT NULL,
	NgaySinh DATE NOT NULL,
	DiaChi NVARCHAR NOT NULL
	CONSTRAINT FK_ThongTinCB_TaiKhoan FOREIGN KEY(MaCB)REFERENCES TaiKhoan(MaTK)
);
GO
CREATE TABLE ThongTinSV
(
	MaSV CHAR(10) PRIMARY KEY,
	GioiTinh BIT NOT NULL,
	NgaySinh DATE NOT NULL,
	DiaChi NVARCHAR NOT NULL,
	CONSTRAINT FK_ThongTinSV_TaiKhoan FOREIGN KEY(MaSV)REFERENCES TaiKhoan(MaTK)
);

GO
CREATE TABLE DanhSachLop
(
	MaSV CHAR(10),
	MaLop CHAR(10),
	PRIMARY KEY (MaSV,MaLop),
	CONSTRAINT FK_DanhSachLop_ThongTinSV FOREIGN KEY(MaSV)REFERENCES ThongTinSV(MaSV),
	CONSTRAINT FK_DanhSachLop_LopHoc FOREIGN KEY(MaLop)REFERENCES LopHoc(MaLop)
);
GO
CREATE TABLE Cauhoi
(
	MaCauHoi CHAR(10) PRIMARY KEY,
	NoiDungCauHoi NVARCHAR NOT NULL,
	DapanA NVARCHAR NOT NULL,
	DapanB NVARCHAR NOT NULL,
	DapanC NVARCHAR NOT NULL,
	DapanD NVARCHAR NOT NULL,
	DapanDung CHAR(1) NOT NULL,
	MaChuong CHAR(10),
	CONSTRAINT FK_CauHoi_Chuong FOREIGN KEY(MaChuong)REFERENCES Chuong(MaChuong)
);
CREATE TABLE DeThi
(
	MaDeThi CHAR(10) PRIMARY KEY,
	TenDeThi NVARCHAR NOT NULL,
	TGlambai TIME NOT NULL,
	SoLuongCau INT NOT NULL,
	NoiDungDeThi NVARCHAR NOT NULL,
	MaCB CHAR(10),
	MaLop CHAR(10),
	MaMH CHAR(10),
	CONSTRAINT FK_DeThi_ThongTinCB FOREIGN KEY(MaCB)REFERENCES ThongTinCB(MaCB),
	CONSTRAINT FK_DeThi_LopHoc FOREIGN KEY(MaLop)REFERENCES LopHoc(MaLop),
	CONSTRAINT FK_DeThi_MonHoc FOREIGN KEY(MaMH)REFERENCES MonHoc(MaMH)
);
CREATE TABLE BaiLam
(
	MaBaiLam CHAR(10),
	MaSV CHAR(10),
	DapanDaChon NVARCHAR,
	TrangThai BIT NOT NULL,
	PRIMARY KEY (MaBaiLam, MaSV),
	CONSTRAINT FK_BaiLam_DeThi FOREIGN KEY(MaBaiLam)REFERENCES DeThi(MaDeThi),
	CONSTRAINT FK_BaiLam_ThongTinSV FOREIGN KEY(MaSV)REFERENCES ThongTinSV(MaSV)
);
--DROP DATABASE ThiTracNghiem