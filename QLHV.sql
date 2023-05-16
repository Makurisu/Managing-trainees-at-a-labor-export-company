create database QLHV
go
use QLHV
go

CREATE TABLE students (
    id VARCHAR(50) PRIMARY KEY,
    full_name NVARCHAR(255) NOT NULL,
    date_of_birth DATE,
    gender NVARCHAR(50),
    address NVARCHAR(255),
    phone NVARCHAR(20),
    email NVARCHAR(255),
	datePv DATE,
	ImagePath NVARCHAR(MAX),
	status NVARCHAR(100)
);

CREATE TABLE languages (
	name_language NVARCHAR(100) PRIMARY KEY
)

CREATE TABLE giangvien (
    id VARCHAR(50) PRIMARY KEY,
    full_name NVARCHAR(255) NOT NULL,
    date_of_birth DATE,
    gender NVARCHAR(50),
    address NVARCHAR(255),
    phone NVARCHAR(20),
    email NVARCHAR(255),
	language NVARCHAR(100) FOREIGN KEY REFERENCES languages(name_language),
	ImagePath NVARCHAR(MAX)
);
CREATE TABLE account (
	username VARCHAR(50) PRIMARY KEY,
	password VARCHAR(100),
	type varchar(50)
);

CREATE TABLE courses (
    id VARCHAR(50) PRIMARY KEY,
	id_giangvien VARCHAR(50) FOREIGN KEY REFERENCES giangvien(id),
    course_name NVARCHAR(255) NOT NULL,
	language NVARCHAR(100) FOREIGN KEY REFERENCES languages(name_language),
    course_fee VARCHAR(50)
);

CREATE TABLE student_courses (
    student_id VARCHAR(50) FOREIGN KEY REFERENCES students(id),
    course_id VARCHAR(50) FOREIGN KEY REFERENCES courses(id),
    status NVARCHAR(255),
	PRIMARY KEY (student_id, course_id)
);

CREATE TABLE contracts (
    id VARCHAR(50) PRIMARY KEY,
	name_contracts NVARCHAR(255),
    country NVARCHAR(100) FOREIGN KEY REFERENCES languages(name_language),
	nhomnganh NVARCHAR(100),
	nghenghiep NVARCHAR(500),
    salary INT,
	slot INT,
    status NVARCHAR(50)
);

CREATE TABLE student_contracts (
    student_id VARCHAR(50) FOREIGN KEY REFERENCES students(id),
    contract_id VARCHAR(50) FOREIGN KEY REFERENCES contracts(id)
	PRIMARY KEY (student_id, contract_id)
);


CREATE TABLE grades (
    student_id VARCHAR(50) FOREIGN KEY REFERENCES students(id),
    course_id VARCHAR(50) FOREIGN KEY REFERENCES courses(id),
    quatrinh1 VARCHAR(50),
	quatrinh2 VARCHAR(50),
	giuaki VARCHAR(50),
	cuoiki VARCHAR(50),
	tongket VARCHAR(50),
	PRIMARY KEY (student_id, course_id)
);

CREATE TABLE calender (
	schedule date PRIMARY KEY,
	event NVARCHAR(255)
)
go

--Thêm sự kiện mới
CREATE PROCEDURE InsertCalender
	@Date date,
	@Event NVARCHAR(255)
AS
BEGIN
	INSERT INTO calender (schedule, event) VALUES (@Date, @Event);
END
go
--Thêm học viên mới
CREATE PROCEDURE InsertStudent
    @FullName NVARCHAR(255),
    @DateOfBirth DATE,
    @Gender NVARCHAR(50),
    @Address NVARCHAR(255),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(255),
	@ImagePath NVARCHAR(MAX),
	@DatePV DATE
AS
BEGIN
    DECLARE @NewID INT;
    DECLARE @StudentCode NVARCHAR(50);
    DECLARE @PaddingZeros NVARCHAR(10) = '';
    DECLARE @MaxExistingID INT;
	DECLARE @password VARCHAR(50);

    SELECT @MaxExistingID = ISNULL(MAX(CAST(SUBSTRING(id, 3, 4) AS INT)), 0)
    FROM students;

    SET @NewID = @MaxExistingID + 1;

    IF @NewID < 10
        SET @PaddingZeros = '000';
    ELSE IF @NewID < 100
        SET @PaddingZeros = '00';
    ELSE IF @NewID < 1000
        SET @PaddingZeros = '0';
    ELSE
        SET @PaddingZeros = '';

    SET @StudentCode = 'HV' + @PaddingZeros + CAST(@NewID AS NVARCHAR);
	SET @password = CONCAT(@StudentCode, RIGHT(@Phone, 3));

    INSERT INTO students (id, full_name, date_of_birth, gender, address, phone, email, datePv, ImagePath, status)
    VALUES (@StudentCode, @FullName, @DateOfBirth, @Gender, @Address, @Phone, @Email, @DatePV, @ImagePath, N'Đang đào tạo');
	INSERT INTO account (username, password, type)
	VALUES (@StudentCode, @password, 'student');
END
go

--Thêm giảng viên
CREATE PROCEDURE InsertGiangVien
    @FullName NVARCHAR(255),
    @DateOfBirth DATE,
    @Gender NVARCHAR(50),
    @Address NVARCHAR(255),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(255),
	@Language NVARCHAR(100),
	@ImagePath NVARCHAR(MAX)
AS
BEGIN
    DECLARE @NewID INT;
    DECLARE @GiangVienCode NVARCHAR(50);
    DECLARE @PaddingZeros NVARCHAR(10) = '';
    DECLARE @MaxExistingID INT;
	DECLARE @password VARCHAR(50);

    SELECT @MaxExistingID = ISNULL(MAX(CAST(SUBSTRING(id, 3, 4) AS INT)), 0)
    FROM giangvien;

    SET @NewID = @MaxExistingID + 1;

    IF @NewID < 10
        SET @PaddingZeros = '000';
    ELSE IF @NewID < 100
        SET @PaddingZeros = '00';
    ELSE IF @NewID < 1000
        SET @PaddingZeros = '0';
    ELSE
        SET @PaddingZeros = '';

    SET @GiangVienCode = 'GV' + @PaddingZeros + CAST(@NewID AS NVARCHAR);
	SET @password = CONCAT(@GiangVienCode, RIGHT(@Phone, 3));

    INSERT INTO giangvien (id, full_name, date_of_birth, gender, address, phone, email, language, ImagePath)
    VALUES (@GiangVienCode, @FullName, @DateOfBirth, @Gender, @Address, @Phone, @Email, @Language, @ImagePath);
	INSERT INTO account (username, password, type)
	VALUES (@GiangVienCode, @password, 'teacher');
END
go

--Thêm khóa học mới
CREATE PROCEDURE InsertCourse
	@ID_teacher VARCHAR(50),
    @CourseName NVARCHAR(255),
    @Language NVARCHAR(100),
    @CourseFee DECIMAL(10)
AS
BEGIN
    DECLARE @NewID INT;
    DECLARE @CourseCode NVARCHAR(50);
    DECLARE @PaddingZeros NVARCHAR(10) = '';
    DECLARE @MaxExistingID INT;

    SELECT @MaxExistingID = ISNULL(MAX(CAST(SUBSTRING(id, 3, 4) AS INT)), 0)
    FROM courses;

    SET @NewID = @MaxExistingID + 1;

    IF @NewID < 10
        SET @PaddingZeros = '000';
    ELSE IF @NewID < 100
        SET @PaddingZeros = '00';
    ELSE IF @NewID < 1000
        SET @PaddingZeros = '0';
    ELSE
        SET @PaddingZeros = '';

    SET @CourseCode = 'L' + @PaddingZeros + CAST(@NewID AS NVARCHAR);

    INSERT INTO courses (id, id_giangvien, course_name, language, course_fee)
    VALUES (@CourseCode,@ID_teacher, @CourseName, @Language, @CourseFee);
END
go

--Thêm học viên vào khóa học
CREATE PROCEDURE EnrollStudentInCourse
    @StudentID VARCHAR(50),
    @CourseID VARCHAR(50)
AS
BEGIN
    INSERT INTO student_courses (student_id, course_id, status)
    VALUES (@StudentID, @CourseID, N'Chưa đóng');
	INSERT INTO grades (student_id, course_id, quatrinh1, quatrinh2, giuaki, cuoiki, tongket)
	VALUES (@StudentID, @CourseID, '','','','','');
END
go
--Thêm hợp đồng
CREATE PROCEDURE InsertContract
    @Name NVARCHAR(50),
    @Country NVARCHAR(255),
	@Nhomnganh NVARCHAR(100),
	@Nghenghiep NVARCHAR(500),
    @Salary VARCHAR(50),
	@Slot INT
AS
BEGIN
    DECLARE @NewID INT;
    DECLARE @ContractCode NVARCHAR(50);
    DECLARE @PaddingZeros NVARCHAR(10) = '';
    DECLARE @CountryCode NVARCHAR(10);
	DECLARE @MaxExistingID INT;

    SELECT @MaxExistingID = ISNULL(MAX(CAST(SUBSTRING(id, 3, 4) AS INT)), 0)
    FROM contracts;

    SELECT @NewID = @MaxExistingID + 1;

    IF @NewID < 10
        SET @PaddingZeros = '000';
    ELSE IF @NewID < 100
        SET @PaddingZeros = '00';
    ELSE IF @NewID < 1000
        SET @PaddingZeros = '0';
    ELSE
        SET @PaddingZeros = '';

    SET @ContractCode = 'HD' + @PaddingZeros + CAST(@NewID AS NVARCHAR);

    INSERT INTO contracts (id, name_contracts, country, nhomnganh ,nghenghiep, salary, slot, status)
    VALUES (@ContractCode, @Name, @Country, @Nhomnganh, @Nghenghiep, @Salary, @Slot, N'Đang tuyển');
END
go
--Thêm hợp đồng cho học viên

CREATE PROCEDURE AddContractToStudent
    @StudentID VARCHAR(50),
    @ContractID VARCHAR(50)
AS
BEGIN
    DECLARE @CurrentSlot INT;

    -- Kiểm tra số lượng slot hiện tại của hợp đồng
    SELECT @CurrentSlot = slot FROM contracts WHERE id = @ContractID;

    -- Nếu còn slot, tiến hành thêm hợp đồng cho học viên vào bảng student_contracts và trừ đi 1 slot
    IF @CurrentSlot > 1
    BEGIN
        INSERT INTO student_contracts (student_id, contract_id)
        VALUES (@StudentID, @ContractID);

        UPDATE contracts
        SET slot = @CurrentSlot - 1
        WHERE id = @ContractID;
    END
    ELSE
    BEGIN
        INSERT INTO student_contracts (student_id, contract_id)
        VALUES (@StudentID, @ContractID);

        UPDATE contracts
        SET slot = @CurrentSlot - 1,
		status = N'Hoàn thành'
        WHERE id = @ContractID;
    END
END;
go

--Cập nhật lịch trình
CREATE PROCEDURE updateEvent
	@Date date,
	@Event NVARCHAR(255)
AS
BEGIN
	UPDATE calender
	set event = @Event
	WHERE schedule = @Date
END
go

--Cập nhật hợp đồng
CREATE PROCEDURE updateContract
	@ID NVARCHAR(50),
	@Name NVARCHAR(50),
    @Country NVARCHAR(255),
    @Salary INT,
	@Slot INT
AS
BEGIN
	IF @Slot = 0
	BEGIN
		UPDATE contracts
		set name_contracts = @Name,
		country = @Country,
		salary = @Salary,
		slot = @slot,
		status = N'Hoàn thành'
		WHERE id = @ID
	END
	ELSE
	BEGIN
		UPDATE contracts
		set name_contracts = @Name,
		country = @Country,
		salary = @Salary,
		slot = @slot,
		status = N'Đang tuyển'
		WHERE id = @ID
	END
END
go

--Cập nhật thông tin học viên
CREATE PROCEDURE UpdateStudent
    @ID VARCHAR(50),
    @FullName NVARCHAR(255),
    @DateOfBirth DATE,
    @Gender NVARCHAR(50),
    @Address NVARCHAR(255),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(255),
	@DatePV DATE,
	@ImagePath NVARCHAR(MAX),
	@Status NVARCHAR(100)
AS
BEGIN
    UPDATE students
    SET full_name = @FullName,
        date_of_birth = @DateOfBirth,
        gender = @Gender,
        address = @Address,
        phone = @Phone,
        email = @Email,
		datePv = @DatePV,
		ImagePath = @ImagePath,
		status = @Status
    WHERE id = @ID
END
go
--Cập nhật thông tin khóa học
CREATE PROCEDURE UpdateCourse
    @ID VARCHAR(50),
    @ID_teacher VARCHAR(50),
    @CourseName NVARCHAR(255),
    @Language NVARCHAR(100),
    @CourseFee DECIMAL(10)
AS
BEGIN
    UPDATE courses
    SET id_giangvien = @ID_teacher,
		course_name = @CourseName,
        language = @Language,
        course_fee = @CourseFee
    WHERE id = @ID
END
go

--Cập nhật điểm
CREATE PROCEDURE UpdateGrade
    @ID_student VARCHAR(50),
    @ID_course VARCHAR(50),
    @Quatrinh1 VARCHAR(50),
    @Quatrinh2 VARCHAR(50),
    @Giuaki VARCHAR(50),
	@Cuoiki VARCHAR(50),
	@Tongket VARCHAR(50)
AS
BEGIN
    UPDATE grades
    SET quatrinh1 = @Quatrinh1,
		quatrinh2 = @Quatrinh2,
        giuaki = @Giuaki,
        cuoiki = @Cuoiki,
		tongket = @Tongket
    WHERE student_id = @ID_student and course_id = @ID_course
END
go

--Xóa học viên khỏi khóa học
CREATE PROCEDURE RemoveStudentFromCourse
    @ID VARCHAR(50),
	@Course_id VARCHAR(50)
AS
BEGIN
    DELETE FROM student_courses
    WHERE student_id = @ID and course_id = @Course_id
	DELETE FROM grades
	WHERE student_id = @ID and course_id = @Course_id
END
go
exec RemoveStudentFromCourse 'HV0001', 'L0002'
--Xóa hợp đồng
CREATE PROCEDURE DeleteContract
    @ID VARCHAR(50)
AS
BEGIN
    DELETE FROM contracts
    WHERE id = @ID
END
go

--Xóa lớp học
CREATE PROCEDURE DeleteCourse
    @ID VARCHAR(50)
AS
BEGIN
    DELETE FROM courses
    WHERE id = @ID
END
go

--Xóa học viên
CREATE PROCEDURE DeleteStudent
	@ID VARCHAR(50)
AS
BEGIN
	DELETE FROM students WHERE id = @ID
	DELETE FROM account WHERE username = @ID
	IF EXISTS (SELECT * FROM student_courses WHERE student_id = @ID)
	BEGIN 
		DELETE FROM student_courses WHERE student_id = @ID
	END
	IF EXISTS (SELECT * FROM student_contracts WHERE student_id = @ID)
	BEGIN
		DELETE FROM student_contracts WHERE student_id = @ID
	END
END
GO
--Xóa hợp đồng của học viên
CREATE PROCEDURE RemoveContractFromStudent
    @student_id VARCHAR(50),
    @contract_id VARCHAR(50)
AS
BEGIN
    DELETE FROM student_contracts
    WHERE student_id = @student_id AND contract_id = @contract_id;

    IF @@ROWCOUNT > 0
    BEGIN
        DECLARE @current_slots INT;
        SELECT @current_slots = slot FROM contracts WHERE id = @contract_id;

        UPDATE contracts
        SET slot = @current_slots + 1
        WHERE id = @contract_id;

        IF @current_slots + 1 > 0 AND (SELECT status FROM contracts WHERE id = @contract_id) = N'Hoàn thành'
        BEGIN
            UPDATE contracts
            SET status = N'Đang tuyển'
            WHERE id = @contract_id;
        END
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy học viên trong hợp đồng để xóa.';
    END
END

exec InsertStudent 'abc', '1/1/2002', 'nam', 'abc', '01231231', 'abc', '1/1/2002';

delete from contracts where id='HV0020';

select * from calender where schedule = '4/4/2023'

insert into student_contracts values('HV0001', 'HD0001');

exec InsertContract 'abc','abc',20,20;

insert into languages values(N'Nhật Bản');
insert into languages values(N'Hàn Quốc');
insert into languages values(N'Trung Quốc');
insert into languages values(N'Đài Loan');
insert into languages values(N'Mỹ');
insert into languages values(N'Nga');
SELECT * FROM giangvien where language = N'Hàn Quốc'

exec InsertCourse 'abc', 'abc', N'Hàn Quốc', 10000000;

SELECT student_id, courses.id, courses.id_giangvien, courses.course_name, courses.language, courses.course_fee, st_courses.status
                         FROM student_courses st_courses
                         JOIN courses ON st_courses.course_id = courses.id

SELECT contracts.id, contracts.name_contracts, contracts.country, contracts.nhomnganh, contracts.nghenghiep, contracts.salary
                         FROM student_contracts st_contracts
                         JOIN contracts ON st_contracts.contract_id = contracts.id

select * from student_contracts
SELECT c.id, c.course_name, c.language, c.course_fee
FROM courses c
WHERE NOT EXISTS (
    SELECT 1
    FROM student_courses hvl
    JOIN students hv ON hvl.student_id = hv.id
    WHERE hvl.course_id = c.id AND hv.id = 'HV0001'
);

SELECT * FROM students WHERE id = 'HV0001'

select * from account
SELECT password FROM account where username = 'HV0002'  
UPDATE account set password = '123' WHERE username = 'HV0002'

SELECT contracts.name_contracts, contracts.country, contracts.nhomnganh, contracts.nghenghiep
                                                         FROM student_contracts st_contracts
                                                         JOIN contracts ON st_contracts.contract_id = contracts.id
                                                            WHERE st_contracts.student_id = 'HV0001'

SELECT
    gv.full_name AS giangvien_name,
    c.id AS course_id,
    c.course_name,
    g.student_id,
    g.quatrinh1,
    g.quatrinh2,
    g.giuaki,
    g.cuoiki
FROM
    giangvien gv
JOIN courses c ON gv.id = c.id_giangvien
JOIN grades g ON c.id = g.course_id
WHERE
    gv.id = 'GV0001';


select * from grades

SELECT c.id AS course_id, c.course_name, g.quatrinh1, g.quatrinh2, g.giuaki, g.cuoiki
FROM
    students st
JOIN courses c ON st.id = c.id_giangvien
JOIN grades g ON c.id = g.course_id
WHERE
    st.id = 'GV0001'

SELECT 
    c.id AS course_id,
    c.course_name,
	c.language,
    g.quatrinh1,
    g.quatrinh2,
    g.giuaki,
    g.cuoiki
FROM
    students s
JOIN
    grades g ON s.id = g.student_id
JOIN
    courses c ON g.course_id = c.id
WHERE
    s.id = 'HV0001';

SELECT COUNT(*) FROM students

SELECT courses.id, courses.course_name, courses.language, courses.course_fee, st_courses.status
                                                        FROM student_courses st_courses
                                                            JOIN courses ON st_courses.course_id = courses.id
                                                                WHERE st_courses.student_id = 'HV0001' and courses. LIKE N'%a%'

select * from contracts where country LIKE N'Nhật%'

SELECT courses.id, courses.course_name, courses.language, courses.course_fee, st_courses.status
                                                        FROM student_courses st_courses
                                                            JOIN courses ON st_courses.course_id = courses.id
                                                                WHERE st_courses.student_id = 'HV0001' and course_id LIKE '%L0002%'
select * from courses where id = 'L0001'
exec DeleteCourse 'L0002'
DELETE FROM grades
	WHERE student_id = 'HV0001' and course_id = 'L0001'