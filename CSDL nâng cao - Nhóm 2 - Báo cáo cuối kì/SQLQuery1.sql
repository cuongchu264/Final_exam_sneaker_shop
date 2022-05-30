USE SNEAKER_SHOP
--thủ tục insert product

alter	 proc [dbo].[sp_Insert_Products] @productname nvarchar(255), @categoryid int, @price float, @avatar nvarchar(255), @description ntext, @instocks int, @branchid int, @img1 nvarchar(255),@img2 nvarchar(255), @img3 nvarchar(255), @img4 nvarchar(255) 
 as
	begin
		IF not EXISTS (SELECT BranchID FROM Products WHERE BranchID = @branchid)
	BEGIN
		PRINT N'Chi nhánh không tồn tại ?'
		RETURN
	END
	IF EXISTS (SELECT ProductName FROM Products WHERE ProductName = @productname)
	BEGIN
		PRINT N'Tên sản phẩm đã tồn tại ?'
		RETURN
	END
	BEGIN 
				begin try
					insert into [dbo].[Products](ProductName,CategoryId,Price,BranchID,Avatar,Description,InStocks,img1,img2,img3,img4)
		            values (@productname,@categoryid,@price,@branchid,@avatar, @description,@instocks,@img1,@img2,@img3,@img4)
					print N'Thêm thành công'
		
				end try
				begin catch
					print N'Thêm thất bại'
				end catch
	 END
	end
	 
GO

--thủ tục insert user

alter proc [dbo].[sp_Insert_Users] @userName nvarchar(255), @password nvarchar(255), @fullName nvarchar(255), @email nvarchar(255), @Phone nvarchar(255), @address nvarchar(Max), @avatar nvarchar(Max), @branchid int
 as
	begin
	IF EXISTS (SELECT Email FROM Users WHERE Email = @email)
	BEGIN
		PRINT N'Email đã tồn tại ?'
		RETURN
	END
	IF EXISTS (SELECT Phone FROM Users WHERE Phone = @Phone)
	BEGIN
		PRINT N'Phone đã tồn tại ?'
		RETURN
	END
    IF NOT EXISTS (SELECT BranchID FROM Users WHERE BranchID = @branchid)
	BEGIN
		PRINT N'Chi nhánh không tồn tại ?'
		RETURN
	END
    IF  ('%@gmail%' = @email)
	BEGIN
		PRINT N'Email không hợp lệ ?'
		RETURN
	END
      
	  DECLARE @dm int
	  select @dm = LEN(@Phone)

    IF  (@dm  > 10 AND @dm  < 10 )
	BEGIN
		PRINT N'Phone không hợp lệ ?'
		RETURN
	END
		insert into [dbo].Users(UserName,Password,FullName,Email,Phone,Address,Avatar,BranchID)
		values ( @userName , @password , @fullName , @email , @Phone , @address , @avatar , @branchid)
		PRINT N'Thành công'
	end
	 
GO

--Kiểm tra tình trạng bills
CREATE PROC sp_Status(@mahang NVARCHAR(100))
AS
BEGIN
     IF(@mahang NOT IN(SELECT Bills.Status FROM Bills))
	 PRINT N'Đơn hàng không tồn tại.'
	 ELSE
	    BEGIN
	       DECLARE @trangthai NVARCHAR(100)
	       SELECT @trangthai=Bills.Status
	       FROM Bills
	       WHERE Bills.BillId = @mahang
	       PRINT @mahang+N' có trạng thái là: '+@trangthai

	     END
END
GO

-- tìm product theo id
CREATE PROC sp_equal_Product(@productid NVARCHAR(100))
AS
BEGIN
     IF(@productid NOT IN(SELECT Products.ProductId FROM Products   ))
	 PRINT N'productid không tồn tại.'
	 ELSE
	    BEGIN
		   PRINT N'product có ID  : '+ @productid + N' là : '
	       SELECT *
	       FROM Products
	       WHERE Products.ProductId = @productid
	     
	     END
END
GO
-- tính số lượng đã bán của product
CREATE PROCEDURE sp_total_product (
	@productid NVARCHAR(100)
)
AS
BEGIN
    SELECT p.ProductId, p.ProductName , SUM(d.Quantity) AS Total_PRODUCT
	FROM Products p LEFT JOIN CartDetails d
	ON p.ProductId = d.ProductId
	WHERE p.ProductId = @productid	
	GROUP BY p.ProductId, p.ProductName
END
GO

