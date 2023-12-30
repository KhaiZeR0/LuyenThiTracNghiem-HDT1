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
VALUES (01, N'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', 'caophankhai123@gmail.com', 0);
GO
--pass 123
select * from TaiKhoan
select * from DanhSachLop
select * from ThongTinSV
select * from ThongTinCB
select * from Lophoc
select * from DeThi
select * from BaiLam
select * from CauHoi

delete BaiLam where MaSV = 'SV001'