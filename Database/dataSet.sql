INSERT INTO Lophoc (MaLop, TenLop)
VALUES (01, N'Lớp 1A');
INSERT INTO Lophoc (MaLop, TenLop)
VALUES (02, N'Lớp 2A');
INSERT INTO Lophoc (MaLop, TenLop)
VALUES (03, N'Lớp 3A');
INSERT INTO Lophoc (MaLop, TenLop)
VALUES (04, N'Lớp 4A');
GO

INSERT INTO TaiKhoan(MaTK, MatKhau, Email , LoaiTK)
VALUES (01, N'1', 'a', 0);
GO
INSERT INTO TaiKhoan(MaTK, MatKhau, Email , LoaiTK)
VALUES (02, N'1', 'caophankhai123@gmail.com', 0);
GO
select * from TaiKhoan
select * from DanhSachLop
select * from ThongTinSV
select * from ThongTinCB
select * from Lophoc
select * from DeThi
select * from BaiLam