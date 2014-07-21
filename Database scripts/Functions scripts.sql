-- Creating Functions --

CREATE FUNCTION create_username (@id int) RETURNS VARCHAR(60) 
AS 
BEGIN
	DECLARE @username varchar (60)
	DECLARE @fname varchar (60)
	DECLARE @lname varchar (60)
	DECLARE @birth_date date

	SELECT @fname = fname, @lname = lname, @birth_date = birth_date FROM clients WHERE id = id
	IF CHARINDEX(' ', @fname) != 0
	BEGIN
		SET @fname = SUBSTRING(@fname, 1, CHARINDEX(' ', @fname) - 1)
	END

	IF CHARINDEX(' ', @lname) != 0
	BEGIN
		SET @lname = SUBSTRING(@lname, 1, CHARINDEX(' ', @lname) - 1)
	END
	
	SET @username = @fname + @lname + CAST(DAY(@birth_date) AS VARCHAR(2))

	IF EXISTS (SELECT id FROM users WHERE username = @username)
	BEGIN
		SET @username = @username + CAST(MONTH(@birth_date) AS VARCHAR(2))
	END
	SET @username = LOWER(@username)
	RETURN @username
END

-- End Creating Functions