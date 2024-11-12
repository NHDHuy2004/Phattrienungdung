--Thủ tục lấy tất cả dữ liệu bảng Category
CREATE PROCEDURE [dbo].[Category_GetAll]
AS
SELECT * FROM Category
------------------------------------------
--Thủ tục lấy tất cả dữ liệu bảng Food
ALTER PROCEDURE [dbo].[Food_GetAll]
AS
SELECT * FROM Food
-- Thủ tục thêm, xóa, sửa bảng Category
creATE OR ALTER PROCEDURE [dbo].[Category_InsertUpdateDelete]
 @ID int output, -- Biến ID tự tăng, khi thêm xong phải lấy ra
 @Name nvarchar(200),
 @Type int,
 @Action int -- Biến cho biết thêm, xóa, hay sửa
AS
-- Nếu Action = 0, thực hiện thêm dữ liệu
IF @Action = 0
BEGIN
INSERT INTO [Category] ([Name],[Type])
VALUES (@Name, @Type)
SET @ID = @@identity -- Thiết lập ID tự tăng
END
-- Nếu Action = 1, thực hiện cập nhật dữ liệu
ELSE IF @Action = 1
BEGIN
UPDATE [Category] SET [Name] = @Name, [Type]=@Type
WHERE [ID] = @ID
END
-- Nếu Action = 2, thực hiện xóa dữ liệu
ELSE IF @Action = 2
BEGIN
DELETE FROM [Category] WHERE [ID] = @ID
END
------------------------------------------
-- Thủ tục thêm, xóa, sửa bảng Food
CREATE OR ALTER PROCEDURE [dbo].[Food_InsertUpdateDelete]
 @ID int output, -- Biến ID tự tăng, khi thêm xong phải lấy ra
 @Name nvarchar(1000),
 @Unit nvarchar(100),
 @FoodCategoryID int,
 @Price int,
 @Notes nvarchar(3000),
 @Action int -- Biến cho biết thêm, xóa, hay sửa
AS
IF @Action = 0 -- Nếu Action = 0, thêm dữ liệu
BEGIN
 INSERT INTO [Food]
([Name],[Unit],[FoodCategoryID],[Price],[Notes])
 VALUES (@Name, @Unit,@FoodCategoryID,@Price,@Notes)
 SET @ID = @@identity -- Thiết lập ID tự tăng
END
ELSE IF @Action = 1 -- Nếu Action = 1, cập nhật dữ liệu
BEGIN
 UPDATE [Food]
 SET [Name] = @Name,[Unit]=@Unit,[FoodCategoryID]=@FoodCategoryID,
 [Price]=@Price,[Notes]=@Notes
 WHERE [ID] = @ID
END
ELSE IF @Action = 2 -- Nếu Action = 2, xóa dữ liệu
BEGIN
 DELETE FROM [Food] WHERE [ID] = @ID
END
--Thủ tục lấy tất cả dữ liệu bảng Category
CREATE PROCEDURE [dbo].[Category_GetAll]
AS
SELECT * FROM Category
------------------------------------------
--Thủ tục lấy tất cả dữ liệu bảng Food
CREATE OR ALTER PROCEDURE [dbo].[Food_GetAll]
AS
SELECT * FROM Food
------------------------------------------